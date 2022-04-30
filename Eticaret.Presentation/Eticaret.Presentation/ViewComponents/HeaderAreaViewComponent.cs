using Eticaret.Business.Helpers;
using Eticaret.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.ViewComponents
{
    public class HeaderAreaViewComponent : ViewComponent // eklenmeli
    {
        private readonly IUserService _userService;
        private readonly IUserTokenService _userTokenService;
        private readonly ICookieHelper _cookieHelper;
        public HeaderAreaViewComponent(IUserService userService, IUserTokenService userTokenService, ICookieHelper cookieHelper)
        {
            _userService = userService;
            _userTokenService = userTokenService;
            _cookieHelper = cookieHelper;
        }
        public IViewComponentResult Invoke() // Invoke standart ad
        {
            //2
            var cookie = _cookieHelper.Get(CookieTypes.user,Request);
            
            var tokenDetail = _userTokenService.Get(cookie);

            if (cookie == null || tokenDetail == null)
            {
                ViewData["email"] = null;
            }
            else
            {
                ViewData["email"] = _userService.GetById(tokenDetail.UserId).Email;
            }
           

            return View();
        }
    }
}
