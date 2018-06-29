using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CurrencyMap : EntityTypeConfiguration<Nop_Currency>
    {
        public Nop_CurrencyMap()
        {
            // Primary Key
            this.HasKey(t => t.CurrencyID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CurrencyCode)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.DisplayLocale)
                .HasMaxLength(50);

            this.Property(t => t.CustomFormatting)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Nop_Currency");
            this.Property(t => t.CurrencyID).HasColumnName("CurrencyID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CurrencyCode).HasColumnName("CurrencyCode");
            this.Property(t => t.DisplayLocale).HasColumnName("DisplayLocale");
            this.Property(t => t.Rate).HasColumnName("Rate");
            this.Property(t => t.CustomFormatting).HasColumnName("CustomFormatting");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
