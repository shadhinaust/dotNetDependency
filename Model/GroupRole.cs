using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Model
{
    [Table("group_role")]
    public class GroupRole
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [ForeignKey("Group")]
        [Column("group_id", TypeName = "smallint")]
        public short GroupId { get; set; }
        public virtual Group Group { get; set; }

        [ForeignKey("Role")]
        [Column("role_id", TypeName = "smallint")]
        public short RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}