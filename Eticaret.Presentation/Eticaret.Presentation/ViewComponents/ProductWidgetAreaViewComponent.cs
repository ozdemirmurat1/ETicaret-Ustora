using Eticaret.Business.Services;
using Eticaret.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;//bu eklenmediğinde .OrderBy kullanılmaz.

namespace Eticaret.Presentation.ViewComponents
{
    public class ProductWidgetAreaViewComponent : ViewComponent
    {
        IProductService _productService;
        public ProductWidgetAreaViewComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke()
        {
            ProductWidgetAreaViewModel model = new ProductWidgetAreaViewModel();
            model.NewProducts = _productService.ProductWithImages().OrderByDescending(x => x.Id).Take(4).ToList();
            model.MostView = _productService.ProductWithImages().OrderByDescending(x => x.Counter).Take(4).ToList();    

            return View(model);
        }
    }
}
