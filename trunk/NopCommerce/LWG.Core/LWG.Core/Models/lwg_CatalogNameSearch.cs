using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_CatalogNameSearch
    {
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
    }
}
