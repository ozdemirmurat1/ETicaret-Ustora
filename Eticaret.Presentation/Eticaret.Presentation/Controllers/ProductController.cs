﻿using Eticaret.Business.Services;
using Eticaret.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Presentation.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        IProductImageService _productImageService;
        public ProductController(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        public IActionResult Index(string name)
        {
            var product = _productService.Get(name);
            if (product == null) return RedirectToRoute("default");

            var images = _productImageService.GetImages(product.Id);// ürün resimleri
            // return Redirect("/"); anasayfa demek RedirectToAction("Index","Home");
            ProductViewModel model = new ProductViewModel
            {
                ProductDetail = product,
                Images = images 
            };

            _productService.CountUp(product);
            return View(model);
          
        }
    }
}
