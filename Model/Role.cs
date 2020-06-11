using System;
using System.Collections.Generic;

namespace RestApi.Model
{
    public class Role
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }

        public ICollection<GroupRole> GroupRoles { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }

        public Auditor Auditor { get; set; }

        public Role()
        {
            this.Auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
        }
    }
}