using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Model
{
    [Table("user_group")]
    public class UserGroup: Auditor
    {
        [Key]
        [Column("id", TypeName = "bigint")]
        public long Id { get; set; }

        [ForeignKey("User")]
        [Column("user_id", TypeName = "bigint")]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Group")]
        [Column("group_id", TypeName = "smallint")]
        public short GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}