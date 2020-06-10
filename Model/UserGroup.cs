using System;

namespace RestApi.Model
{
    public class UserGroup
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public short GroupId { get; set; }
        public Group Group { get; set; }

        public Auditor Auditor { get; set; }

        public UserGroup()
        {
            this.Auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
        }
    }
}