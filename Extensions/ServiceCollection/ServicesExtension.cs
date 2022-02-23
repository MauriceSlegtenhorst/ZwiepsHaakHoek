using ZwiepsHaakHoek.Services.Browser;
using ZwiepsHaakHoek.Services.Localization;
using ZwiepsHaakHoek.Services.LocalStorage;

namespace ZwiepsHaakHoek.Extensions.ServiceCollection
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration, string baseAddress)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            services.AddContentfulServices(configuration);
            services.AddLocalization();
            services.AddSingleton<IBrowser, Browser>();
            services.AddSingleton<ILocalStorage, LocalStorage>();
            services.AddSingleton<ILocalization, Localization>();
        }
    }
}
