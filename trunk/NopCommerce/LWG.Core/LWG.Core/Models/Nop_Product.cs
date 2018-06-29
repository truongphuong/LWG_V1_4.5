using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Product
    {
        public Nop_Product()
        {
            this.Nop_Product_Category_Mapping = new List<Nop_Product_Category_Mapping>();
            this.Nop_Product_Manufacturer_Mapping = new List<Nop_Product_Manufacturer_Mapping>();
            this.Nop_Product_SpecificationAttribute_Mapping = new List<Nop_Product_SpecificationAttribute_Mapping>();
            this.Nop_ProductLocalized = new List<Nop_ProductLocalized>();
            this.Nop_ProductPicture = new List<Nop_ProductPicture>();
            this.Nop_ProductRating = new List<Nop_ProductRating>();
            this.Nop_ProductReview = new List<Nop_ProductReview>();
            this.Nop_ProductVariant = new List<Nop_ProductVariant>();
            this.Nop_RelatedProduct = new List<Nop_RelatedProduct>();
            this.Nop_ProductTag = new List<Nop_ProductTag>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string AdminComment { get; set; }
        public int ProductTypeID { get; set; }
        public int TemplateID { get; set; }
        public bool ShowOnHomePage { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string SEName { get; set; }
        public bool AllowCustomerReviews { get; set; }
        public bool AllowCustomerRatings { get; set; }
        public int RatingSum { get; set; }
        public int TotalRatingVotes { get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public virtual ICollection<Nop_Product_Category_Mapping> Nop_Product_Category_Mapping { get; set; }
        public virtual ICollection<Nop_Product_Manufacturer_Mapping> Nop_Product_Manufacturer_Mapping { get; set; }
        public virtual Nop_ProductTemplate Nop_ProductTemplate { get; set; }
        public virtual Nop_ProductType Nop_ProductType { get; set; }
        public virtual ICollection<Nop_Product_SpecificationAttribute_Mapping> Nop_Product_SpecificationAttribute_Mapping { get; set; }
        public virtual ICollection<Nop_ProductLocalized> Nop_ProductLocalized { get; set; }
        public virtual ICollection<Nop_ProductPicture> Nop_ProductPicture { get; set; }
        public virtual ICollection<Nop_ProductRating> Nop_ProductRating { get; set; }
        public virtual ICollection<Nop_ProductReview> Nop_ProductReview { get; set; }
        public virtual ICollection<Nop_ProductVariant> Nop_ProductVariant { get; set; }
        public virtual ICollection<Nop_RelatedProduct> Nop_RelatedProduct { get; set; }
        public virtual ICollection<Nop_ProductTag> Nop_ProductTag { get; set; }
    }
}
