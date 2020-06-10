using System;

namespace RestApi.Model
{
    public class LoginHistory
    {
        public long Id { get; set; }

        public DateTime AccessTime { get; set; }

        public string Status { get; set; }

        public long SessionId { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public Auditor Auditor { get; set; }

        public LoginHistory()
        {
            this.Auditor = new Auditor() { CreatedBy = "development", CreatedAt = DateTime.Now, ModifiedBy = "development", ModifiedAt = DateTime.Now };
        }
    }
}