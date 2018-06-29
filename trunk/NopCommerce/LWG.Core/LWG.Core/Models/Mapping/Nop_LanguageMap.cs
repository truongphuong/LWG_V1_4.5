using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_LanguageMap : EntityTypeConfiguration<Nop_Language>
    {
        public Nop_LanguageMap()
        {
            // Primary Key
            this.HasKey(t => t.LanguageId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.LanguageCulture)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.FlagImageFileName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Nop_Language");
            this.Property(t => t.LanguageId).HasColumnName("LanguageId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LanguageCulture).HasColumnName("LanguageCulture");
            this.Property(t => t.FlagImageFileName).HasColumnName("FlagImageFileName");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
