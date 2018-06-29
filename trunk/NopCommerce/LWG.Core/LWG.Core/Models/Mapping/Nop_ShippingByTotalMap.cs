using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ShippingByTotalMap : EntityTypeConfiguration<Nop_ShippingByTotal>
    {
        public Nop_ShippingByTotalMap()
        {
            // Primary Key
            this.HasKey(t => t.ShippingByTotalID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_ShippingByTotal");
            this.Property(t => t.ShippingByTotalID).HasColumnName("ShippingByTotalID");
            this.Property(t => t.ShippingMethodID).HasColumnName("ShippingMethodID");
            this.Property(t => t.From).HasColumnName("From");
            this.Property(t => t.To).HasColumnName("To");
            this.Property(t => t.UsePercentage).HasColumnName("UsePercentage");
            this.Property(t => t.ShippingChargePercentage).HasColumnName("ShippingChargePercentage");
            this.Property(t => t.ShippingChargeAmount).HasColumnName("ShippingChargeAmount");

            // Relationships
            this.HasRequired(t => t.Nop_ShippingMethod)
                .WithMany(t => t.Nop_ShippingByTotal)
                .HasForeignKey(d => d.ShippingMethodID);

        }
    }
}
