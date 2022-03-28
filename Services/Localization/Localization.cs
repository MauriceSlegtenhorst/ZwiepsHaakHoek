using Contentful.Core;
using Contentful.Core.Errors;
using Contentful.Core.Models.Management;
using Contentful.Core.Search;
using System.Globalization;
using ZwiepsHaakHoek.Contentful;
using ZwiepsHaakHoek.Models;
using ZwiepsHaakHoek.Models.Contentful;
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

        private bool _isInitialSetup = true;

        public event EventHandler LanguageChanged;

        private Culture _selectedCulture;
        public Culture SelectedCulture => _selectedCulture;

        private Culture[] _supportedCultures;
        public Culture[] SupportedCultures => _supportedCultures;

        public Localization(ILocalStorage localStorage, IBrowser browser, IContentfulClient contentfulClient)
        {
            _localStorage = localStorage;
            _browser = browser;
            _contentfulClient = contentfulClient;
        }

        public async Task SetInitialCultureAsync()
        {
            if (_supportedCultures is null)
                _supportedCultures = await GetSupportedCulturesAsync();

            (bool isValueFound, string cultureName) = await _localStorage.TryGetAsync(CULTURE_NAME_KEY);

            bool isCultureSet = isValueFound
                ? await TrySetCultureAsync(cultureName)
                : await TrySetCultureAsync((await _browser.GetLanguageName())[..2]);

            if (!isCultureSet)
                await TrySetCultureAsync("nl");

            _isInitialSetup = false;
        }

        public async Task<bool> TrySetCultureAsync(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode))
                return false;

            languageCode = languageCode[..2];

            if (!IsCultureSupported(languageCode))
                return false;

            if (_selectedCulture is not null && _selectedCulture.Locale.Code[..2] == languageCode)
                return false;

            await _localStorage.SetAsync(CULTURE_NAME_KEY, languageCode);

            var culture = new CultureInfo(languageCode);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            
            _selectedCulture = _supportedCultures.First(culture => culture.Locale.Code[..2] == languageCode);

            if(!_isInitialSetup)
                LanguageChanged?.Invoke(this, EventArgs.Empty);

            return true;
        }

        private bool IsCultureSupported(string languageCode) => _supportedCultures.Any(culture => culture.Locale.Code[..2] == languageCode);

        private async Task<Culture[]> GetSupportedCulturesAsync()
        {
            Culture[] supportedCultures;
            Locale[] locales;
            CFLanguageIcon[] cFLanguageIcons;

            try
            {
                locales = (await _contentfulClient.GetLocales()).ToArray();
                QueryBuilder<CFLanguageIcon> builder = QueryBuilder<CFLanguageIcon>.New.ContentTypeIs(ContentfulContentTypes.LANGUAGE_ICON);
                cFLanguageIcons = (await _contentfulClient.GetEntries<CFLanguageIcon>(builder)).ToArray();
            }
            catch (ContentfulException ex)
            {
                // TODO show error or something
                throw new NotImplementedException("TODO is not yet done", ex);
            }
            catch (ArgumentNullException ex)
            {
                // TODO show error or something
                throw new NotImplementedException("TODO is not yet done", ex);
            }
            catch (Exception ex)
            {
                // TODO show error or something
                throw new NotImplementedException("TODO is not yet done", ex);
            }

            supportedCultures = new Culture[locales.Length];
            for (int i = 0; i < supportedCultures.Length; i++)
            {
                supportedCultures[i] = new Culture
                {
                    LanguageIcon = cFLanguageIcons.FirstOrDefault(li => li.LanguageCode == locales[i].Code)?.LanguageIcon,
                    Locale = locales[i]
                };
            }

            return supportedCultures;
        }
    }
}
