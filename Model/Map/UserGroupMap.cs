using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class UserGroupMap: EntityTypeConfiguration<UserGroup>
    {
        public UserGroupMap()
        {
            this.ToTable("user_group")
                .HasKey(userGroup => userGroup.Id);

            this.Property(userGroup => userGroup.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(userGroup => userGroup.UserId)
                .HasColumnName("user_id")
                .HasColumnType("bigint")
                .IsRequired();

            this.Property(userGroup => userGroup.GroupId)
                .HasColumnName("group_Id")
                .HasColumnType("smallint")
                .IsRequired();
        }
    }
}