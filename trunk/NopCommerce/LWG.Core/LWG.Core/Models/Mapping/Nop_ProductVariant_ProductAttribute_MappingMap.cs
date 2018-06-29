using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductVariant_ProductAttribute_MappingMap : EntityTypeConfiguration<Nop_ProductVariant_ProductAttribute_Mapping>
    {
        public Nop_ProductVariant_ProductAttribute_MappingMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductVariantAttributeID);

            // Properties
            this.Property(t => t.TextPrompt)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Nop_ProductVariant_ProductAttribute_Mapping");
            this.Property(t => t.ProductVariantAttributeID).HasColumnName("ProductVariantAttributeID");
            this.Property(t => t.ProductVariantID).HasColumnName("ProductVariantID");
            this.Property(t => t.ProductAttributeID).HasColumnName("ProductAttributeID");
            this.Property(t => t.TextPrompt).HasColumnName("TextPrompt");
            this.Property(t => t.IsRequired).HasColumnName("IsRequired");
            this.Property(t => t.AttributeControlTypeID).HasColumnName("AttributeControlTypeID");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_ProductAttribute)
                .WithMany(t => t.Nop_ProductVariant_ProductAttribute_Mapping)
                .HasForeignKey(d => d.ProductAttributeID);
            this.HasRequired(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_ProductVariant_ProductAttribute_Mapping)
                .HasForeignKey(d => d.ProductVariantID);

        }
    }
}
