using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Models;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class Polaroid
    {
        private Image _image;
        [Parameter, EditorRequired]
        public Func<Image> Image { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        public Popup FullImagePopup { get; set; }

        protected override Task OnInitializedAsync()
        {
            _image = Image.Invoke();

            return base.OnInitializedAsync();
        }
    }
}
