using Contentful.Core.Models.Management;

namespace ZwiepsHaakHoek.Services.Localization
{
    public interface ILocalization
    {
        Task SetCulture();
        Task<bool> TrySetCulture(string cultureName);
        Locale SelectedCulture { get; }
        Locale[] SupportedCultures { get; }
    }
}
