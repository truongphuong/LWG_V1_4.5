using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_TopicLocalized
    {
        public int TopicLocalizedID { get; set; }
        public int TopicID { get; set; }
        public int LanguageID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime UpdatedOn { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual Nop_Topic Nop_Topic { get; set; }
    }
}
