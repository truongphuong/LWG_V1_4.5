using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_InstrTitle
    {
        public lwg_InstrTitle()
        {
            this.lwg_CatalogTitle = new List<lwg_CatalogTitle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TitleTypeId { get; set; }
        public virtual ICollection<lwg_CatalogTitle> lwg_CatalogTitle { get; set; }
        public virtual lwg_TitleType lwg_TitleType { get; set; }
    }
}
