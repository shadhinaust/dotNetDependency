using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Repository
{
    public interface IUserGroupRepository
    {
        // Save Methods
        UserGroup Save(UserGroup userGroup);

        // Update Methods
        UserGroup Update(UserGroup userGroup);

        // Delete Methods
        void Delete(long id);

        // ONE Methods
        UserGroup GetOne(long id);

        // List Methods
        List<UserGroup> GetAll();

        List<UserGroup> GetAll(List<long> ids);
    }
}
