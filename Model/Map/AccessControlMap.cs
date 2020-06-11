using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class AccessControlMap : EntityTypeConfiguration<AccessControl>
    {
        public AccessControlMap()
        {
            this.ToTable("access_control")
                .HasKey(accessControl => accessControl.Id);

            this.Property(accessControl => accessControl.Id)
                .HasColumnName("id")
                .HasColumnType("smallint");

            this.Property(accessControl => accessControl.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsRequired();

            this.Property(role => role.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();

            this.Property(accessControl => accessControl.DeletedBy)
                .HasColumnName("deleted_by")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            this.Property(accessControl => accessControl.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime")
                .IsRequired();

            this.HasMany<RolePermission>(accessControl => accessControl.RolePermissions)
                .WithRequired(rolePermission => rolePermission.AccessControl)
                .HasForeignKey(rolePermission => rolePermission.AccessControlId)
                .WillCascadeOnDelete();
        }
    }
}