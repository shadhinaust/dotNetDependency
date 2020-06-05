using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Model
{
    [Table("role")]
    public class Role
    {
        [Key]
        [Column("id", TypeName = "smallint")]
        public short Id { get; set; }

        [Column("name", TypeName = "nvarchar")]
        [Required, MaxLength(16)]
        public string Name { get; set; }

        [Column("description", TypeName = "nvarchar")]
        [MaxLength(128)]
        public string Description { get; set; }

        [Column("status", TypeName = "nvarchar")]
        [Required, MaxLength(8), DefaultValue("Inactive")]
        public string Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}