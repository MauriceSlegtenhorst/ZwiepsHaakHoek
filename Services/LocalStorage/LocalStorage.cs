using Microsoft.JSInterop;
using ZwiepsHaakHoek.Services.UrlService;

namespace ZwiepsHaakHoek.Services.LocalStorage
{
    public class LocalStorage : JSObjectReferenceGuard, ILocalStorage
    {
        private const string GET_FUNCTION = "getLocalStoredValue";
        private const string SET_FUNCTION = "setLocalStoredValue";
        private const string JS_LOCAL_STORAGE_PATH = "/javascript/local-storage.js";

        private IJSObjectReference _localStorageJSReference;

        public LocalStorage(IJSRuntime jSRuntime, IUrlService urlService) : base(jSRuntime, urlService) { }

        public async Task<(bool, string)> TryGetAsync(string key)
        {
            string result = await GetAsync(key);

            return string.IsNullOrEmpty(result)
                ? (false, string.Empty)
                : (true, result);
        }

        public async Task SetAsync(string key, string value)
        {
            _localStorageJSReference = await EnsureJSObjectInitialized(_localStorageJSReference, JS_LOCAL_STORAGE_PATH);

            await _localStorageJSReference.InvokeVoidAsync(SET_FUNCTION, key, value);
        }

        private async Task<string> GetAsync(string key)
        {
            _localStorageJSReference = await EnsureJSObjectInitialized(_localStorageJSReference, JS_LOCAL_STORAGE_PATH);

            return await _localStorageJSReference.InvokeAsync<string>(GET_FUNCTION, key);
        }
    }
}
