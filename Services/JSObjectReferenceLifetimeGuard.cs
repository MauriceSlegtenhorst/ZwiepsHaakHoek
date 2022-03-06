namespace ZwiepsHaakHoek.Services
{
    public abstract class JSObjectReferenceLifetimeGuard
    {
        protected abstract Task EnsureJSObjectReferencesAreInitiated();
    }
}
