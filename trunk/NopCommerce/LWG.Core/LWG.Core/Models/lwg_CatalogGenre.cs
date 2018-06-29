using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_CatalogGenre
    {
        public int Id { get; set; }
        public int CatalogId { get; set; }
        public int GerneId { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
        public virtual lwg_Genre lwg_Genre { get; set; }
    }
}
