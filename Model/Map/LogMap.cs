using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class LogMap: EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("log")
                .HasKey(log => log.Id);

            this.Property(log => log.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(log => log.Type)
                .HasColumnName("type")
                .HasColumnType("nvarchar")
                .HasMaxLength(16)
                .IsRequired();

            this.Property(log => log.Level)
                .HasColumnName("level")
                .HasColumnType("nvarchar")
                .HasMaxLength(16)
                .IsRequired();

            this.Property(log => log.Message)
                .HasColumnName("message")
                .HasColumnType("nvarchar")
                .IsRequired();
        }
    }
}