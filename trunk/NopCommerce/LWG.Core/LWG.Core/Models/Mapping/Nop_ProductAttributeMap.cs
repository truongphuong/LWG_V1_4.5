using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductAttributeMap : EntityTypeConfiguration<Nop_ProductAttribute>
    {
        public Nop_ProductAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductAttributeID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(400);

            // Table & Column Mappings
            this.ToTable("Nop_ProductAttribute");
            this.Property(t => t.ProductAttributeID).HasColumnName("ProductAttributeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
