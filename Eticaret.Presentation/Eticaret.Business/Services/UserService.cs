
using Eticaret.Business.Helpers;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eticaret.Business.Services
{
    public class UserService : IUserService
    {
        //using Eticaret.DataAccess.Abstract;
        private readonly IUserDal _userDal;
        private readonly IStringHelper _stringHelper;

        public UserService(IUserDal userDal, IStringHelper stringHelper)
        {
            _userDal = userDal;
            _stringHelper = stringHelper;
        }

        public void Add(User userData)
        {
           _userDal.Add(userData);
        }

        public User AdminLogin(string username, string password)
        {
            password = _stringHelper.ToMd5(password);
            var result = _userDal.Query(x => x.Email == username && x.Password == password && x.IsAdmin == true).FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            else
            {

                return result;
            }
        }

        public void Delete(int id)
        {
            var user = _userDal.Get(x => x.Id == id);
            user.Status = false;
            _userDal.Update(user);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(x => x.Id == userId);
        }

        public List<User> List()
        {
            return _userDal.List(x => x.Status == true);
        }

        public User Login(string username, string password)
        {
            // kullanıcının hangi tarihte başarılı login olduğunu bu kısımda if ve else arasında insert edelim 
            password = _stringHelper.ToMd5(password);
            var result =  _userDal.Query(x => x.Email == username && x.Password == password).FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            else
            {

                return result;
            }

        }

        public void Update(User userData)
        {
            _userDal.Update(userData);
        }
    }
}
