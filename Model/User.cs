using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RestApi.Model
{
    [JsonObject(IsReference = true)]
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int ResetCode { get; set; }

        public long LoginAttempt { get; set; }

        public string Status { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

        public virtual ICollection<LoginHistory> LoginHistories { get; set; }

        public Auditor Auditor { get; set; }

        public User()
        {
            this.Auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
        }
    }
}