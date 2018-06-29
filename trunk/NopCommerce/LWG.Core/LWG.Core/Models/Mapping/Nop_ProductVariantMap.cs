using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace LWG.Core.Models.Mapping
{
    public class Nop_ProductVariantMap : EntityTypeConfiguration<Nop_ProductVariant>
    {
        public Nop_ProductVariantMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductVariantId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(400);

            this.Property(t => t.SKU)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.AdminComment)
                .IsRequired()
                .HasMaxLength(4000);

            this.Property(t => t.ManufacturerPartNumber)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.UserAgreementText)
                .IsRequired();

            this.Property(t => t.ISBN)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Nop_ProductVariant");
            this.Property(t => t.ProductVariantId).HasColumnName("ProductVariantId");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SKU).HasColumnName("SKU");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AdminComment).HasColumnName("AdminComment");
            this.Property(t => t.ManufacturerPartNumber).HasColumnName("ManufacturerPartNumber");
            this.Property(t => t.IsGiftCard).HasColumnName("IsGiftCard");
            this.Property(t => t.IsDownload).HasColumnName("IsDownload");
            this.Property(t => t.DownloadID).HasColumnName("DownloadID");
            this.Property(t => t.UnlimitedDownloads).HasColumnName("UnlimitedDownloads");
            this.Property(t => t.MaxNumberOfDownloads).HasColumnName("MaxNumberOfDownloads");
            this.Property(t => t.DownloadExpirationDays).HasColumnName("DownloadExpirationDays");
            this.Property(t => t.DownloadActivationType).HasColumnName("DownloadActivationType");
            this.Property(t => t.HasSampleDownload).HasColumnName("HasSampleDownload");
            this.Property(t => t.SampleDownloadID).HasColumnName("SampleDownloadID");
            this.Property(t => t.HasUserAgreement).HasColumnName("HasUserAgreement");
            this.Property(t => t.UserAgreementText).HasColumnName("UserAgreementText");
            this.Property(t => t.IsRecurring).HasColumnName("IsRecurring");
            this.Property(t => t.CycleLength).HasColumnName("CycleLength");
            this.Property(t => t.CyclePeriod).HasColumnName("CyclePeriod");
            this.Property(t => t.TotalCycles).HasColumnName("TotalCycles");
            this.Property(t => t.IsShipEnabled).HasColumnName("IsShipEnabled");
            this.Property(t => t.IsFreeShipping).HasColumnName("IsFreeShipping");
            this.Property(t => t.AdditionalShippingCharge).HasColumnName("AdditionalShippingCharge");
            this.Property(t => t.IsTaxExempt).HasColumnName("IsTaxExempt");
            this.Property(t => t.TaxCategoryID).HasColumnName("TaxCategoryID");
            this.Property(t => t.ManageInventory).HasColumnName("ManageInventory");
            this.Property(t => t.StockQuantity).HasColumnName("StockQuantity");
            this.Property(t => t.DisplayStockAvailability).HasColumnName("DisplayStockAvailability");
            this.Property(t => t.MinStockQuantity).HasColumnName("MinStockQuantity");
            this.Property(t => t.LowStockActivityID).HasColumnName("LowStockActivityID");
            this.Property(t => t.NotifyAdminForQuantityBelow).HasColumnName("NotifyAdminForQuantityBelow");
            this.Property(t => t.AllowOutOfStockOrders).HasColumnName("AllowOutOfStockOrders");
            this.Property(t => t.OrderMinimumQuantity).HasColumnName("OrderMinimumQuantity");
            this.Property(t => t.OrderMaximumQuantity).HasColumnName("OrderMaximumQuantity");
            this.Property(t => t.WarehouseID).HasColumnName("WarehouseID");
            this.Property(t => t.DisableBuyButton).HasColumnName("DisableBuyButton");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.OldPrice).HasColumnName("OldPrice");
            this.Property(t => t.ProductCost).HasColumnName("ProductCost");
            this.Property(t => t.CustomerEntersPrice).HasColumnName("CustomerEntersPrice");
            this.Property(t => t.MinimumCustomerEnteredPrice).HasColumnName("MinimumCustomerEnteredPrice");
            this.Property(t => t.MaximumCustomerEnteredPrice).HasColumnName("MaximumCustomerEnteredPrice");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.PictureID).HasColumnName("PictureID");
            this.Property(t => t.AvailableStartDateTime).HasColumnName("AvailableStartDateTime");
            this.Property(t => t.AvailableEndDateTime).HasColumnName("AvailableEndDateTime");
            this.Property(t => t.Published).HasColumnName("Published");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.CreatedOn).HasColumnName("CreatedOn");
            this.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn");
            this.Property(t => t.ISBN).HasColumnName("ISBN");

            // Relationships
            this.HasRequired(t => t.Nop_LowStockActivity)
                .WithMany(t => t.Nop_ProductVariant)
                .HasForeignKey(d => d.LowStockActivityID);
            this.HasRequired(t => t.Nop_Product)
                .WithMany(t => t.Nop_ProductVariant)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
