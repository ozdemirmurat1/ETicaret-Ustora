using Eticaret.Business.Helpers;
using Eticaret.Business.Services;
using Eticaret.Presentation.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Eticaret.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICookieHelper _cookieHelper;
        private readonly IUserService _userService;
        private readonly IUserTokenService _userTokenService;

        public HomeController(ICookieHelper cookieHelper, IUserService userService, IUserTokenService userTokenService)
        {
            _cookieHelper = cookieHelper;
            _userService = userService;
            _userTokenService = userTokenService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var login = _userService.AdminLogin(model.Email, model.Password);
                if (login == null)
                {
                    ModelState.AddModelError("LoginError", "Giriş Başarısız.");
                }
                else
                {
                    string guid = Guid.NewGuid().ToString();
                    _cookieHelper.Add(CookieTypes.admin, guid, DateTime.Now.AddDays(10), Response);
                    _userTokenService.Add(guid, login.Id);
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                // bu model bir şekilde hatalı
            }
            return View();
        }
    }
}
