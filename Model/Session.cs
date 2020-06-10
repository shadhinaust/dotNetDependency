using System;

namespace RestApi.Model
{
    public class Session
    {
        public long Id { get; set; }

        public string Token { get; set; }

        public DateTime CreationTime { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public Auditor Auditor { get; set; }

        public Session()
        {
            this.Auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
        }
    }
}