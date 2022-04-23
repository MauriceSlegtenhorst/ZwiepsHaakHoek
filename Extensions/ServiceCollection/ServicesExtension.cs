using Microsoft.Extensions.Internal;
using ZwiepsHaakHoek.Services.Browser;
using ZwiepsHaakHoek.Services.ContentfulCache;
using ZwiepsHaakHoek.Services.Interpreter;
using ZwiepsHaakHoek.Services.Localization;
using ZwiepsHaakHoek.Services.LocalStorage;
using ZwiepsHaakHoek.Services.PopupManager;
using ZwiepsHaakHoek.Services.UrlService;

namespace ZwiepsHaakHoek.Extensions.ServiceCollection
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration, string baseAddress)
        {
            services.AddContentfulServices(configuration);
            services.AddSingleton<ISystemClock, SystemClock>();
            services.AddSingleton<IPopupManager, PopupManager>();
            services.AddSingleton<IInterpreter, Interpreter>();
            services.AddSingleton<IBrowser, Browser>();
            services.AddSingleton<ILocalStorage, LocalStorage>();
            services.AddSingleton<ILocalization, Localization>();
            services.AddSingleton<IUrlService, UrlService>();
            services.AddSingleton<IContentfulCache, ContentfulCache>();
        }
    }
}
