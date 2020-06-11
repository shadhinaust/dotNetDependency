using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class RoleMap: EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.ToTable("role")
               .HasKey(role => role.Id);

            this.Property(role => role.Id)
                .HasColumnName("id")
                .HasColumnType("smallint");

            this.Property(role => role.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();

            this.Property(role => role.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar")
                .HasMaxLength(128);

            this.Property(role => role.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();

            this.HasMany<UserRole>(role => role.UserRoles)
                .WithRequired(userRole => userRole.Role)
                .HasForeignKey(userRole => userRole.RoleId)
                .WillCascadeOnDelete();

            this.HasMany<GroupRole>(role => role.GroupRoles)
                .WithRequired(groupRole => groupRole.Role)
                .HasForeignKey(groupRole => groupRole.RoleId)
                .WillCascadeOnDelete();

            this.HasMany<RolePermission>(role => role.RolePermissions)
                .WithRequired(rolePermission => rolePermission.Role)
                .HasForeignKey(rolePermission => rolePermission.RoleId)
                .WillCascadeOnDelete();
        }
    }
}