using System.Data.Entity.ModelConfiguration;

namespace RestApi.Model.Map
{
    public class DecipheredMap: EntityTypeConfiguration<Deciphered>
    {
        public DecipheredMap()
        {
            this.ToTable("deciphered")
                .HasKey(deciphered => deciphered.Id);

            this.Property(deciphered => deciphered.Id)
                .HasColumnName("id")
                .HasColumnType("bigint");

            this.Property(deciphered => deciphered.MessageId)
                .HasColumnName("message_id")
                .HasColumnType("bigint")
                .IsRequired();

            this.Property(deciphered => deciphered.Tag)
                .HasColumnName("tag")
                .HasColumnType("nvarchar")
                .HasMaxLength(16);

            this.Property(deciphered => deciphered.Data)
                .HasColumnName("data")
                .HasColumnType("nvarchar")
                .IsRequired();

            this.HasRequired<Intermediate>(deciphered => deciphered.Intermediate)
                .WithRequiredPrincipal(intermediate => intermediate.Deciphered)
                .WillCascadeOnDelete();
        }
    }
}