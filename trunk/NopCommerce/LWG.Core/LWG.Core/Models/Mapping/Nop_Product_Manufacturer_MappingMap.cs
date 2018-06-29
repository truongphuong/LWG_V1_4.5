using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_Product_Manufacturer_MappingMap : EntityTypeConfiguration<Nop_Product_Manufacturer_Mapping>
    {
        public Nop_Product_Manufacturer_MappingMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductManufacturerID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_Product_Manufacturer_Mapping");
            this.Property(t => t.ProductManufacturerID).HasColumnName("ProductManufacturerID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.ManufacturerID).HasColumnName("ManufacturerID");
            this.Property(t => t.IsFeaturedProduct).HasColumnName("IsFeaturedProduct");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_Manufacturer)
                .WithMany(t => t.Nop_Product_Manufacturer_Mapping)
                .HasForeignKey(d => d.ManufacturerID);
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_Product_Manufacturer_Mapping)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
