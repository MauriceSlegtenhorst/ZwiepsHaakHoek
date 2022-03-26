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
            new() 
            {
#if DEBUG
                Url = "/products",
#else
                Url = "/ZwiepsHaakHoek/products",
#endif
                DisplayText = Localizer["Products"] 
            },
            new() 
            { 
#if DEBUG
                Url = "/contact", 
#else
                Url = "/ZwiepsHaakHoek/contact",
#endif
                DisplayText = Localizer["Contact"] 
            },
            new() 
            {
#if DEBUG
                Url = "/credis", 
#else
                Url = "/ZwiepsHaakHoek/credits",
#endif
                DisplayText = Localizer["Credits"] 
            },
            new() 
            { 
#if DEBUG
                Url = "/about", 
#else
                Url = "/ZwiepsHaakHoek/about",
#endif
                DisplayText = Localizer["About"] 
            }
        };
    }
}
