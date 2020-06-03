using System.Collections.Generic;

namespace RestApi.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ResetCode { get; set; }
        public short LoginAttempt { get; set; }
        public string Status { get; set; }
        public List<Role> Roles { get; set; }
    }
}