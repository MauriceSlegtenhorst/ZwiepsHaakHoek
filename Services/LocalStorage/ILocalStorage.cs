namespace ZwiepsHaakHoek.Services.LocalStorage
{
    public interface ILocalStorage
    {
        Task SetAsync(string key, string value);
        Task<(bool, string)> TryGetAsync(string key);
    }
}
