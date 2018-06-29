using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CheckoutAttributeValueLocalizedMap : EntityTypeConfiguration<Nop_CheckoutAttributeValueLocalized>
    {
        public Nop_CheckoutAttributeValueLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.CheckoutAttributeValueLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_CheckoutAttributeValueLocalized");
            this.Property(t => t.CheckoutAttributeValueLocalizedID).HasColumnName("CheckoutAttributeValueLocalizedID");
            this.Property(t => t.CheckoutAttributeValueID).HasColumnName("CheckoutAttributeValueID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.Nop_CheckoutAttributeValue)
                .WithMany(t => t.Nop_CheckoutAttributeValueLocalized)
                .HasForeignKey(d => d.CheckoutAttributeValueID);
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_CheckoutAttributeValueLocalized)
                .HasForeignKey(d => d.LanguageID);

        }
    }
}
