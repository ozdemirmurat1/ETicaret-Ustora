using Eticaret.Business.Services;// 1111
using Eticaret.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.Controllers
{
    public class ShopController : Controller
    {
        ICategoryService _categoryService;
        IProductService _productService;


        public ShopController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index(string name, int? page)
        {
            var category = _categoryService.GetCategory(name);
            var products = _productService.GetCategoryProducts(category.Id, page);

            ShopViewModel model = new()
            {
                Products = products,
                CurrentPage = page ?? 1, // ?? page null ise 1 değerini CurrentPage e ata değilse page değerini ata
                TotalPage = _productService.TotalPage(category.Id), // buuuuuuuuuuuuuu >>>>>
                CategoryName = name // kategori name 
            };

            return View(model);
        }
    }
}
