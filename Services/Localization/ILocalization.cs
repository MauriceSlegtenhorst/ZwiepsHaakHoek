using Contentful.Core.Models.Management;
using ZwiepsHaakHoek.Models;

namespace ZwiepsHaakHoek.Services.Localization
{
    public interface ILocalization
    {
        event EventHandler LanguageChanged;
        Task SetInitialCultureAsync();
        Task<bool> TrySetCultureAsync(string cultureName);
        Culture SelectedCulture { get; }
        Culture[] SupportedCultures { get; }
    }
}
