using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class NavBar : IDisposable
    {
        private bool expanded;
        private string navContainerCSS => expanded ? " expanded" : null;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter, EditorRequired]
        public Func<NavLink[]> NavLinks { get; set; }

        protected override Task OnInitializedAsync()
        {
            NavigationManager.LocationChanged += OnLocationChanged;
            return base.OnInitializedAsync();
        }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
            GC.SuppressFinalize(this);
        }

        private void OnHamburgerClick() => expanded = !expanded;

        private void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            expanded = false;
            StateHasChanged();
        } 

        public class NavLink
        {
            public string DisplayText { get; set; }
            public string CssClass { get; set; }
            public string Url { get; set; }
        }
    }
}
