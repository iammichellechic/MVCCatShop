using System.ComponentModel.DataAnnotations;

namespace SkysMvcCatShop.ViewModels
{
    public class ProductNewViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Color { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Range(0, 100)]
        public int PopularityPercent { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastBought { get; set; }
        public string Ean13 { get; set; }
    }
}
