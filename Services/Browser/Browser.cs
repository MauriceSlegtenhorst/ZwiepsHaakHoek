using Microsoft.JSInterop;

namespace ZwiepsHaakHoek.Services.Browser
{
    public class Browser : JSObjectReferenceLifetimeGuard, IBrowser
    {
        private readonly IJSRuntime _jSRuntime;

        private IJSObjectReference _browserJSReference;

        public Browser(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task<string> GetLanguageName()
        {
            await EnsureJSObjectReferencesAreInitiated();

            return await _browserJSReference.InvokeAsync<string>("getBrowserLanguage");
        }

        protected override async Task EnsureJSObjectReferencesAreInitiated()
        {
            if (_browserJSReference is null)
                _browserJSReference = await _jSRuntime.InvokeAsync<IJSObjectReference>("import", "/javascript/browser.js");
        }
    }
}
