using Eticaret.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.ViewComponents
{
    public class MainMenuAreaViewComponent : ViewComponent
    {
        ICategoryService _categoryService;
        public MainMenuAreaViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            //4
            var result = _categoryService.List();

            return View(result);
        }
    }
}
