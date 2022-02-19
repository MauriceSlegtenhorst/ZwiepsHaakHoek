using Contentful.Core.Models;
using Newtonsoft.Json.Linq;

namespace ZwiepsHaakHoek.Models
{
    public class Product
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Asset[] Image { get; set; }
        public decimal Price { get; set; }
    }
}
