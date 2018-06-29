using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_TaxProviderMap : EntityTypeConfiguration<Nop_TaxProvider>
    {
        public Nop_TaxProviderMap()
        {
            // Primary Key
            this.HasKey(t => t.TaxProviderID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.ConfigureTemplatePath)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.ClassName)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Nop_TaxProvider");
            this.Property(t => t.TaxProviderID).HasColumnName("TaxProviderID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ConfigureTemplatePath).HasColumnName("ConfigureTemplatePath");
            this.Property(t => t.ClassName).HasColumnName("ClassName");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
