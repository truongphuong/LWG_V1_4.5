using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ShoppingCartItemMap : EntityTypeConfiguration<Nop_ShoppingCartItem>
    {
        public Nop_ShoppingCartItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ShoppingCartItemID);

            // Properties
            this.Property(t => t.AttributesXML)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Nop_ShoppingCartItem");
            this.Property(t => t.ShoppingCartItemID).HasColumnName("ShoppingCartItemID");
            this.Property(t => t.ShoppingCartTypeID).HasColumnName("ShoppingCartTypeID");
            this.Property(t => t.CustomerSessionGUID).HasColumnName("CustomerSessionGUID");
            this.Property(t => t.ProductVariantID).HasColumnName("ProductVariantID");
            this.Property(t => t.AttributesXML).HasColumnName("AttributesXML");
            this.Property(t => t.CustomerEnteredPrice).HasColumnName("CustomerEnteredPrice");
            this.Property(t => t.Quantity).HasColumnName("Quantity");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");

            // Relationships
            this.HasRequired(t => t.Nop_CustomerSession)
                .WithMany(t => t.Nop_ShoppingCartItem)
                .HasForeignKey(d => d.CustomerSessionGUID);
            this.HasRequired(t => t.Nop_ProductVariant)
                .WithMany(t => t.Nop_ShoppingCartItem)
                .HasForeignKey(d => d.ProductVariantID);
            this.HasRequired(t => t.Nop_ShoppingCartType)
                .WithMany(t => t.Nop_ShoppingCartItem)
                .HasForeignKey(d => d.ShoppingCartTypeID);

        }
    }
}
