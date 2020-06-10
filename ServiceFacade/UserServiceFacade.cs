using Autofac.Features.Indexed;
using RestApi.Model;
using RestApi.Service;
using System.Collections.Generic;

namespace RestApi.ServiceFacade
{
    public class UserServiceFacade : IUserServiceFacade
    {
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;

        public UserServiceFacade(IIndex<UserServiceType, IUserService> userService, IGroupService groupService)
        {
            this._userService = userService[UserServiceType.UserService];
            this._groupService = groupService;
        }

        public List<User> GetAllUsersByGroupId(short id)
        {
            Group group = _groupService.GetGroup(id);
            List<User> users = _userService.GetAllUsers(group);
            return users;
        }
    }
}