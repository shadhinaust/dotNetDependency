using System;

namespace RestApi.Model
{
    public class Session : Auditor
    {
        public long Id { get; set; }

        public string Token { get; set; }

        public DateTime CreationTime { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public Session()
        {
            this.CreatedBy = this.ModifiedBy = "Dev";
            this.CreatedAt = this.ModifiedAt = DateTime.Now;
        }
    }
}