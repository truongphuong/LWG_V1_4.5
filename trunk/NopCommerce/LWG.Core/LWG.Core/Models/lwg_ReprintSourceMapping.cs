using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_ReprintSourceMapping
    {
        public int Id { get; set; }
        public int ReprintSourceID { get; set; }
        public int CatalogID { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
        public virtual lwg_ReprintSource lwg_ReprintSource { get; set; }
    }
}
