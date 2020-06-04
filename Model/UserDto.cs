using System.Collections.Generic;

namespace RestApi.Model
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public List<Role> Roles { get; set; }
    }
}