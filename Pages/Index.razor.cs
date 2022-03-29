using Contentful.Core;
using Contentful.Core.Errors;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Models.Contentful;
using ZwiepsHaakHoek.Services.Interpreter;
using ZwiepsHaakHoek.Services.Localization;

namespace ZwiepsHaakHoek.Pages
{
    public partial class Index : IDisposable
    {
        [Inject]
        public IContentfulClient ContentfulClient { get; set; }

        [Inject] 
        public HtmlRenderer HtmlRenderer { get; set; }

        [Inject]
        public ILocalization Localization { get; set; }

        [Inject]
        public IInterpreter Interpreter { get; set; }

        public CFIndex CFIndex { get; set; }

        public string IntroHTML { get; set; }

        public void Dispose()
        {
            Localization.LanguageChanged -= OnLanguageChanged;

            GC.SuppressFinalize(this);
        }

        public async void OnLanguageChanged(object sender, EventArgs args)
        {
            CFIndex = null;

            await GetPageData();

            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetPageData();

            Localization.LanguageChanged += OnLanguageChanged;
        }

        private async Task GetPageData()
        {
            // Contenful: Including referenced content is only supported for the methods that return collections. Using GetEntry will not resolve your references. Meaning we have to configure QueryBuilder
            // with Limit(1)
            QueryBuilder<CFIndex> queryBuilder = QueryBuilder<CFIndex>.New.ContentTypeIs("home").LocaleIs(Localization.SelectedCulture.Locale.Code).Limit(1);
            
            try
            {
                CFIndex = (await ContentfulClient.GetEntries<CFIndex>(queryBuilder)).First();
            }
            catch (ContentfulException ex)
            {
                // TODO show error or something
                throw new NotImplementedException("TODO is not yet done", ex);
            }
            catch (ArgumentException ex)
            {
                // TODO show error or something
                throw new NotImplementedException("TODO is not yet done", ex);
            }
            catch (Exception ex)
            {
                // TODO show error or something
                throw new NotImplementedException("TODO is not yet done", ex);
            }
            
            IntroHTML = await HtmlRenderer.ToHtml(CFIndex.IntroMarkup);
        }
    }
}
