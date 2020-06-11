using System;

namespace RestApi.Model
{
    public class RolePermission
    {
        public short Id { get; set; }

        public string Permission { get; set; }

        public string DeletedBy { get; set; }

        public DateTime DeletedAt { get; set; }

        public string Status { get; set; }

        public short RoleId { get; set; }
        public Role Role { get; set; }

        public short AccessControlId { get; set; }
        public AccessControl AccessControl { get; set; }

        public Auditor Auditor { get; set; }
    }
}