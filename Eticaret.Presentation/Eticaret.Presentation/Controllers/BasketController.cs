using Eticaret.Business.Helpers;
using Eticaret.Business.Services;
using Eticaret.Presentation.Helpers;
using Eticaret.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Eticaret.Presentation.Controllers
{
    public class BasketController : Controller
    {
        ICookieHelper _cookieHelper;
        IProductService _productService;
        IProductImageService _productImageService;//111

        public BasketController(ICookieHelper cookieHelper, IProductService productService, IProductImageService productImageService)
        {
            _cookieHelper = cookieHelper;
            _productService = productService;
            _productImageService = productImageService;//111
        }

        public IActionResult Index()
        {
            var guidKey = GetGuid();

            var basketDetail = BasketHelper.GetMethods.Get(guidKey);
            BasketIndexViewModel model = new();
            model.Basket = basketDetail;



            return View(model);
        }
        public JsonResult AddBasket(int quantityData, int productIdData)
        {
            string basketGuid = null;
            var basketCookieValue = _cookieHelper.Get(CookieTypes.basket, Request);
            if (basketCookieValue == null)
            {
                basketGuid = Guid.NewGuid().ToString();
                _cookieHelper.Add(CookieTypes.basket, basketGuid, DateTime.Now.AddDays(50), Response);
            }
            else
            {
                basketGuid = basketCookieValue;
            }
            var product = _productService.Get(productIdData);
            var productImages = _productImageService.GetImages(productIdData);

            BasketHelper.GetMethods.AddProduct(new BasketProduct
            {
                Image = productImages.First().Name,
                ProductId = productIdData,
                Quantity = quantityData,
                Product = product


            }, basketGuid, 0, quantityData);


            var basketDetail = BasketHelper.GetMethods.GetBasketDetails(basketGuid);

            string basketHtml = $"<a href=\"/mybasket\">Cart - <span class=\"cart-amunt\">{basketDetail.Item2}</span> <i class=\"fa fa-shopping-cart\"></i> <span class=\"product-count\">{basketDetail.Item1}</span></a>";
            return Json(basketHtml);
        }

        public JsonResult GetBasket()
        {
            string basketGuid = null;
            var basketCookieValue = _cookieHelper.Get(CookieTypes.basket, Request);
            if (basketCookieValue == null)
            {
                basketGuid = Guid.NewGuid().ToString();
                _cookieHelper.Add(CookieTypes.basket, basketGuid, DateTime.Now.AddDays(50), Response);
            }
            else
            {
                basketGuid = basketCookieValue;
            }

            var basketDetail = BasketHelper.GetMethods.GetBasketDetails(basketGuid);
            if (basketDetail == null)
            {
                return Json($"<a href=\"/mybasket\">Cart - <span class=\"cart-amunt\">0</span> <i class=\"fa fa-shopping-cart\"></i> <span class=\"product-count\">0</span></a>");
            }
            string basketHtml = $"<a href=\"/mybasket\">Cart - <span class=\"cart-amunt\">{basketDetail.Item2}</span> <i class=\"fa fa-shopping-cart\"></i> <span class=\"product-count\">{basketDetail.Item1}</span></a>";
            return Json(basketHtml);
        }

        private string GetGuid()
        {
            string basketGuid = null;
            var basketCookieValue = _cookieHelper.Get(CookieTypes.basket, Request);
            if (basketCookieValue == null)
            {
                basketGuid = Guid.NewGuid().ToString();
                _cookieHelper.Add(CookieTypes.basket, basketGuid, DateTime.Now.AddDays(50), Response);
            }
            else
            {
                basketGuid = basketCookieValue;
            }
            return basketGuid;
        }
        public IActionResult Minus(int Id)
        {
            var token = _cookieHelper.Get(CookieTypes.basket, Request);
            var products = BasketHelper.GetMethods.Get(token);
            var product = products.BasketProducts.FirstOrDefault(p => p.ProductId == Id);
            if (product.Quantity == 1)
            {
                products.BasketProducts.Remove(product);
            }
            else
            {
                product.Quantity += -1;
            }
            return Redirect("/mybasket");

        }
        public IActionResult Plus(int Id)
        {
            var token = _cookieHelper.Get(CookieTypes.basket, Request);
            var products = BasketHelper.GetMethods.Get(token);
            var product = products.BasketProducts.FirstOrDefault(p => p.ProductId == Id);

            product.Quantity += 1;

            return Redirect("/mybasket");

        }
    }
}
