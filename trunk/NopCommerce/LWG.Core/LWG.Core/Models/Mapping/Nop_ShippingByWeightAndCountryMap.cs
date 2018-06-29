using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ShippingByWeightAndCountryMap : EntityTypeConfiguration<Nop_ShippingByWeightAndCountry>
    {
        public Nop_ShippingByWeightAndCountryMap()
        {
            // Primary Key
            this.HasKey(t => t.ShippingByWeightAndCountryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_ShippingByWeightAndCountry");
            this.Property(t => t.ShippingByWeightAndCountryID).HasColumnName("ShippingByWeightAndCountryID");
            this.Property(t => t.ShippingMethodID).HasColumnName("ShippingMethodID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.From).HasColumnName("From");
            this.Property(t => t.To).HasColumnName("To");
            this.Property(t => t.UsePercentage).HasColumnName("UsePercentage");
            this.Property(t => t.ShippingChargePercentage).HasColumnName("ShippingChargePercentage");
            this.Property(t => t.ShippingChargeAmount).HasColumnName("ShippingChargeAmount");

            // Relationships
            this.HasRequired(t => t.Nop_Country)
                .WithMany(t => t.Nop_ShippingByWeightAndCountry)
                .HasForeignKey(d => d.CountryID);
            this.HasRequired(t => t.Nop_ShippingMethod)
                .WithMany(t => t.Nop_ShippingByWeightAndCountry)
                .HasForeignKey(d => d.ShippingMethodID);

        }
    }
}
