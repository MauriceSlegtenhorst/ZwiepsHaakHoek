using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Services.PopupManager;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class PopupContainer : IDisposable
    {
        [Inject]
        public IPopupManager PopupManager { get; set; }

        public void Dispose()
        {
            PopupManager.OnPopupsChanged -= PopupManager_OnPopupsChanged;

            GC.SuppressFinalize(this);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            PopupManager.OnPopupsChanged += PopupManager_OnPopupsChanged;
        }

        private void PopupManager_OnPopupsChanged(RenderFragment popupContent)
        {
            StateHasChanged();
        }
    }
}
