using System;

namespace RestApi.Model
{
    public class LoginHistory : Auditor
    {
        public long Id { get; set; }

        public DateTime AccessTime { get; set; }

        public string Status { get; set; }

        public long SessionId { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public LoginHistory()
        {
            this.CreatedBy = this.ModifiedBy = "Dev";
            this.CreatedAt = this.ModifiedAt = DateTime.Now;
        }
    }
}