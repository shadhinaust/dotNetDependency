using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class SpeechRulesMap : EntityTypeConfiguration<SpeechRules>
    {
        public SpeechRulesMap()
        {
            this.ToTable("speech_rules")
                .HasKey(speechRules => speechRules.Id);

            this.Property(speechRules => speechRules.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(speechRules => speechRules.Rule)
                .HasColumnName("rule")
                .HasColumnType("nvarchar")
                .IsRequired();

            this.Property(speechRules => speechRules.MessageFormat)
                .HasColumnName("message_format")
                .HasColumnType("nvarchar")
                .IsRequired();

            this.Property(speechRules => speechRules.Type)
                .HasColumnName("type")
                .HasColumnType("nvarchar")
                .IsRequired();

            this.Property(speechRules => speechRules.Status)
                .HasColumnName("status")
                .HasColumnType("nvarchar")
                .HasMaxLength(8)
                .IsRequired();
        }
    }
}