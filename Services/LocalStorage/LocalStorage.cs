using Microsoft.JSInterop;

namespace ZwiepsHaakHoek.Services.LocalStorage
{
    public class LocalStorage : JSObjectReferenceLifetimeGuard, ILocalStorage
    {
        private const string GET_FUNCTION = "getLocalStoredValue";
        private const string SET_FUNCTION = "setLocalStoredValue";
        private const string IMPORT_FUNCTION = "import";

        private readonly IJSRuntime _jSRuntime;

        private IJSObjectReference _localStorageJSReference;

        public LocalStorage(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task<(bool, string)> TryGetAsync(string key)
        {
            string result = await GetAsync(key);

            return string.IsNullOrEmpty(result)
                ? (false, string.Empty)
                : (true, result);
        }

        public async Task SetAsync(string key, string value)
        {
            await EnsureJSObjectReferencesAreInitiated();

            await _localStorageJSReference.InvokeVoidAsync(SET_FUNCTION, key, value);
        }

        private async Task<string> GetAsync(string key)
        {
            await EnsureJSObjectReferencesAreInitiated();

            return await _localStorageJSReference.InvokeAsync<string>(GET_FUNCTION, key);
        }

        protected override async Task EnsureJSObjectReferencesAreInitiated()
        {
            if (_localStorageJSReference is null)
                _localStorageJSReference = await _jSRuntime.InvokeAsync<IJSObjectReference>(IMPORT_FUNCTION, "/javascript/local-storage.js");
        }
    }
}
