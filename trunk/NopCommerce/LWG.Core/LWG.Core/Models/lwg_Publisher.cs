using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Publisher
    {
        public lwg_Publisher()
        {
            this.lwg_CatalogPublisher = new List<lwg_CatalogPublisher>();
        }

        public int PublisherId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<lwg_CatalogPublisher> lwg_CatalogPublisher { get; set; }
    }
}
