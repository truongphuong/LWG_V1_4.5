using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductVariant
    {
        public Nop_ProductVariant()
        {
            this.Nop_CustomerRole_ProductPrice = new List<Nop_CustomerRole_ProductPrice>();
            this.Nop_OrderProductVariant = new List<Nop_OrderProductVariant>();
            this.Nop_ProductVariant_Pricelist_Mapping = new List<Nop_ProductVariant_Pricelist_Mapping>();
            this.Nop_ProductVariant_ProductAttribute_Mapping = new List<Nop_ProductVariant_ProductAttribute_Mapping>();
            this.Nop_ProductVariantAttributeCombination = new List<Nop_ProductVariantAttributeCombination>();
            this.Nop_ProductVariantLocalized = new List<Nop_ProductVariantLocalized>();
            this.Nop_ShoppingCartItem = new List<Nop_ShoppingCartItem>();
            this.Nop_TierPrice = new List<Nop_TierPrice>();
            this.Nop_Discount = new List<Nop_Discount>();
            this.Nop_Discount1 = new List<Nop_Discount>();
        }

        public int ProductVariantId { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public string AdminComment { get; set; }
        public string ManufacturerPartNumber { get; set; }
        public bool IsGiftCard { get; set; }
        public bool IsDownload { get; set; }
        public int DownloadID { get; set; }
        public bool UnlimitedDownloads { get; set; }
        public int MaxNumberOfDownloads { get; set; }
        public Nullable<int> DownloadExpirationDays { get; set; }
        public int DownloadActivationType { get; set; }
        public bool HasSampleDownload { get; set; }
        public int SampleDownloadID { get; set; }
        public bool HasUserAgreement { get; set; }
        public string UserAgreementText { get; set; }
        public bool IsRecurring { get; set; }
        public int CycleLength { get; set; }
        public int CyclePeriod { get; set; }
        public int TotalCycles { get; set; }
        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public decimal AdditionalShippingCharge { get; set; }
        public bool IsTaxExempt { get; set; }
        public int TaxCategoryID { get; set; }
        public int ManageInventory { get; set; }
        public int StockQuantity { get; set; }
        public bool DisplayStockAvailability { get; set; }
        public int MinStockQuantity { get; set; }
        public int LowStockActivityID { get; set; }
        public int NotifyAdminForQuantityBelow { get; set; }
        public bool AllowOutOfStockOrders { get; set; }
        public int OrderMinimumQuantity { get; set; }
        public int OrderMaximumQuantity { get; set; }
        public int WarehouseID { get; set; }
        public bool DisableBuyButton { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }
        public decimal ProductCost { get; set; }
        public bool CustomerEntersPrice { get; set; }
        public decimal MinimumCustomerEnteredPrice { get; set; }
        public decimal MaximumCustomerEnteredPrice { get; set; }
        public double Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int PictureID { get; set; }
        public Nullable<System.DateTime> AvailableStartDateTime { get; set; }
        public Nullable<System.DateTime> AvailableEndDateTime { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string ISBN { get; set; }
        public virtual ICollection<Nop_CustomerRole_ProductPrice> Nop_CustomerRole_ProductPrice { get; set; }
        public virtual Nop_LowStockActivity Nop_LowStockActivity { get; set; }
        public virtual ICollection<Nop_OrderProductVariant> Nop_OrderProductVariant { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
        public virtual ICollection<Nop_ProductVariant_Pricelist_Mapping> Nop_ProductVariant_Pricelist_Mapping { get; set; }
        public virtual ICollection<Nop_ProductVariant_ProductAttribute_Mapping> Nop_ProductVariant_ProductAttribute_Mapping { get; set; }
        public virtual ICollection<Nop_ProductVariantAttributeCombination> Nop_ProductVariantAttributeCombination { get; set; }
        public virtual ICollection<Nop_ProductVariantLocalized> Nop_ProductVariantLocalized { get; set; }
        public virtual ICollection<Nop_ShoppingCartItem> Nop_ShoppingCartItem { get; set; }
        public virtual ICollection<Nop_TierPrice> Nop_TierPrice { get; set; }
        public virtual ICollection<Nop_Discount> Nop_Discount { get; set; }
        public virtual ICollection<Nop_Discount> Nop_Discount1 { get; set; }
    }
}
