using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Service
{
    public interface IUserGroupService
    {
        // Save Methods
        UserGroup SaveUserGroup(UserGroup userGroup);

        // Update Methods
        UserGroup UpdateUserGroup(UserGroup userGroup);

        // Delete Methods
        void DeleteUserGroup(long id);

        // One Methods
        UserGroup GetUserGroup(long id);

        // List Methods
        List<UserGroup> GetAllUserGroup();

        List<UserGroup> GetAllUserGroup(List<long> ids);



    }
}
