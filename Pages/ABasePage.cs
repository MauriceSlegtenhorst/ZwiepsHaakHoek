using Contentful.Core.Models;
using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Services.ContentfulCache;
using ZwiepsHaakHoek.Services.Interpreter;
using ZwiepsHaakHoek.Services.Localization;

namespace ZwiepsHaakHoek.Pages
{
    public abstract class ABasePage : ComponentBase
    {
        [Inject]
        public IContentfulCache ContentfulCache { get; set; }

        [Inject]
        public HtmlRenderer HtmlRenderer { get; set; }

        [Inject]
        public ILocalization Localization { get; set; }

        [Inject]
        public IInterpreter Interpreter { get; set; }
    }
}
