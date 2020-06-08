using System.Collections.Generic;

namespace RestApi.Repository
{
    interface IUserGroup
    {
        List<UserGroup> GetAll();
        UserGroup GetOne(long id);
        UserGroup Save(UserGroup userGroup);
        UserGroup Update(UserGroup userGroup);
        void Delete(long id);
    }
}
