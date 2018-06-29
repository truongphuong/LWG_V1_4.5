using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Category
    {
        public Nop_Category()
        {
            this.Nop_CategoryLocalized = new List<Nop_CategoryLocalized>();
            this.Nop_Product_Category_Mapping = new List<Nop_Product_Category_Mapping>();
        }

        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TemplateID { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SEName { get; set; }
        public int ParentCategoryID { get; set; }
        public int PictureID { get; set; }
        public int PageSize { get; set; }
        public string PriceRanges { get; set; }
        public bool ShowOnHomePage { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public int DisplayOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual Nop_CategoryTemplate Nop_CategoryTemplate { get; set; }
        public virtual ICollection<Nop_CategoryLocalized> Nop_CategoryLocalized { get; set; }
        public virtual ICollection<Nop_Product_Category_Mapping> Nop_Product_Category_Mapping { get; set; }
    }
}
