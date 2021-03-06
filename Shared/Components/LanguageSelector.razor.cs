using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Models.Contentful;
using ZwiepsHaakHoek.Services.Localization;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class LanguageSelector
    {
        [Inject]
        public ILocalization Localization { get; set; }

        public async Task SetLanguage(string cultureName)
        {
            bool isLanguageSet = await Localization.TrySetCultureAsync(cultureName);

            if (!isLanguageSet)
            {
                // TODO show error or do something
                return;
            }
        }

        private async Task OnLanguageClick(Culture culture)
        {
            await SetLanguage(culture.Locale.Code);
        }
    }
}
