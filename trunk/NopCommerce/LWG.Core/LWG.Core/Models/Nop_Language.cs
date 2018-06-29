using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Language
    {
        public Nop_Language()
        {
            this.Nop_BlogPost = new List<Nop_BlogPost>();
            this.Nop_CategoryLocalized = new List<Nop_CategoryLocalized>();
            this.Nop_CheckoutAttributeLocalized = new List<Nop_CheckoutAttributeLocalized>();
            this.Nop_CheckoutAttributeValueLocalized = new List<Nop_CheckoutAttributeValueLocalized>();
            this.Nop_LocaleStringResource = new List<Nop_LocaleStringResource>();
            this.Nop_ManufacturerLocalized = new List<Nop_ManufacturerLocalized>();
            this.Nop_MessageTemplateLocalized = new List<Nop_MessageTemplateLocalized>();
            this.Nop_News = new List<Nop_News>();
            this.Nop_Poll = new List<Nop_Poll>();
            this.Nop_ProductAttributeLocalized = new List<Nop_ProductAttributeLocalized>();
            this.Nop_ProductLocalized = new List<Nop_ProductLocalized>();
            this.Nop_ProductVariantAttributeValueLocalized = new List<Nop_ProductVariantAttributeValueLocalized>();
            this.Nop_ProductVariantLocalized = new List<Nop_ProductVariantLocalized>();
            this.Nop_SpecificationAttributeLocalized = new List<Nop_SpecificationAttributeLocalized>();
            this.Nop_SpecificationAttributeOptionLocalized = new List<Nop_SpecificationAttributeOptionLocalized>();
            this.Nop_TopicLocalized = new List<Nop_TopicLocalized>();
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string FlagImageFileName { get; set; }
        public bool Published { get; set; }
        public int DisplayOrder { get; set; }
        public virtual ICollection<Nop_BlogPost> Nop_BlogPost { get; set; }
        public virtual ICollection<Nop_CategoryLocalized> Nop_CategoryLocalized { get; set; }
        public virtual ICollection<Nop_CheckoutAttributeLocalized> Nop_CheckoutAttributeLocalized { get; set; }
        public virtual ICollection<Nop_CheckoutAttributeValueLocalized> Nop_CheckoutAttributeValueLocalized { get; set; }
        public virtual ICollection<Nop_LocaleStringResource> Nop_LocaleStringResource { get; set; }
        public virtual ICollection<Nop_ManufacturerLocalized> Nop_ManufacturerLocalized { get; set; }
        public virtual ICollection<Nop_MessageTemplateLocalized> Nop_MessageTemplateLocalized { get; set; }
        public virtual ICollection<Nop_News> Nop_News { get; set; }
        public virtual ICollection<Nop_Poll> Nop_Poll { get; set; }
        public virtual ICollection<Nop_ProductAttributeLocalized> Nop_ProductAttributeLocalized { get; set; }
        public virtual ICollection<Nop_ProductLocalized> Nop_ProductLocalized { get; set; }
        public virtual ICollection<Nop_ProductVariantAttributeValueLocalized> Nop_ProductVariantAttributeValueLocalized { get; set; }
        public virtual ICollection<Nop_ProductVariantLocalized> Nop_ProductVariantLocalized { get; set; }
        public virtual ICollection<Nop_SpecificationAttributeLocalized> Nop_SpecificationAttributeLocalized { get; set; }
        public virtual ICollection<Nop_SpecificationAttributeOptionLocalized> Nop_SpecificationAttributeOptionLocalized { get; set; }
        public virtual ICollection<Nop_TopicLocalized> Nop_TopicLocalized { get; set; }
    }
}
