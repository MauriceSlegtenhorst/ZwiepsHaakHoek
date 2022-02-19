using Contentful.Core;
using Contentful.Core.Models;
using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Models;

namespace ZwiepsHaakHoek.Pages
{
    public partial class Index
    {
        [Inject]
        public IContentfulClient ContentFulClient { get; set; }

        public ContentfulCollection<Product> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Products = await this.ContentFulClient.GetEntriesByType<Product>("product");
        }
    }
}
