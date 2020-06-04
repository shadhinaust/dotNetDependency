using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Model
{
    [Table("user_role")]
    public class UserRole: Auditor
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [ForeignKey("User")]
        [Column("user_id", TypeName = "bigint")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Role")]
        [Column("role_id", TypeName = "smallint")]
        public short RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}