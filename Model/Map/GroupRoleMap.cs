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
                .HasColumnType("smallint")
                .IsRequired();

            this.Property(groupRole => groupRole.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("smallint")
                .IsRequired();
        }
    }
}