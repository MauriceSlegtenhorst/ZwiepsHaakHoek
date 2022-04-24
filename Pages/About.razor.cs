namespace ZwiepsHaakHoek.Pages
{
    public partial class About : ABasePage, IBasePage
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
