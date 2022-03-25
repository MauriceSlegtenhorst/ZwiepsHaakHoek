using Microsoft.JSInterop;

namespace ZwiepsHaakHoek.Services.Browser
{
    public class Browser : JSObjectReferenceGuard, IBrowser
    {
        private const string JS_BROWSER_PATH = "/javascript/browser.js";

        private IJSObjectReference _browserJSReference;

        public Browser(IJSRuntime jSRuntime) : base(jSRuntime) { }

        public async Task<string> GetLanguageName()
        {
            _browserJSReference = await EnsureJSObjectReference(_browserJSReference, JS_BROWSER_PATH);

            return await _browserJSReference.InvokeAsync<string>("getBrowserLanguage");
        }
    }
}
