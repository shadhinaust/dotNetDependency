using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Service
{
    public interface IGroupService
    {
        Group GetGroup(short id);

        List<Group> GetAllGroups();

        Group SaveGroup(User user);

        Group UpdateGroup(Group user);

        void DeleteUser(long id);
    }
}
