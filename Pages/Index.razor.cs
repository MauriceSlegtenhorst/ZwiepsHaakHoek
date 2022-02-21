using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Models.Contentful;

namespace ZwiepsHaakHoek.Pages
{
    public partial class Index
    {
        [Inject]
        public IContentfulClient ContentfulClient { get; set; }

        [Inject] 
        public HtmlRenderer HtmlRenderer { get; set; }

        public CFIndex CFIndex { get; set; }

        public string IntroHTML { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetPageData();
        }

        private async Task GetPageData()
        {
            var queryBuilder = QueryBuilder<CFIndex>.New.ContentTypeIs("home");
            // Contenful: Including referenced content is only supported for the methods that return collections. Using GetEntry will not resolve your references
            CFIndex = (await ContentfulClient.GetEntries<CFIndex>(queryBuilder)).FirstOrDefault();
            IntroHTML = await HtmlRenderer.ToHtml(CFIndex.IntroMarkup);
        }
    }
}
