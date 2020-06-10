using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();

        User GetOne(long id);

        User Save(User user);

        User Update(User user);

        void Delete(long id);

        List<User> GetAll(Group group);
    }
}
