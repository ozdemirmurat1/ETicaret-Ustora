using Eticaret.DataAccess.Abstract;
using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Business.Services
{
    public class ProductImageService : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageService(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public List<ProductImage> GetImages(int productId)
        {
            return _productImageDal.List(x => x.ProductId == productId).OrderBy(s => s.Sort).ToList();
        }
    }
}
