namespace ZwiepsHaakHoek.Models
{
    public class Product
    {
        public Image[] Images { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPrice { get; set; }
    }
}
