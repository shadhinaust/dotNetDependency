using Autofac;
using Autofac.Features.Indexed;
using RestApi.Models;
using RestApi.Service;
using System.Net;
using System.Web.Http;


namespace RestApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IUserService _userServiceCore;
        private readonly ILifetimeScope _scope;

        public UserController(ILifetimeScope scope, IIndex<UserServiceType, IUserService> userService)
        {
            _scope = scope;
            _userService = userService[UserServiceType.UserService];
            _userServiceCore = userService[UserServiceType.UserServiceCore];
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetRoot()
        {
            // ThreadOne();
            // ThreadTwo();
            return Content(HttpStatusCode.OK, "What is the difference between Rest and Soap");
        }

        private void ThreadOne()
        {
            using (var scope = this._scope.BeginLifetimeScope())
            {
                var userService = scope.ResolveKeyed<IUserService>(UserServiceType.UserServiceCore);
                userService.GetAllUsers();
            }
        }

        private IHttpActionResult ThreadTwo()
        {
            var scope = this._scope.BeginLifetimeScope();
            var userService = scope.Resolve<IUserService>();
            var content = userService.GetAllUsers();
            scope.Dispose();
            return Content(HttpStatusCode.OK, content);
        }


        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            return Content(HttpStatusCode.OK, _userService.GetAllUsers());
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
    }
}
