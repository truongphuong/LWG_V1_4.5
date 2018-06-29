using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Video
    {
        public int VideoId { get; set; }
        public int CatalogId { get; set; }
        public string QTFile { get; set; }
        public int DisplayOrder { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
    }
}
