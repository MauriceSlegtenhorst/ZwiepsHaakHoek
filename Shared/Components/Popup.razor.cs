using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Services.PopupManager;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class Popup
    {
        [Inject]
        public IPopupManager PopupManager { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        public void ShowPopup()
        {
            PopupManager.Add(Content);
        }

        public void HidePopup()
        {
            PopupManager.Remove(Content);
        }
    }
}
