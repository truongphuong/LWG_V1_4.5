using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_CustomerRole_ProductPriceMap : EntityTypeConfiguration<Nop_CustomerRole_ProductPrice>
    {
        public Nop_CustomerRole_ProductPriceMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerRoleProductPriceID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Nop_CustomerRole_ProductPrice");
            this.Property(t => t.CustomerRoleProductPriceID).HasColumnName("CustomerRoleProductPriceID");
            this.Property(t => t.CustomerRoleID).HasColumnName("CustomerRoleID");
            this.Property(t => t.ProductVariantID).HasColumnName("ProductVariantID");
            this.Property(t => t.Price).HasColumnName("Price");

            // Relationships
            this.HasRequired(t => t.Nop_CustomerRole)
                .WithMany(t => t.Nop_CustomerRole_ProductPrice)
                .HasForeignKey(d => d.CustomerRoleID);
            this.HasRequired(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_CustomerRole_ProductPrice)
                .HasForeignKey(d => d.ProductVariantID);

        }
    }
}
