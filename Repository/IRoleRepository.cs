using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Repository
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role GetOne(long id);
        Role Save(Role role);
        Role Update(Role role);
        void Delete(long id);
    }
}