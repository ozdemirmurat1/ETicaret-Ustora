using Eticaret.Entities;
using System.Collections.Generic;

namespace Eticaret.Business.Services
{
    public interface IProductImageService
    {
        List<ProductImage> GetImages(int productId);
    }
}
