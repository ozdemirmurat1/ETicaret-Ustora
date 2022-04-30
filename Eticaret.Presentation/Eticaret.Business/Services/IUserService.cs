using Eticaret.Entities;
using System.Collections.Generic;

namespace Eticaret.Business.Services
{
    public interface IUserService
    {
        User Login(string username, string password);
        User AdminLogin(string username, string password);
        User GetById(int userId);
        List<User> List();

        void Delete(int id); // soft delete yapacak
        void Add(User userData);
        void Update(User userData);
    }
}
