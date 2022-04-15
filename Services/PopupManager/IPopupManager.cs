using Microsoft.AspNetCore.Components;

namespace ZwiepsHaakHoek.Services.PopupManager
{
    public interface IPopupManager
    {
        public List<RenderFragment> Popups { get; set; }
    }
}
