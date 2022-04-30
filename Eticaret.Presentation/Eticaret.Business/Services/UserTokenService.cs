using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eticaret.DataAccess.Abstract;
namespace Eticaret.Business.Services
{
    public class UserTokenService : IUserTokenService
    {
        IUserTokenDal _userTokenDal;

        public UserTokenService(IUserTokenDal userTokenDal)
        {
            _userTokenDal = userTokenDal;
        }

        public UserToken Get(string token)
        {
            var userToken = _userTokenDal.Get(x => x.TokenKey == token);
            return userToken;
        }
        public void Add(string token, int userId)
        {
            var tokenData = new UserToken()
            {
                CreateDate = DateTime.Now,
                TokenKey = token,
                Status = true,
                UserId = userId
            };
            _userTokenDal.Add(tokenData);
        }
    }
}
