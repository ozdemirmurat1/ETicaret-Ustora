using Eticaret.Core.DataAccess;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities;

namespace Eticaret.DataAccess.Concrete
{
    public class UserDal : RepositoryBase<User,EticaretContext>,IUserDal
    {

    }
}
