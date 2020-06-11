using System;

namespace RestApi.Model
{
    public class GroupRole
    {
        public long Id { get; set; }

        public short GroupId { get; set; }
        public Group Group { get; set; }

        public short RoleId { get; set; }
        public Role Role { get; set; }

        public Auditor Auditor { get; set; }

        public GroupRole()
        {
            this.Auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
        }
    }
}