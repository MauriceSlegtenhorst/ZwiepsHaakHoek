using Contentful.Core.Models;
using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Services.ContentfulCache;
using ZwiepsHaakHoek.Services.Interpreter;
using ZwiepsHaakHoek.Services.Localization;

namespace ZwiepsHaakHoek.Pages
{
    public interface IBasePage : IComponent, IDisposable
    {
        public IContentfulCache ContentfulCache { get; set; }

        public HtmlRenderer HtmlRenderer { get; set; }

        public ILocalization Localization { get; set; }

        public IInterpreter Interpreter { get; set; }
    }
}
