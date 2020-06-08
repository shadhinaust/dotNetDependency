using System;

namespace RestApi.Model
{
    public class UserGroup: Auditor
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public short GroupId { get; set; }
        public Group Group { get; set; }

        public UserGroup()
        {
            this.CreatedBy = this.ModifiedBy = "Dev";
            this.CreatedAt = this.ModifiedAt = DateTime.Now;
        }
    }
}