using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using ZwiepsHaakHoek.Shared.ResourceFiles;
using ZwiepsHaakHoek.Shared.Components;
using ZwiepsHaakHoek.Services.UrlService;

namespace ZwiepsHaakHoek.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IStringLocalizer<Resource> Localizer { get; set; }

        [Inject]
        public IUrlService UrlService { get; set; }

        private NavBar.NavLink[] NavLinks() => new NavBar.NavLink[] 
        {
            new() { Url = UrlService.CreateUrl("/products"), DisplayText = Localizer["Products"] },
            new() { Url = UrlService.CreateUrl("/contact"), DisplayText = Localizer["Contact"] },
            new() { Url = UrlService.CreateUrl("/credits"), DisplayText = Localizer["Credits"] },
            new() { Url = UrlService.CreateUrl("/about"), DisplayText = Localizer["About"] }
        };
    }
}
