using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Model
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [Column("name", TypeName = "nvarchar")]
        [Required, MaxLength(32)]
        [Index("idx_name", IsClustered = false, IsUnique = false)]
        public string Name { get; set; }

        [Column("email", TypeName = "nvarchar")]
        [Required, MaxLength(256)]
        [Index("idx_email", IsClustered = false, IsUnique = true)]
        public string Email { get; set; }

        [Column("password", TypeName = "nvarchar")]
        [Required, MaxLength(256)]
        public string Password { get; set; }

        [Column("reset_code", TypeName = "int")]
        public int ResetCode { get; set; }

        [Column("login_attempt", TypeName = "smallint")]
        public short LoginAttempt { get; set; }

        [Column("status", TypeName = "nvarchar")]
        [Required, MaxLength(8), DefaultValue("Inactive")]
        public string Status { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

        public virtual ICollection<LoginHistory> LoginHistories { get; set; }
    }
}