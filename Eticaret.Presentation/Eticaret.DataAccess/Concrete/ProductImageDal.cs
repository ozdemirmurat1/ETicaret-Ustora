using Eticaret.Core.DataAccess;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities;

namespace Eticaret.DataAccess.Concrete
{
    public class ProductImageDal : RepositoryBase<ProductImage, EticaretContext>, IProductImageDal
    {
    }
}
