using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ShippingByWeightMap : EntityTypeConfiguration<Nop_ShippingByWeight>
    {
        public Nop_ShippingByWeightMap()
        {
            // Primary Key
            this.HasKey(t => t.ShippingByWeightID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_ShippingByWeight");
            this.Property(t => t.ShippingByWeightID).HasColumnName("ShippingByWeightID");
            this.Property(t => t.ShippingMethodID).HasColumnName("ShippingMethodID");
            this.Property(t => t.From).HasColumnName("From");
            this.Property(t => t.To).HasColumnName("To");
            this.Property(t => t.UsePercentage).HasColumnName("UsePercentage");
            this.Property(t => t.ShippingChargePercentage).HasColumnName("ShippingChargePercentage");
            this.Property(t => t.ShippingChargeAmount).HasColumnName("ShippingChargeAmount");

            // Relationships
            this.HasRequired(t => t.Nop_ShippingMethod)
                .WithMany(t => t.Nop_ShippingByWeight)
                .HasForeignKey(d => d.ShippingMethodID);

        }
    }
}
