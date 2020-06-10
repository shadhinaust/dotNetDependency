using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("user")
                .Ignore(user => user.Groups)
                .Ignore(user => user.Roles)
                .HasKey(user => user.Id)
                .HasIndex(user => new { user.Name, user.Email })
                .IsUnique()
                .HasName("idx_name_email");

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

/*            this.HasMany(user => user.Sessions)
                .WithRequired(session => session.User)
                .HasForeignKey(session => session.UserId)
                .WillCascadeOnDelete();*/
        }
    }
}