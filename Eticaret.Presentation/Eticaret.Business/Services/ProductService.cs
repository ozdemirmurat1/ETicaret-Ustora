using Eticaret.Business.Helpers;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;//1111
        private readonly IProductImageDal _productImageDal;// bunu ekledik
        
        ICacheManager _cacheManager;

        public ProductService(IProductDal productDal, ICacheManager cacheManager, ICategoryDal categoryDal, IProductImageDal productImageDal)
        {
            _productDal = productDal;
            _cacheManager = cacheManager;
            _categoryDal = categoryDal;//111
            _productImageDal = productImageDal;
        }

        public void CountUp(Product product)
        {
            product.Counter = product.Counter + 1;
            _productDal.Update(product);
        }

        public Product Get(string seoName)
        {
            return _productDal.Get(x => x.SeoName == seoName);
        }

        public Product Get(int id)
        {
            return _productDal.Get(x => x.Id == id);
        }

        public List<CategoryProductsCustomModel> GetCategoryProducts(int categoryId, int? page)
        {
            var result = _productDal.GetCategoryProduct(categoryId, page);// ürünler
            var images = _productImageDal.List();// bütün resimler
            result.ForEach(x => x.Image = images.First(i => i.ProductId == x.Id).Name);

            //foreach (var item in result)
            //{
            //    var urunresimi = images.First(x => x.ProductId == item.Id);
            //    item.Image = urunresimi.Name;
            //}
            return result;
        }

        public List<ProductImagesCustomModel> ProductWithImages()
        {
            var cacheData = _cacheManager.Get<List<ProductImagesCustomModel>>("productwithimage.all");
            if (cacheData == null)
            {
                var result = _productDal.GetProductsWithImages();
                _cacheManager.Set("productwithimage.all", result);
                return result;
            }
            else
            {
                return cacheData;
            }
            // productwithimage.all

        }

        public int TotalPage(int categoryId)
        {
            var productCount = _productDal.CategoryProductCount(categoryId);
            var modResult = productCount % 12;//25 % 12 = 1 // 12 bir sayfada görünecek ürün adeti
            if (modResult > 0)
            {
                return ((productCount - modResult) / 12) + 1;
            }
            else
            {
                return productCount / 12;
            }
        }
    }
}
