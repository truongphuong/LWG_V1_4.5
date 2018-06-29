using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_LocaleStringResourceMap : EntityTypeConfiguration<Nop_LocaleStringResource>
    {
        public Nop_LocaleStringResourceMap()
        {
            // Primary Key
            this.HasKey(t => t.LocaleStringResourceID);

            // Properties
            this.Property(t => t.ResourceName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.ResourceValue)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_LocaleStringResource");
            this.Property(t => t.LocaleStringResourceID).HasColumnName("LocaleStringResourceID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.ResourceName).HasColumnName("ResourceName");
            this.Property(t => t.ResourceValue).HasColumnName("ResourceValue");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_LocaleStringResource)
                .HasForeignKey(d => d.LanguageID);

        }
    }
}
