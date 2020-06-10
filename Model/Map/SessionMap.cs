using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class SessionMap: EntityTypeConfiguration<Session>
    {
        public SessionMap()
        {
            this.ToTable("session")
                .HasKey(session => session.Id);

            this.Property(session => session.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(session => session.Token)
                .HasColumnName("token")
                .HasColumnType("nvarchar")
                .HasMaxLength(512)
                .IsRequired();

            this.Property(session => session.CreationTime)
                .HasColumnName("creation_time")
                .HasColumnType("datetime")
                .IsRequired();

            this.Property(session => session.UserId)
                .HasColumnName("user_id")
                .HasColumnType("bigint");
        }
    }
}