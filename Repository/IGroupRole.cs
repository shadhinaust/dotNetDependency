using System.Collections.Generic;

namespace RestApi.Repository
{
    interface IGroupRole
    {
        List<GroupRole> GetAll();
        GroupRole GetOne(long id);
        GroupRole Save(GroupRole groupRole);
        GroupRole Update(GroupRole groupRole);
        void Delete(long id);
    }
}
