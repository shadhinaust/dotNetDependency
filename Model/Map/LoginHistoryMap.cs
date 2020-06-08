using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class LoginHistoryMap: EntityTypeConfiguration<LoginHistory>
    {
        public LoginHistoryMap()
        {
            this.ToTable("login_history")
                .HasKey(loginHistory => loginHistory.Id);

            this.Property(loginHistory => loginHistory.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(loginHistory => loginHistory.SessionId)
                .HasColumnName("session_id")
                .HasColumnType("bigint");

            this.Property(loginHistory => loginHistory.AccessTime)
                .HasColumnName("access_time")
                .HasColumnType("datetime")
                .IsRequired();

            this.Property(loginHistory => loginHistory.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();

            this.Property(loginHistory => loginHistory.UserId)
                .HasColumnName("user_id")
                .HasColumnType("bigint")
                .IsRequired();

            this.HasRequired<User>(user => user.User)
                .WithMany(loginHistory => loginHistory.LoginHistories)
                .HasForeignKey(loginHistory => loginHistory.UserId)
                .WillCascadeOnDelete();
        }
    }
}