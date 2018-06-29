using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Instrumental
    {
        public lwg_Instrumental()
        {
            this.lwg_Catalog = new List<lwg_Catalog>();
        }

        public int InstrumentalId { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public virtual ICollection<lwg_Catalog> lwg_Catalog { get; set; }
    }
}
