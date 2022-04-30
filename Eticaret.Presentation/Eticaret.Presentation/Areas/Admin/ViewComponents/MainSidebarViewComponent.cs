using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.Areas.Admin.ViewComponents
{
    public class MainSidebarViewComponent : ViewComponent
    {
        public MainSidebarViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
