using Autofac.Features.Indexed;
using RestApi.Dto;
using RestApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestApi.Service.Facade
{
    public class UserServiceFacade : IUserServiceFacade
    {
        private readonly IUserService _userService;
        private readonly IGroupService _groupService;
        private readonly IUserGroupService _userGroupService;

        public UserServiceFacade(IIndex<UserServiceType,
            IUserService> userService, IGroupService groupService,
            IUserGroupService userGroupService)
        {
            this._userService = userService[UserServiceType.UserService];
            this._groupService = groupService;
            this._userGroupService = userGroupService;
        }

        public List<UserDto> GetAllUsersByGroupId(short id)
        {
            Group group = _groupService.GetGroup(id);
            List<UserDto> users = _userService.GetAllUsers(group)
                .Select(user => new UserDto() { Name = user.Name, Email = user.Email, Status = user.Status })
                .ToList();
            return users;
        }
    }
}