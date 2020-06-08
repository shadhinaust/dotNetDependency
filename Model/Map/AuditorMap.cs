using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class AuditorMap: EntityTypeConfiguration<Auditor>
    {
        public AuditorMap()
        {
            this.Property(auditor => auditor.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            this.Property(auditor => auditor.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

            this.Property(auditor => auditor.ModifiedBy)
                .HasColumnName("modified_by")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            this.Property(auditor => auditor.ModifiedAt)
                .HasColumnName("modified_at")
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}