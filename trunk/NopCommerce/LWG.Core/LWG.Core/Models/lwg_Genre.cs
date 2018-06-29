using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Genre
    {
        public lwg_Genre()
        {
            this.lwg_CatalogGenre = new List<lwg_CatalogGenre>();
        }

        public int GerneId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<lwg_CatalogGenre> lwg_CatalogGenre { get; set; }
    }
}
