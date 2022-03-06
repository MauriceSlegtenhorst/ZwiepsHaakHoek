using Microsoft.AspNetCore.Components;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class Select<TOption>
    {
        [Parameter]
        public string Width { get; set; } = "100%";

        [Parameter]
        public bool IsExpanded { get; set; }

        [Parameter]
        public TOption SelectedOption { get; set; }

        [Parameter, EditorRequired]
        public TOption[] Options { get; set; }

        [Parameter]
        public EventCallback<TOption> OnOptionClickCallBack { get; set; }

        [Parameter, EditorRequired]
        public RenderFragment<TOption> OptionTemplate { get; set; }

        [Parameter]
        public RenderFragment<TOption> SelectedOptionTemplate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if(SelectedOption is null)
                SelectedOption = Options[0];

            if (SelectedOptionTemplate is null)
                SelectedOptionTemplate = OptionTemplate;

            await base.OnInitializedAsync();
        }

        private void OnSelectClick()
        {
            IsExpanded = !IsExpanded;
        }

        private async Task OnOptionClick(TOption option)
        {
            SelectedOption = option;
            IsExpanded = false;
            await OnOptionClickCallBack.InvokeAsync(option);
        }
    }
}
