﻿using Contentful.Core;
using Contentful.Core.Models;
using Microsoft.AspNetCore.Components;
using ZwiepsHaakHoek.Services.Interpreter;
using ZwiepsHaakHoek.Services.Localization;

namespace ZwiepsHaakHoek.Pages
{
    public interface IBasePage : IComponent, IDisposable//, IHandleEvent, IHandleAfterRender
    {
        public IContentfulClient ContentfulClient { get; set; }

        public HtmlRenderer HtmlRenderer { get; set; }

        public ILocalization Localization { get; set; }

        public IInterpreter Interpreter { get; set; }
    }
}
