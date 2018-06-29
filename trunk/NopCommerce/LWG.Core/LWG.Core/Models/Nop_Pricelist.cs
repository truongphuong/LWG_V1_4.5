using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Pricelist
    {
        public Nop_Pricelist()
        {
            this.Nop_ProductVariant_Pricelist_Mapping = new List<Nop_ProductVariant_Pricelist_Mapping>();
        }

        public int PricelistID { get; set; }
        public int ExportModeID { get; set; }
        public int ExportTypeID { get; set; }
        public int AffiliateID { get; set; }
        public string DisplayName { get; set; }
        public string ShortName { get; set; }
        public string PricelistGuid { get; set; }
        public int CacheTime { get; set; }
        public string FormatLocalization { get; set; }
        public string Description { get; set; }
        public string AdminNotes { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public int PriceAdjustmentTypeID { get; set; }
        public decimal PriceAdjustment { get; set; }
        public bool OverrideIndivAdjustment { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual ICollection<Nop_ProductVariant_Pricelist_Mapping> Nop_ProductVariant_Pricelist_Mapping { get; set; }
    }
}
