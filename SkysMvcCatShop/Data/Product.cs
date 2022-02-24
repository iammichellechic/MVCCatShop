using System.ComponentModel.DataAnnotations;

namespace SkysMvcCatShop.Data;

public class Product
{
    public int Id { get; set; }
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