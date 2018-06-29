using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CustomerAttributeMap : EntityTypeConfiguration<Nop_CustomerAttribute>
    {
        public Nop_CustomerAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerAttributeId);

            // Properties
            this.Property(t => t.Key)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Nop_CustomerAttribute");
            this.Property(t => t.CustomerAttributeId).HasColumnName("CustomerAttributeId");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.Key).HasColumnName("Key");
            this.Property(t => t.Value).HasColumnName("Value");

            // Relationships
            this.HasRequired(t => t.Nop_Customer)
                .WithMany(t => t.Nop_CustomerAttribute)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
