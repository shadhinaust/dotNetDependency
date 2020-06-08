using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            this.ToTable("group")
                .HasKey(group => group.Id);

            this.Property(group => group.Id)
                .HasColumnName("id")
                .HasColumnType("smallint");

            this.Property(group => group.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();

            this.Property(group => group.Description)
                .HasColumnName("description")
                .HasColumnType("nvarchar")
                .HasMaxLength(128);

            this.Property(group => group.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}