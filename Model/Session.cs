using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Model
{
    [Table("session")]
    public class Session : Auditor
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [Column("token", TypeName = "nvarchar")]
        [Required, MaxLength(512)]
        public string Token { get; set; }

        [Column("creation_time", TypeName = "datetime")]
        [Required]
        public DateTime CreationTime { get; set; }

        [ForeignKey("User")]
        [Column("user_id", TypeName = "bigint")]
        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}