using Contentful.Core.Models;

namespace ZwiepsHaakHoek.Models.Contentful
{
    public class CFProduct
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Asset[] Images { get; set; }
        public decimal Price { get; set; }
    }
}
