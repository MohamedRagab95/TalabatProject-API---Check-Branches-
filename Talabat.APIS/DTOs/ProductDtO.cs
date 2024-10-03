using Talabat.Core.Entities;

namespace Talabat.APIS.DTOs
{
    public class ProductDtO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }


        public int BrandId { get; set; } //FK
        public string Brand { get; set; } //Navigational Property [One]

        public int CategoryId { get; set; } //FK
        public string Category { get; set; } //Navigational Property [One]

    }
}
