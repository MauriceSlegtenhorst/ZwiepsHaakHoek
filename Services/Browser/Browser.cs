using Microsoft.JSInterop;
using ZwiepsHaakHoek.Services.UrlService;

namespace ZwiepsHaakHoek.Services.Browser
{
    public class Browser : JSObjectReferenceGuard, IBrowser
    {
        private const string JS_BROWSER_PATH = "/javascript/browser.js";

        private IJSObjectReference _browserJSReference;

        public Browser(IJSRuntime jSRuntime, IUrlService urlService) : base(jSRuntime, urlService) { }

        public async Task<string> GetLanguageName()
        {
            _browserJSReference = await EnsureJSObjectInitialized(_browserJSReference, JS_BROWSER_PATH);

            return await _browserJSReference.InvokeAsync<string>("getBrowserLanguage");
        }
    }
}
