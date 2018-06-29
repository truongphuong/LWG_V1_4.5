using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CheckoutAttributeMap : EntityTypeConfiguration<Nop_CheckoutAttribute>
    {
        public Nop_CheckoutAttributeMap()
        {
            // Primary Key
            this.HasKey(t => t.CheckoutAttributeID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.TextPrompt)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Nop_CheckoutAttribute");
            this.Property(t => t.CheckoutAttributeID).HasColumnName("CheckoutAttributeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TextPrompt).HasColumnName("TextPrompt");
            this.Property(t => t.IsRequired).HasColumnName("IsRequired");
            this.Property(t => t.ShippableProductRequired).HasColumnName("ShippableProductRequired");
            this.Property(t => t.IsTaxExempt).HasColumnName("IsTaxExempt");
            this.Property(t => t.TaxCategoryID).HasColumnName("TaxCategoryID");
            this.Property(t => t.AttributeControlTypeID).HasColumnName("AttributeControlTypeID");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
        }
    }
}
