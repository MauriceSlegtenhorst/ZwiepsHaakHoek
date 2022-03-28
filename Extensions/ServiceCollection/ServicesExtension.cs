using ZwiepsHaakHoek.Services.Browser;
using ZwiepsHaakHoek.Services.Localization;
using ZwiepsHaakHoek.Services.LocalStorage;
using ZwiepsHaakHoek.Services.UrlService;

namespace ZwiepsHaakHoek.Extensions.ServiceCollection
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration, string baseAddress)
        {
            // TODO maybe changing baseadres here wil help wioth github pages base url problem. Prob not
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            services.AddContentfulServices(configuration);
            services.AddLocalization();
            services.AddSingleton<IBrowser, Browser>();
            services.AddSingleton<ILocalStorage, LocalStorage>();
            services.AddSingleton<ILocalization, Localization>();
            services.AddSingleton<IUrlService, UrlService>();
        }
    }
}
