using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;

namespace ZwiepsHaakHoek.Services.ContentfulCache
{
    public interface IContentfulCache
    {
        public Task<TContentModel> GetContentAsync<TContentModel, TContentfulModel>(
            Func<TContentfulModel, Task<TContentModel>> mapFunc, 
            bool forceCMSFetch) 
            where TContentfulModel : ContentType;

        public Task<TContentModel> GetContentAsync<TContentModel, TContentfulModel>(
            Func<TContentfulModel, Task<TContentModel>> mapFunc, 
            QueryBuilder<TContentfulModel> queryBuilder,
            bool forceCMSFetch)
            where TContentfulModel : ContentType;

        public Task<TContentModel> GetContentAsync<TContentModel, TContentfulModel>(
            Func<TContentfulModel, Task<TContentModel>> mapFunc, 
            QueryBuilder<TContentfulModel> queryBuilder, 
            Func<ContentfulCollection<TContentfulModel>, TContentfulModel> filter,
            bool forceCMSFetch) 
            where TContentfulModel : ContentType;

        public Task<TContentModel> GetContentAsync<TContentModel, TContentfulModel>(
            Func<TContentfulModel, Task<TContentModel>> mapFunc, 
            Func<IContentfulClient, Task<TContentfulModel>> cmsContentFunc,
            bool forceCMSFetch) 
            where TContentfulModel : ContentType;
    }
}
