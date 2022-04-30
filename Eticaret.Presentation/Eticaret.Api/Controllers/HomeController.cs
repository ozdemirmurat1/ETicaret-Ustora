using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
