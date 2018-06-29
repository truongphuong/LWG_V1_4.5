using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_CatalogInstrumentSearch
    {
        public int CatalogId { get; set; }
        public string IntrText { get; set; }
        public int Id { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
    }
}
