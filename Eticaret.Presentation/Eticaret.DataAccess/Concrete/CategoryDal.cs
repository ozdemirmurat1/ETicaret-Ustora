using Eticaret.Core.DataAccess;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities;

namespace Eticaret.DataAccess.Concrete
{
    public class CategoryDal : RepositoryBase<Category, EticaretContext>, ICategoryDal
    {
    }
}
