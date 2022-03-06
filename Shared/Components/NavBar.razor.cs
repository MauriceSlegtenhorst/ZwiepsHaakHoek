using Microsoft.AspNetCore.Components;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class NavBar
    {
        private bool _collapsed;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private void OnHamburgerClick()
        {

        }

        private void OnLanguageSelected()
        {

        }
    }
}
