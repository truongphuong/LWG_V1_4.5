using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_StateProvinceMap : EntityTypeConfiguration<Nop_StateProvince>
    {
        public Nop_StateProvinceMap()
        {
            // Primary Key
            this.HasKey(t => t.StateProvinceID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Abbreviation)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("Nop_StateProvince");
            this.Property(t => t.StateProvinceID).HasColumnName("StateProvinceID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_Country)
                .WithMany(t => t.Nop_StateProvince)
                .HasForeignKey(d => d.CountryID);

        }
    }
}
