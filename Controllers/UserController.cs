using Autofac.Features.Indexed;
using Microsoft.Ajax.Utilities;
using RestApi.Dto;
using RestApi.Model;
using RestApi.Service;
using RestApi.ServiceFacade;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;


namespace RestApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IUserServiceFacade _userServiceFacade;

        public UserController(IUserServiceFacade userServiceFacade, IIndex<UserServiceType, IUserService> userService)
        {
            this._userService = userService[UserServiceType.UserService];
            this._userServiceFacade = userServiceFacade;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetRoot()
        {
            return Content(HttpStatusCode.OK, "What is the difference between Rest and Soap");
        }

        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            List<UserDto> response = new List<UserDto>();
            _userService.GetAllUsers().ForEach(user =>
            {
                List<RoleDto> roles = new List<RoleDto>();
                user.Roles.ForEach(role => {
                    roles.Add(new RoleDto() { Name = role.Name, Description = role.Description, Status = role.Status });
                });

                List<GroupDto> groups = new List<GroupDto>();
                user.Groups.ForEach(group => {
                    groups.Add(new GroupDto() { Name = group.Name, Description = group.Description, Status = group.Status });
                });

                response.Add(new UserDto() { Name = user.Name, Email = user.Email, Status = user.Status, Roles = roles, Groups = groups });
            });
            return Content(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("api/user/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            return Content(HttpStatusCode.OK, _userService.GetUser(id));
        }

        [HttpPost]
        [Route("api/user")]
        public IHttpActionResult PostUser([FromBody] UserDto userDto)
        {
            return Content(HttpStatusCode.OK, _userService.SaveUser(new User() 
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Status = userDto.Status
            }));
        }

        [HttpPut]
        [Route("api/user/{id}")]
        public IHttpActionResult PutUser(long id, [FromBody] UserDto userDto)
        {
            return Content(HttpStatusCode.OK, _userService.UpdateUser(new User()
            {
                Id = id,
                Name = userDto.Name,
                Email = userDto.Email,
                Status = userDto.Status
            }));
        }

        [HttpDelete]
        [Route("api/user/{id}")]
        public IHttpActionResult DeleteUser(long id)
        {
            _userService.DeleteUser(id);
            return Content(HttpStatusCode.OK, "Goodby user!");
        }

        [HttpGet]
        [Route("api/user/group/{groupId}/users")]
        public IHttpActionResult GetUsers(short groupId)
        {
            List<UserDto> users = _userServiceFacade.GetAllUsersByGroupId(groupId)
                .Select(user => new UserDto() { Name = user.Name, Email = user.Email, Status = user.Status })
                .ToList();
            return Content(HttpStatusCode.OK, users);
        }
    }
}
