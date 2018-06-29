using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductAttributeLocalizedMap : EntityTypeConfiguration<Nop_ProductAttributeLocalized>
    {
        public Nop_ProductAttributeLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductAttributeLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Nop_ProductAttributeLocalized");
            this.Property(t => t.ProductAttributeLocalizedID).HasColumnName("ProductAttributeLocalizedID");
            this.Property(t => t.ProductAttributeID).HasColumnName("ProductAttributeID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_ProductAttributeLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_ProductAttribute)
                .WithMany(t => t.Nop_ProductAttributeLocalized)
                .HasForeignKey(d => d.ProductAttributeID);

        }
    }
}
