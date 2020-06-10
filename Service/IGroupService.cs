using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Service
{
    public interface IGroupService
    {
        Group GetGroup(short id);

        List<Group> GetAllGroups();

        List<Group> GetAllGroups(List<short> ids);

        Group SaveGroup(User user);

        Group UpdateGroup(Group user);

        void DeleteUser(long id);
    }
}
