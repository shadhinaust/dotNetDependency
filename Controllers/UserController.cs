using Autofac.Features.Indexed;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using RestApi.Dto;
using RestApi.Model;
using RestApi.Service;
using RestApi.Service.Facade;
using RestApi.Utils;
using System;
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

        public UserController(IUserServiceFacade userServiceFacade,
            IIndex<UserServiceType, IUserService> userService)
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
                response.Add(new UserDto() { Name = user.Name, Email = user.Email, Status = user.Status});
            });
            return Content(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("api/user/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            User user = _userService.GetUser(id);
            var json = JsonConvert.SerializeObject(_userService.GetUser(id));
            return Content(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/user")]
        public IHttpActionResult PostUser([FromBody] UserDto userDto)
        {
            // Auditor auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
            User user = new User()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Status = userDto.Status,
                UserGroups = new List<UserGroup>(),
                UserRoles = new List<UserRole>(),
                Sessions = new List<Session>(),
                LoginHistories = new List<LoginHistory>()
            };
            userDto.UserGroups.ForEach(usrGroup =>
            {
                UserGroup userGroup = new UserGroup() { GroupId = usrGroup.GroupId };
                user.UserGroups.Add(userGroup);
            });

            user = _userService.SaveUser(user);
            return Content(HttpStatusCode.OK, UserConverter.ToUserDto(user));
        }

        [HttpPut]
        [Route("api/user/{id}")]
        public IHttpActionResult PutUser(long id, [FromBody] UserDto userDto)
        {
            User user = _userService.GetUser(id);
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.Status = userDto.Status;

            user.UserGroups.ForEach(usrGroup =>
            {
                usrGroup.GroupId = userDto.UserGroups[0].GroupId;
            });

            user = _userService.UpdateUser(user);
            return Content(HttpStatusCode.OK, user);
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
            List<UserDto> users = _userServiceFacade.GetAllUsersByGroupId(groupId);
            return Content(HttpStatusCode.OK, users);
        }
    }
}
