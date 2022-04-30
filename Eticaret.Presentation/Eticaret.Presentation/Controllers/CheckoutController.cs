using Eticaret.Business.Helpers;
using Eticaret.Business.Services;
using Eticaret.Entities;
using Eticaret.Presentation.Helpers;
using Eticaret.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Eticaret.Presentation.Controllers
{
    public class CheckoutController : Controller
    {
        IOrderService _orderService;
        ICookieHelper _cookieHelper;

        public CheckoutController(IOrderService orderService, ICookieHelper cookieHelper)
        {
            _orderService = orderService;
            _cookieHelper = cookieHelper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CheckoutViewModel model)
        {
            if (model == null)
            {
                return RedirectToAction("Home", "Index");

            }
            if (ModelState.IsValid)
            {
                Order ord = new Order();
                ord.Address = model.Address;
                ord.City = Convert.ToInt32(model.City);
                ord.Date = DateTime.Now;
                ord.FirstName = model.FirstName;    
                ord.LastName = model.LastName;
                ord.Phone = model.Phone;
                var token = _cookieHelper.Get(CookieTypes.basket, Request);
                var basket = BasketHelper.GetMethods.Get(token);
                var orderJson = Newtonsoft.Json.JsonConvert.SerializeObject(basket);

                ord.OrderDetail = orderJson;// json db ye gönderildi.
                //Json
                _orderService.Add(ord);
                return RedirectToAction("Checkout", "OrderOk");
            }
            return View();
        }
    }
}
