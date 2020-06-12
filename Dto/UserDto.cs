using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.Dto
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Status { get; set; }

        public ICollection<Group> Groups { get; set; }

        public List<UserGroup> UserGroups { get; set; }

        public ICollection<Session> Sessions { get; set; }

        public ICollection<LoginHistory> LoginHistories { get; set; }
    }
}