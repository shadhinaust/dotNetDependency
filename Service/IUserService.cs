using RestApi.Model;
using System.Collections.Generic;

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
