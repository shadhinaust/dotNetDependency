using RestApi.Model;
using RestApi.Repository;
using System;
using System.Collections.Generic;

namespace RestApi.Service
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupService(IUserGroupRepository userGroupRepository)
        {
            this._userGroupRepository = userGroupRepository;
        }

        public void DeleteUserGroup(long id)
        {
            throw new NotImplementedException();
        }

        public List<UserGroup> GetAllUserGroup()
        {
            throw new NotImplementedException();
        }

        public List<UserGroup> GetAllUserGroup(List<long> ids)
        {
            throw new NotImplementedException();
        }

        public UserGroup GetUserGroup(long id)
        {
            throw new NotImplementedException();
        }

        public UserGroup SaveUserGroup(UserGroup userGroup)
        {
            return _userGroupRepository.Save(userGroup);
        }

        public UserGroup UpdateUserGroup(UserGroup userGroup)
        {
            throw new NotImplementedException();
        }
    }
}