using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using ZwiepsHaakHoek.Shared.ResourceFiles;
using ZwiepsHaakHoek.Shared.Components;

namespace ZwiepsHaakHoek.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IStringLocalizer<Resource> Localizer { get; set; }

        private NavBar.NavLink[] NavLinks() => new NavBar.NavLink[] 
        {
            new() { Url = "/products", DisplayText = Localizer["Products"] },
            new() { Url = "/contact", DisplayText = Localizer["Contact"] },
            new() { Url = "/credits", DisplayText = Localizer["Credits"] },
            new() { Url = "/about", DisplayText = Localizer["About"] }
        };
    }
}
