using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductVariantLocalizedMap : EntityTypeConfiguration<Nop_ProductVariantLocalized>
    {
        public Nop_ProductVariantLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductVariantLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_ProductVariantLocalized");
            this.Property(t => t.ProductVariantLocalizedID).HasColumnName("ProductVariantLocalizedID");
            this.Property(t => t.ProductVariantID).HasColumnName("ProductVariantID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_ProductVariantLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_ProductVariantLocalized)
                .HasForeignKey(d => d.ProductVariantID);

        }
    }
}
