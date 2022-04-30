using Eticaret.Presentation.Areas.Admin.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        IAdminChecker _adminChecker;

        public DashboardController(IAdminChecker adminChecker)
        {
            _adminChecker = adminChecker;
        }

        public IActionResult Index()
        {
            var check = _adminChecker.Check(Request);
            if (check == false)
            {
                return Redirect("/admin");
            }

            return View();
        }
    }
}
