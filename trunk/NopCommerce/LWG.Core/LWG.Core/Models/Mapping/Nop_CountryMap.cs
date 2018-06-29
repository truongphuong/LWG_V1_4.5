using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CountryMap : EntityTypeConfiguration<Nop_Country>
    {
        public Nop_CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.CountryID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.TwoLetterISOCode)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.ThreeLetterISOCode)
                .IsRequired()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("Nop_Country");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.AllowsRegistration).HasColumnName("AllowsRegistration");
            this.Property(t => t.AllowsBilling).HasColumnName("AllowsBilling");
            this.Property(t => t.AllowsShipping).HasColumnName("AllowsShipping");
            this.Property(t => t.TwoLetterISOCode).HasColumnName("TwoLetterISOCode");
            this.Property(t => t.ThreeLetterISOCode).HasColumnName("ThreeLetterISOCode");
            this.Property(t => t.NumericISOCode).HasColumnName("NumericISOCode");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasMany(t => t.Nop_PaymentMethod)
                .WithMany(t => t.Nop_Country)
                .Map(m =>
                    {
                        m.ToTable("Nop_PaymentMethod_RestrictedCountries");
                        m.MapLeftKey("CountryID");
                        m.MapRightKey("PaymentMethodID");
                    });

            this.HasMany(t => t.Nop_ShippingMethod)
                .WithMany(t => t.Nop_Country)
                .Map(m =>
                    {
                        m.ToTable("Nop_ShippingMethod_RestrictedCountries");
                        m.MapLeftKey("CountryID");
                        m.MapRightKey("ShippingMethodID");
                    });


        }
    }
}
