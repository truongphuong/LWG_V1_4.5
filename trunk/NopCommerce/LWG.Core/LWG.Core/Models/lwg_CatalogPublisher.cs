using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_CatalogPublisher
    {
        public int Id { get; set; }
        public int CatalogId { get; set; }
        public int PublisherId { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
        public virtual lwg_Publisher lwg_Publisher { get; set; }
    }
}
