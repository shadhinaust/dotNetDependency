using System;

namespace RestApi.Model
{
    public class GroupRole: Auditor
    {
        public long Id { get; set; }

        public short GroupId { get; set; }
        public Group Group { get; set; }

        public short RoleId { get; set; }
        public Role Role { get; set; }

        public GroupRole()
        {
            this.CreatedBy = this.ModifiedBy = "Dev";
            this.CreatedAt = this.ModifiedAt = DateTime.Now;
        }
    }
}