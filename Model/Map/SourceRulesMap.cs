using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class SourceRulesMap: EntityTypeConfiguration<SourceRules>
    {
        public SourceRulesMap()
        {
            this.ToTable("source_rules")
                .HasKey(sourceRules => sourceRules.Id);

            this.Property(sourceRules => sourceRules.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(sourceRules => sourceRules.Rule)
                .HasColumnName("rule")
                .HasColumnType("nvarchar")
                .IsRequired();

            this.Property(sourceRules => sourceRules.MessageFormat)
                .HasColumnName("message_format")
                .HasColumnType("nvarchar")
                .IsRequired();

            this.Property(sourceRules => sourceRules.Type)
                .HasColumnName("type")
                .HasColumnType("nvarchar")
                .IsRequired();

            this.Property(sourceRules => sourceRules.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}