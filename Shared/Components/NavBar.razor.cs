using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using ZwiepsHaakHoek.Services.Localization;
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

        [Inject]
        public ILocalization Localization { get; set; }

        private NavLink[] _navLinks;
        [Parameter, EditorRequired]
        public Func<NavLink[]> NavLinks { get; set; }

        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
            Localization.LanguageChanged -= OnLanguageChanged;
            GC.SuppressFinalize(this);
        }

        public void OnLanguageChanged(object sender, EventArgs args)
        {
            _navLinks = NavLinks.Invoke();

            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            _navLinks = NavLinks.Invoke();

            NavigationManager.LocationChanged += OnLocationChanged;
            Localization.LanguageChanged += OnLanguageChanged;

            await base.OnInitializedAsync();
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
