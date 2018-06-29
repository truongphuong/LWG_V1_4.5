using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductVariantAttributeValueLocalizedMap : EntityTypeConfiguration<Nop_ProductVariantAttributeValueLocalized>
    {
        public Nop_ProductVariantAttributeValueLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductVariantAttributeValueLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_ProductVariantAttributeValueLocalized");
            this.Property(t => t.ProductVariantAttributeValueLocalizedID).HasColumnName("ProductVariantAttributeValueLocalizedID");
            this.Property(t => t.ProductVariantAttributeValueID).HasColumnName("ProductVariantAttributeValueID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_ProductVariantAttributeValueLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_ProductVariantAttributeValue)
                .WithMany(t => t.Nop_ProductVariantAttributeValueLocalized)
                .HasForeignKey(d => d.ProductVariantAttributeValueID);

        }
    }
}
