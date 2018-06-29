using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_MessageTemplateLocalizedMap : EntityTypeConfiguration<Nop_MessageTemplateLocalized>
    {
        public Nop_MessageTemplateLocalizedMap()
        {
            // Primary Key
            this.HasKey(t => t.MessageTemplateLocalizedID);

            // Properties
            this.Property(t => t.BCCEmailAddresses)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.Body)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_MessageTemplateLocalized");
            this.Property(t => t.MessageTemplateLocalizedID).HasColumnName("MessageTemplateLocalizedID");
            this.Property(t => t.MessageTemplateID).HasColumnName("MessageTemplateID");
            this.Property(t => t.LanguageID).HasColumnName("LanguageID");
            this.Property(t => t.BCCEmailAddresses).HasColumnName("BCCEmailAddresses");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.Nop_Language)
                .WithMany(t => t.Nop_MessageTemplateLocalized)
                .HasForeignKey(d => d.LanguageID);
            this.HasRequired(t => t.Nop_MessageTemplate)
                .WithMany(t => t.Nop_MessageTemplateLocalized)
                .HasForeignKey(d => d.MessageTemplateID);

        }
    }
}
