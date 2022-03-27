using Microsoft.AspNetCore.Components;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class NavBar
    {
        private bool _expanded;
        private string _navContainerCSS => _expanded ? " expanded" : null;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter, EditorRequired]
        public Func<NavLink[]> NavLinks { get; set; }

        private void OnHamburgerClick() => _expanded = !_expanded;

        public class NavLink
        {
            public string DisplayText { get; set; }
            public string CssClass { get; set; }
            public string Url { get; set; }
        }
    }
}
