using Contentful.Core;
using Contentful.Core.Models.Management;
using System.Globalization;
using ZwiepsHaakHoek.Services.Browser;
using ZwiepsHaakHoek.Services.LocalStorage;

namespace ZwiepsHaakHoek.Services.Localization
{
    public class Localization : ILocalization
    {
        private const string CULTURE_NAME_KEY = "culture-name";

        private readonly ILocalStorage _localStorage;
        private readonly IBrowser _browser;
        private readonly IContentfulClient _contentfulClient;

        private Locale _selectedCulture;
        public Locale SelectedCulture => _selectedCulture;

        private Locale[] _supportedCultures;
        public Locale[] SupportedCultures => _supportedCultures;

        public Localization(ILocalStorage localStorage, IBrowser browser, IContentfulClient contentfulClient)
        {
            _localStorage = localStorage;
            _browser = browser;
            _contentfulClient = contentfulClient;
        }

        public async Task SetCulture()
        {
            if (_supportedCultures is null)
                _supportedCultures = await GetSupportedCultures();

            (bool isValueFound, string cultureName) = await _localStorage.TryGetAsync(CULTURE_NAME_KEY);

            bool isCultureSet = isValueFound
                ? await TrySetCulture(cultureName)
                : await TrySetCulture((await _browser.GetLanguageName())[..2]);

            if (!isCultureSet)
                await TrySetCulture("nl");
        }

        public async Task<bool> TrySetCulture(string cultureName)
        {
            if (string.IsNullOrEmpty(cultureName))
                return false;

            if (_supportedCultures is null)
                _supportedCultures = await GetSupportedCultures();

            if (!IsCultureSupported(cultureName))
                return false;

            if (_selectedCulture is not null && _selectedCulture.Code[..2] == cultureName)
                return false;

            await _localStorage.SetAsync(CULTURE_NAME_KEY, cultureName);

            var culture = new CultureInfo(cultureName);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            
            _selectedCulture = _supportedCultures.First(locale => locale.Code[..2] == cultureName);

            return true;
        }

        private bool IsCultureSupported(string cultureName) => _supportedCultures.Any(local => local.Code[..2] == cultureName); //.Select(locale => locale.Code[..2]).Contains(cultureName);

        private async Task<Locale[]> GetSupportedCultures()
        {
            return (await _contentfulClient.GetLocales()).ToArray();
        }
    }
}
