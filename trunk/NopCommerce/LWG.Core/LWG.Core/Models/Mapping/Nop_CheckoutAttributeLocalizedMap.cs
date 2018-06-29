using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CheckoutAttributeLocalizedMap : EntityTypeConfiguration<Nop_CheckoutAttributeLocalized>
    {
        public Nop_CheckoutAttributeLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.CheckoutAttributeLocalizedID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.TextPrompt)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Nop_CheckoutAttributeLocalized");
            this.Property(t => t.CheckoutAttributeLocalizedID).HasColumnName("CheckoutAttributeLocalizedID");
            this.Property(t => t.CheckoutAttributeID).HasColumnName("CheckoutAttributeID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TextPrompt).HasColumnName("TextPrompt");

            // Relationships
            this.HasRequired(t => t.Nop_CheckoutAttribute)
                .WithMany(t => t.Nop_CheckoutAttributeLocalized)
                .HasForeignKey(d => d.CheckoutAttributeID);
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_CheckoutAttributeLocalized)
                .HasForeignKey(d => d.LanguageID);

        }
    }
}
