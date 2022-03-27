namespace ZwiepsHaakHoek.Services.UrlService
{
    public class UrlService : IUrlService
    {
#if !DEBUG
        private const string GITHUB_PAGES_BASE_URL = "/ZwiepsHaakHoek";
#endif

        public string CreateUrl(string url)
        {
            if (url[0] is not '/')
                url = url.Prepend('/').ToString();
#if DEBUG
            return url;
#else
            return string.Join(null, GITHUB_PAGES_BASE_URL, url);
#endif
        }
    }
}
