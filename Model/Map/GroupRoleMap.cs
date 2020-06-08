using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class GroupRoleMap: EntityTypeConfiguration<GroupRole>
    {
        public GroupRoleMap()
        {
            this.ToTable("group_role")
                .HasKey(groupRole => groupRole.Id);

            this.Property(groupRole => groupRole.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(groupRole => groupRole.GroupId)
                .HasColumnName("group_id")
                .HasColumnType("smallint");

            this.HasRequired<Group>(group => group.Group)
                .WithMany(groupRole => groupRole.GroupRoles)
                .HasForeignKey(groupRole => groupRole.GroupId)
                .WillCascadeOnDelete();

            this.Property(groupRole => groupRole.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("smallint");

            this.HasRequired<Role>(role => role.Role)
                .WithMany(groupRole => groupRole.GroupRoles)
                .HasForeignKey(groupRole => groupRole.RoleId)
                .WillCascadeOnDelete();
        }
    }
}