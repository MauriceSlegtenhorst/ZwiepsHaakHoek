using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Services.Interpreter;

namespace ZwiepsHaakHoek.Shared.Components
{
    public partial class LoadingPageMessage
    {
        [Inject]
        public IInterpreter Interpreter { get; set; }

        [Parameter, EditorRequired]
        public string PageName { get; set; }
    }
}
