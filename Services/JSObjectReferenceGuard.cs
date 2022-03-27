using Microsoft.JSInterop;
using ZwiepsHaakHoek.Services.UrlService;

namespace ZwiepsHaakHoek.Services
{
    public abstract class JSObjectReferenceGuard
    {
        private const string IMPORT_FUNCTION = "import";

        private readonly IUrlService _urlService;

        protected readonly IJSRuntime JSRuntime;

        public JSObjectReferenceGuard(IJSRuntime jSRuntime, IUrlService urlService)
        {
            JSRuntime = jSRuntime;
            _urlService = urlService;
        }

        protected async Task<IJSObjectReference> EnsureJSObjectInitialized(IJSObjectReference jSObjectReference, string path)
        {
            path = _urlService.CreateUrl(path);

            if (jSObjectReference is null)
                jSObjectReference = await JSRuntime.InvokeAsync<IJSObjectReference>(IMPORT_FUNCTION, path);

            return jSObjectReference;
        }
    }
}
