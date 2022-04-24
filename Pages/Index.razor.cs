using Contentful.Core.Errors;
using ZwiepsHaakHoek.Models;
using ZwiepsHaakHoek.Models.Contentful;

namespace ZwiepsHaakHoek.Pages
{
    public partial class Index : ABasePage, IBasePage
    {
        public IndexModel IndexData { get; set; }

        public void Dispose()
        {
            Localization.LanguageChanged -= OnLanguageChanged;

            GC.SuppressFinalize(this);
        }

        public async void OnLanguageChanged(object sender, EventArgs args)
        {
            IndexData = null;

            await GetPageData(forceCMSFetch: true);

            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await GetPageData();

            Localization.LanguageChanged += OnLanguageChanged;
        }

        public async Task GetPageData(bool forceCMSFetch = false)
        {          
            try
            {
                IndexData = await ContentfulCache.GetContentAsync<IndexModel, CFIndex>(async (contentfulModel) => new IndexModel 
                {
                    Images = contentfulModel.Images.Select((asset) => new Image { Alt = asset.Title, Url = asset.File.Url}).ToArray(),
                    IntroMarkup = await HtmlRenderer.ToHtml(contentfulModel.IntroMarkup),
                    LatestProduct = new Product 
                    {
                        Images = contentfulModel.LatestProduct.Images.Select((asset) => new Image { Alt = asset.Title, Url = asset.File.Url }).ToArray(),
                        Title = contentfulModel.LatestProduct.Title,
                        ShortDescription = contentfulModel.LatestProduct.ShortDescription,
                        Description = contentfulModel.LatestProduct.Description,
                        DiscountPrice = contentfulModel.LatestProduct.DiscountPrice,
                        Price = contentfulModel.LatestProduct.Price,
                    }
                }, 
                forceCMSFetch);
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
        }
    }
}
