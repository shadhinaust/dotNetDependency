using System;
using System.Collections.Generic;

namespace RestApi.Model
{
    public class AccessControl
    {
        public short Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string DeletedBy { get; set; }

        public DateTime DeletedAt { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }

        public Auditor Auditor { get; set; }
    }
}