using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Microsoft.Extensions.Internal;
using Newtonsoft.Json;
using ZwiepsHaakHoek.Contentful;
using ZwiepsHaakHoek.Services.Localization;
using ZwiepsHaakHoek.Services.LocalStorage;

namespace ZwiepsHaakHoek.Services.ContentfulCache
{
    public class ContentfulCache : IContentfulCache
    {
        private const double MAX_CACHE_AGE_IN_HOURS = 1.0D;

        private readonly ILocalStorage _localStorage;
        private readonly ISystemClock _systemClock;
        private readonly ILocalization _localization;
        private readonly IContentfulClient _contentfulClient;

        public ContentfulCache(ILocalStorage localStorage, ISystemClock systemClock, ILocalization localization, IContentfulClient contentfulClient)
        {
            _localStorage = localStorage;
            _systemClock = systemClock;
            _localization = localization;
            _contentfulClient = contentfulClient;
        }

        public async Task<TContentModel> GetContentAsync<TContentModel, TContentfulModel>(
            Func<TContentfulModel, Task<TContentModel>> mapFunc, 
            bool forceCMSFetch) where TContentfulModel : ContentType
        {
            QueryBuilder<TContentfulModel> queryBuilder = QueryBuilder<TContentfulModel>.New.ContentTypeIs(ContentfulContentTypes.GetContentTypeName<TContentfulModel>()).LocaleIs(_localization.SelectedCulture.Locale.Code).Limit(1);
            return await GetContentAsync<TContentModel, TContentfulModel>(mapFunc, queryBuilder, forceCMSFetch);
        }

        public async Task<TContentModel> GetContentAsync<TContentModel, TContentfulModel>(
            Func<TContentfulModel, Task<TContentModel>> mapFunc,
            QueryBuilder<TContentfulModel> queryBuilder,
            bool forceCMSFetch) 
            where TContentfulModel : ContentType
        {
            return await GetContentAsync<TContentModel, TContentfulModel>(mapFunc, queryBuilder, (ContentfulCollection) => ContentfulCollection.FirstOrDefault(), forceCMSFetch);
        }

        public async Task<TContentModel> GetContentAsync<TContentModel, TContentfulModel>(
            Func<TContentfulModel, Task<TContentModel>> mapFunc,
            QueryBuilder<TContentfulModel> queryBuilder, 
            Func<ContentfulCollection<TContentfulModel>, TContentfulModel> filter,
            bool forceCMSFetch) 
            where TContentfulModel : ContentType
        {
            CacheDTO<TContentModel>? dtoContent = await GetDTOContentFromCacheAsync<TContentModel>();

            if (dtoContent is null || !dtoContent.IsValid(MAX_CACHE_AGE_IN_HOURS, _systemClock) || forceCMSFetch)
            {
                TContentfulModel cmsContent = await GetCMSContentAsync<TContentfulModel>(queryBuilder, filter);

                dtoContent = await CacheDTO<TContentModel>.Create<TContentfulModel>(cmsContent, mapFunc, _systemClock);

                // Fire and forget the saving to cache
                _ = SaveDTOToCacheAsync<TContentModel>(dtoContent);
            }

            return dtoContent.ContentModel;
        }

        public async Task<TContentModel> GetContentAsync<TContentModel, TContentfulModel>(
            Func<TContentfulModel, Task<TContentModel>> mapFunc,
            Func<IContentfulClient, Task<TContentfulModel>> cmsContentFunc,
            bool forceCMSFetch) 
            where TContentfulModel : ContentType
        {
            CacheDTO<TContentModel>? dtoContent = await GetDTOContentFromCacheAsync<TContentModel>();

            if (dtoContent is null || !dtoContent.IsValid(MAX_CACHE_AGE_IN_HOURS, _systemClock) || forceCMSFetch)
            {
                TContentfulModel cmsContent = await GetCMSContentAsync<TContentfulModel>(cmsContentFunc);

                dtoContent = await CacheDTO<TContentModel>.Create<TContentfulModel>(cmsContent, mapFunc, _systemClock);

                // Fire and forget the saving to cache
                _ = SaveDTOToCacheAsync<TContentModel>(dtoContent);
            }

            return dtoContent.ContentModel;
        }

        private async Task<CacheDTO<TContentModel>?> GetDTOContentFromCacheAsync<TContentModel>()
        {
            (bool isSucces, string dtoSerialized) = await _localStorage.TryGetAsync(typeof(TContentModel).Name);

            if (!isSucces)
                return null;

            CacheDTO<TContentModel> dtoContent = JsonConvert.DeserializeObject<CacheDTO<TContentModel>>(dtoSerialized, _contentfulClient.SerializerSettings);

            return dtoContent;
        }

        private async Task SaveDTOToCacheAsync<TContentModel>(CacheDTO<TContentModel> dtoContent)
        {
            var dtoContentSerialized = JsonConvert.SerializeObject(dtoContent, _contentfulClient.SerializerSettings);

            await _localStorage.SetAsync(typeof(TContentModel).Name, dtoContentSerialized);
        }

        private async Task<TContentfulModel> GetCMSContentAsync<TContentfulModel>(
            QueryBuilder<TContentfulModel> queryBuilder, 
            Func<ContentfulCollection<TContentfulModel>, 
                TContentfulModel> filter) 
            where TContentfulModel : ContentType
        {
            return filter.Invoke(await _contentfulClient.GetEntries<TContentfulModel>(queryBuilder));
        }

        private async Task<TContentfulModel> GetCMSContentAsync<TContentfulModel>(Func<IContentfulClient, Task<TContentfulModel>> cmsContentFunc) where TContentfulModel : ContentType
        {
            return await cmsContentFunc.Invoke(_contentfulClient);
        }

        private class CacheDTO<TContentModel>
        {
            private CacheDTO() { }

            public DateTime? UTCLastUpdated { get; set; }

            public TContentModel? ContentModel { get; set; }

            public bool IsValid(double maxCacheAgeInHours, ISystemClock _systemClock)
            {
                if(UTCLastUpdated is null ||
                    ContentModel is null ||
                    UTCLastUpdated.Value < _systemClock.UtcNow.Subtract(TimeSpan.FromHours(maxCacheAgeInHours)).DateTime)
                    return false;

                return true;
            }
                

            public async static Task<CacheDTO<TContentModel>> Create<TContentfulModel>(TContentfulModel contentfulModel, Func<TContentfulModel, Task<TContentModel>> mapFunc, ISystemClock systemClock) where TContentfulModel : ContentType
            {
                return Create(await mapFunc.Invoke(contentfulModel), systemClock);
            }

            public static CacheDTO<TContentModel> Create(TContentModel content, ISystemClock systemClock)
            {
                return new CacheDTO<TContentModel>
                {
                    UTCLastUpdated = systemClock.UtcNow.DateTime,
                    ContentModel = content
                };
            }

            
        }
    }
}
