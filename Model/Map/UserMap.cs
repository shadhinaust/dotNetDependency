using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("user")
                .HasKey(user => user.Id)
                .Ignore(user => user.Groups)
                .Ignore(user => user.Roles);

            this.Property(user => user.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(user => user.Name)
                .HasColumnName("name")
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsRequired();

            this.Property(user => user.Email)
                .HasColumnName("email")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            this.Property(user => user.Password)
                .HasColumnName("password")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            this.Property(user => user.ResetCode)
                .HasColumnName("reset_code")
                .HasColumnType("int");

            this.Property(user => user.LoginAttempt)
                .HasColumnName("login_attempt")
                .HasColumnType("bigint");

            this.Property(user => user.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}