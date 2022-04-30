using Eticaret.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.ViewComponents
{
    public class MainContentAreaViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public MainContentAreaViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productService.ProductWithImages();

            return View(products);
        }
    }
}
