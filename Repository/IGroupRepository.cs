using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Repository
{
    public interface IGroupRepository
    {
        List<Group> GetAll();

        List<Group> GetAll(List<short> ids);

        Group GetOne(short id);

        Group Save(Group group);

        Group Update(Group group);

        void Delete(short id);
    }
}