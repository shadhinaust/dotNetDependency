using System.Collections.Generic;

namespace RestApi.Dto
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public List<RoleDto> Roles { get; set; }
        public List<GroupDto> Groups { get; set; }

        public UserDto()
        {
            this.Roles = new List<RoleDto>();
            this.Groups = new List<GroupDto>();
        }
    }
}