using Microsoft.Ajax.Utilities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Model
{
    [Table("login_history")]
    public class LoginHistory : Auditor
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [Column("access_time", TypeName = "datetime")]
        [Required]
        public DateTime AccessTime { get; set; }

        [Column("status", TypeName = "nvarchar")]
        [Required, MaxLength(8), DefaultValue("Inactive")]
        public string Status { get; set; }

        [Column("session_id", TypeName = "bigint")]
        public long SessionId { get; set; }

        [ForeignKey("User")]
        [Column("user_id", TypeName = "bigint")]
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}