using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Utilities;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class Select<TOption>
    {
        private bool _isExpanded;
        [Parameter]
        public bool IsExpanded 
        {
            get => _isExpanded; 
            set 
            {
                _isExpanded = value;

                if (_isExpanded)
                    CssClass.Add("expanded");
                else
                    CssClass.Remove("expanded");
            }
        }

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

        [Parameter]
        public CssClass CssClass { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if(CssClass is null)
                CssClass = new CssClass("select-container");
            else
            {
                if (!CssClass.Contains("select-container"))
                    CssClass.Add("select-container");
            }

            if(SelectedOption is null)
                SelectedOption = Options[0];

            if (SelectedOptionTemplate is null)
                SelectedOptionTemplate = OptionTemplate;

            await base.OnInitializedAsync();
        }

        private void OnSelectClick() => IsExpanded = !_isExpanded;

        private async Task OnOptionClick(TOption option)
        {
            SelectedOption = option;
            IsExpanded = false;
            await OnOptionClickCallBack.InvokeAsync(option);
        }
    }
}
