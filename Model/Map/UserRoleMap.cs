using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class UserRoleMap: EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.ToTable("user_role")
                .HasKey(userRole => userRole.Id);

            this.Property(userRole => userRole.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(userRole => userRole.UserId)
                .HasColumnName("user_id")
                .HasColumnType("bigint")
                .IsRequired();

            this.Property(userRole => userRole.RoleId)
                .HasColumnName("role_Id")
                .HasColumnType("smallint")
                .IsRequired();
        }
    }
}