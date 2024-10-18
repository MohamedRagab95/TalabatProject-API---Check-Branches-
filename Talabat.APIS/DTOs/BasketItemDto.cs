using System.ComponentModel.DataAnnotations;

namespace Talabat.APIS.DTOs
{
    public class BasketItemDto
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Category { get; set; }
        public decimal Price { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Please Add Quantity")]
        public int Quantity { get; set; }
    }
}
