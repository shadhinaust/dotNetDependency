using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetOne(long id);
        User Save(User user);
        User Update(User user);
        void Delete(long id);
    }
}
