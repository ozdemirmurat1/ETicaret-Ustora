using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.ViewComponents
{
    public class SiteBrandingAreaViewComponent : ViewComponent
    {
        public SiteBrandingAreaViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            //3
            return View();
        }
    }
}
