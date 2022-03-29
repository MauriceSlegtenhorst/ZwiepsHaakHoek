using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Shared.Components;
using ZwiepsHaakHoek.Services.UrlService;
using ZwiepsHaakHoek.Services.Interpreter;

namespace ZwiepsHaakHoek.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IInterpreter Interpreter { get; set; }

        [Inject]
        public IUrlService UrlService { get; set; }

        private NavBar.NavLink[] NavLinks() => new NavBar.NavLink[] 
        {
            new() { Url = UrlService.CreateUrl("/"), DisplayText = Interpreter["Home"] },
            new() { Url = UrlService.CreateUrl("/products"), DisplayText = Interpreter["Products"] },
            new() { Url = UrlService.CreateUrl("/contact"), DisplayText = Interpreter["Contact"] },
            new() { Url = UrlService.CreateUrl("/credits"), DisplayText = Interpreter["Credits"] },
            new() { Url = UrlService.CreateUrl("/about"), DisplayText = Interpreter["About"] }
        };
    }
}
