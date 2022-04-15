using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Services.PopupManager;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class PopupContainer
    {
        [Inject]
        public IPopupManager PopupManager { get; set; }
    }
}
