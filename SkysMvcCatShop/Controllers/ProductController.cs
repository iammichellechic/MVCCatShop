using Microsoft.AspNetCore.Mvc;
using SkysMvcCatShop.Data;
using SkysMvcCatShop.Infrastracture.Paging;
using SkysMvcCatShop.ViewModels;
using static SkysMvcCatShop.ViewModels.ProductListViewModel;

namespace SkysMvcCatShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;   
        public ProductController(ApplicationDbContext context)

        {
            _context = context;         
        }

        public IActionResult Index(int page=1)
        {
            var productList = _context.Products.GetPaged(page, 30);
            return View(productList);
        }

        [HttpPost]
        public IActionResult Edit(int productId, ProductEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _context.Products.First(p => p.Id == productId);
                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.Color = viewModel.Color;
                product.Ean13 = viewModel.Ean13;
                product.PopularityPercent = viewModel.PopularityPercent;
                product.Created = viewModel.Created;
                product.LastBought = viewModel.LastBought;

                _context.SaveChanges();
            

                //Redirect
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            //retrieving id
            var product = _context.Products.First(p => p.Id == productId);

            //mapping viewmodel to model
            var viewModel = new ProductEditViewModel();
            viewModel.Name = product.Name;
            viewModel.Price = Convert.ToInt32(product.Price);
            viewModel.Color = product.Color;
            viewModel.Ean13 = product.Ean13;
            viewModel.PopularityPercent = product.PopularityPercent;
            viewModel.Created = product.Created;
            viewModel.LastBought= product.LastBought;

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            var viewModel = new ProductNewViewModel();
           
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(ProductNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();

                product.Name = viewModel.Name;
                product.Price = viewModel.Price;
                product.Color = viewModel.Color;
                product.Ean13 = viewModel.Ean13;
                product.PopularityPercent = viewModel.PopularityPercent;
                product.Created = viewModel.Created;
                product.LastBought = viewModel.LastBought;

                _context.Products.Add(product);
                
                _context.SaveChanges();
               

                //Redirect
                return RedirectToAction("Index");
            }

        
            return View(viewModel);
        }

    }
}
