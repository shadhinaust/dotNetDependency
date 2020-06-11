using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class SourceMap: EntityTypeConfiguration<Source>
    {
        public SourceMap()
        {
            this.ToTable("source")
                .HasKey(source => source.Id);

            this.Property(source => source.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(source => source.MessageId)
                .HasColumnName("message_id")
                .HasColumnType("bigint")
                .IsRequired();

            this.Property(source => source.Tag)
                .HasColumnName("tag")
                .HasColumnType("nvarchar")
                .HasMaxLength(16);

            this.Property(source => source.Data)
                .HasColumnName("data")
                .HasColumnType("nvarchar")
                .IsRequired();
        }
    }
}