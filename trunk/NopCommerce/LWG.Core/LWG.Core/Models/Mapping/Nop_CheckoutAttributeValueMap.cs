using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CheckoutAttributeValueMap : EntityTypeConfiguration<Nop_CheckoutAttributeValue>
    {
        public Nop_CheckoutAttributeValueMap()
        {
            // Primary Key
            this.HasKey(t => t.CheckoutAttributeValueID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Nop_CheckoutAttributeValue");
            this.Property(t => t.CheckoutAttributeValueID).HasColumnName("CheckoutAttributeValueID");
            this.Property(t => t.CheckoutAttributeID).HasColumnName("CheckoutAttributeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PriceAdjustment).HasColumnName("PriceAdjustment");
            this.Property(t => t.WeightAdjustment).HasColumnName("WeightAdjustment");
            this.Property(t => t.IsPreSelected).HasColumnName("IsPreSelected");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");

            // Relationships
            this.HasRequired(t => t.Nop_CheckoutAttribute)
                .WithMany(t => t.Nop_CheckoutAttributeValue)
                .HasForeignKey(d => d.CheckoutAttributeID);

        }
    }
}
