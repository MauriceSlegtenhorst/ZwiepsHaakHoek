namespace ZwiepsHaakHoek.Pages
{
    public partial class Products : ABasePage, IBasePage
    {
        public void Dispose()
        {

            GC.SuppressFinalize(this);
        }

        public async Task GetPageData(bool forceCMSFetch = false)
        {

        }
    }
}
