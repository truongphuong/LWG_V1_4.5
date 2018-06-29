using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_SeriesMapping
    {
        public int Id { get; set; }
        public int SeriesID { get; set; }
        public int CatalogID { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
        public virtual lwg_Series lwg_Series { get; set; }
    }
}
