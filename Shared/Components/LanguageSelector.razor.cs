using Contentful.Core;
using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Services.Localization;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class LanguageSelector
    {
        [Inject]
        public ILocalization Localization { get; set; }

        [Inject]
        public IContentfulClient ContentfulClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task SetLanguage(string cultureName)
        {
            bool isLanguageSet = await Localization.TrySetCulture(cultureName);

            if (!isLanguageSet)
            {
                // TODO show error or do something
                return;
            }

            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }
    }
}
