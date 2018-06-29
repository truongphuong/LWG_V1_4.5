using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_CatalogTitleSearch
    {
        public int CatalogId { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
    }
}
