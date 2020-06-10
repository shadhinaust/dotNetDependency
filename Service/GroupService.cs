using RestApi.Model;
using RestApi.Repository;
using System;
using System.Collections.Generic;

namespace RestApi.Service
{
    public class GroupService : IGroupService
    {
        IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            this._groupRepository = groupRepository;
        }

        public void DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public Group GetGroup(short id)
        {
            return _groupRepository.GetOne(id);
        }

        public Group SaveGroup(User user)
        {
            throw new NotImplementedException();
        }

        public Group UpdateGroup(Group user)
        {
            throw new NotImplementedException();
        }
    }
}