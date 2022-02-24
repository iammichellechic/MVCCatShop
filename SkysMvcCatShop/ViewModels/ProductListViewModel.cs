using System.ComponentModel.DataAnnotations;

namespace SkysMvcCatShop.ViewModels
{
    public class ProductListViewModel
    {
        public class ProductItem
        {
            public int Id { get; set; }

            public string Name { get; set; }
            public string Color { get; set; }

            public decimal Price { get; set; }

            public int PopularityPercent { get; set; }
            public DateTime Created { get; set; }
            public DateTime LastBought { get; set; }
            public string Ean13 { get; set; }

            public int CurrentPage { get; set; }
            public int PageCount { get; set; }
        }
        public List<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
