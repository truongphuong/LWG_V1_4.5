using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ShippingMethodMap : EntityTypeConfiguration<Nop_ShippingMethod>
    {
        public Nop_ShippingMethodMap()
        {
            // Primary Key
            this.HasKey(t => t.ShippingMethodID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(2000);

            // Table & Column Mappings
            this.ToTable("Nop_ShippingMethod");
            this.Property(t => t.ShippingMethodID).HasColumnName("ShippingMethodID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
