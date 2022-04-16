using Microsoft.AspNetCore.Components;

namespace ZwiepsHaakHoek.Services.PopupManager
{
    public interface IPopupManager : ICollection<RenderFragment>
    {
        public delegate void PopupsChanged(RenderFragment popupContent);

        public event PopupsChanged OnPopupsChanged;

        public int IndexOf(RenderFragment popupContent);
    }
}
