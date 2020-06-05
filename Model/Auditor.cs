using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Model
{
    public abstract class Auditor
    {
        [Column("created_by", TypeName = "nvarchar")]
        // [Required, MaxLength(256)]
        public string CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("created_at", TypeName = "datetime")]
        // [Required]
        public DateTime CreatedAt { get; set; }

        [Column("modified_by", TypeName = "nvarchar")]
        // [Required, MaxLength(256)]
        public string ModifiedBy{ get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("modified_at", TypeName = "datetime")]
        // [Required]
        public DateTime ModifiedAt { get; set; }
    }
}