using System;
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

        public long LoginAttempt { get; set; }

        public string Status { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<Session> Sessions { get; set; }

        public ICollection<LoginHistory> LoginHistories { get; set; }

        public Auditor Auditor { get; set; }

        public User()
        {
            this.Auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
        }
    }
}