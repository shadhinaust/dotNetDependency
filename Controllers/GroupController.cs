using Autofac.Features.Indexed;
using RestApi.Context;
using RestApi.Dto;
using RestApi.Model;
using RestApi.Service;
using RestApi.Service.Facade;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class GroupController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IUserServiceFacade _userServiceFacade;

        public GroupController(IUserServiceFacade userServiceFacade,
            IIndex<UserServiceType, IUserService> userService)
        {
            this._userService = userService[UserServiceType.UserService];
            this._userServiceFacade = userServiceFacade;
        }

        [HttpGet]
        [Route("api/groups")]
        public IHttpActionResult GetUsers()
        {
            return Content(HttpStatusCode.OK, "Groups");
        }

        [HttpGet]
        [Route("api/group/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            return Content(HttpStatusCode.OK, "Group");
        }

        [HttpPost]
        [Route("api/group")]
        public IHttpActionResult PostUser([FromBody] GroupDto groupDto)
        {
            return Content(HttpStatusCode.OK, "Save");
        }

        [HttpPut]
        [Route("api/group/{id}")]
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
        [Route("api/group/{id}")]
        public IHttpActionResult DeleteUser(short id)
        {
            using (var ctx = new EntityContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var group = ctx.Group
                    .Where(grp => grp.Id == id)
                    .Include(grp => grp.UserGroups)
                    .Include(grp => grp.GroupRoles)
                    .FirstOrDefault();
                ctx.Group.Remove(group);
                ctx.SaveChanges();
            }
            return Content(HttpStatusCode.OK, "Goodby group!");
        }

        [HttpGet]
        [Route("api/group/user/{userId}/groups")]
        public IHttpActionResult GetUsers(short groupId)
        {
            return Content(HttpStatusCode.OK, "Groups");
        }
    }
}
