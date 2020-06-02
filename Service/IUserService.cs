using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Service
{
    public interface IUserService
    {
        User GetUser(long id);
        List<User> GetAllUsers();
        User SaveUser(User user);
        User UpdateUser(User user);
        void DeleteUser(long id);
    }
}
