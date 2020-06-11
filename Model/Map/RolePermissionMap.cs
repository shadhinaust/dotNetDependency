using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class RolePermissionMap: EntityTypeConfiguration<RolePermission>
    {
        public RolePermissionMap()
        {
            this.ToTable("role_permission")
                .HasKey(rolePermission => rolePermission.Id);

            this.Property(rolePermission => rolePermission.Id)
                .HasColumnName("id")
                .HasColumnType("smallint");

            this.Property(rolePermission => rolePermission.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("smallint")
                .IsRequired();

            this.Property(rolePermission => rolePermission.AccessControlId)
                .HasColumnName("access_control_id")
                .HasColumnType("smallint")
                .IsRequired();

            this.Property(rolePermission => rolePermission.Permission)
                .HasColumnName("permission")
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();

            this.Property(rolePermission => rolePermission.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();

            this.Property(rolePermission => rolePermission.DeletedBy)
                .HasColumnName("deleted_by")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            this.Property(rolePermission => rolePermission.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("datetime")
                .IsRequired();
        }

    }
}