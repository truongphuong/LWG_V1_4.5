using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_CatalogTitle
    {
        public int Id { get; set; }
        public int CatalogId { get; set; }
        public int InstrTitleId { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
        public virtual lwg_InstrTitle lwg_InstrTitle { get; set; }
    }
}
