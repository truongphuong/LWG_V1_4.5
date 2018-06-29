using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_PeriodMapping
    {
        public int Id { get; set; }
        public int PeriodID { get; set; }
        public int CatalogID { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
        public virtual lwg_Period lwg_Period { get; set; }
    }
}
