using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_TaxRateMap : EntityTypeConfiguration<Nop_TaxRate>
    {
        public Nop_TaxRateMap()
        {
            // Primary Key
            this.HasKey(t => t.TaxRateID);

            // Properties
            this.Property(t => t.Zip)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Nop_TaxRate");
            this.Property(t => t.TaxRateID).HasColumnName("TaxRateID");
            this.Property(t => t.TaxCategoryID).HasColumnName("TaxCategoryID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.StateProvinceID).HasColumnName("StateProvinceID");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.Percentage).HasColumnName("Percentage");

            // Relationships
            this.HasRequired(t => t.Nop_Country)
                .WithMany(t => t.Nop_TaxRate)
                .HasForeignKey(d => d.CountryID);
            this.HasRequired(t => t.Nop_TaxCategory)
                .WithMany(t => t.Nop_TaxRate)
                .HasForeignKey(d => d.TaxCategoryID);

        }
    }
}
