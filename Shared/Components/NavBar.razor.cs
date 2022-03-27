using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using ZwiepsHaakHoek.Services.UrlService;
using ZwiepsHaakHoek.Utilities;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class NavBar : IDisposable
    {
        private bool _expanded;

        private readonly CssClass _cssClass = new("navbar-container");

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IUrlService UrlService { get; set; }

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

        private void OnHamburgerClick()
        {
            _expanded = !_expanded;

            if (_expanded)
                _cssClass.Add("expanded");
            else
                _cssClass.Remove("expanded");
        } 

        private void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            _expanded = false;
            _cssClass.Remove("expanded");
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
