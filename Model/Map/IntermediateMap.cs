using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class IntermediateMap: EntityTypeConfiguration<Intermediate>
    {
        public IntermediateMap()
        {
            this.ToTable("intermediate")
                .HasKey(intermediate => intermediate.Id);

            this.Property(intermediate => intermediate.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(intermediate => intermediate.MessageId)
                .HasColumnName("message_id")
                .HasColumnType("bigint")
                .IsRequired();

            this.Property(intermediate => intermediate.Tag)
                .HasColumnName("tag")
                .HasColumnType("nvarchar")
                .HasMaxLength(16);

            this.Property(intermediate => intermediate.Data)
                .HasColumnName("data")
                .HasColumnType("nvarchar")
                .IsRequired();

            this.HasRequired<Source>(intermediate => intermediate.Source)
                .WithRequiredPrincipal(source => source.Intermediate)
                .WillCascadeOnDelete();
        }
    }
}