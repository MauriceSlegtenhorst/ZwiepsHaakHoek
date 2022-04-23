using ZwiepsHaakHoek.Models;

namespace ZwiepsHaakHoek.Pages
{
    public partial class Index
    {
        public class IndexModel
        {
            public Image[] Images { get; set; }

            public string IntroMarkup { get; set; }

            public Product LatestProduct { get; set; }
        }
    }
}
