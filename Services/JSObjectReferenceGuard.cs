using Microsoft.JSInterop;

namespace ZwiepsHaakHoek.Services
{
    public abstract class JSObjectReferenceGuard
    {
        private const string IMPORT_FUNCTION = "import";

        protected readonly IJSRuntime JSRuntime;

        public JSObjectReferenceGuard(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
        }

        protected async Task<IJSObjectReference> EnsureJSObjectReference(IJSObjectReference jSObjectReference, string path)
        {
#if !DEBUG
            path = string.Join(null, "/ZwiepsHaakHoek", path);
#endif

            if (jSObjectReference is null)
                jSObjectReference = await JSRuntime.InvokeAsync<IJSObjectReference>(IMPORT_FUNCTION, path);

            return jSObjectReference;
        }
    }
}
