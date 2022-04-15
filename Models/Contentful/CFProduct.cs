using Contentful.Core.Models;

namespace ZwiepsHaakHoek.Models.Contentful
{
    public class CFProduct
    {
        public Asset[] Images { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
    }
}
