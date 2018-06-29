using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_TitleType
    {
        public lwg_TitleType()
        {
            this.lwg_InstrTitle = new List<lwg_InstrTitle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<lwg_InstrTitle> lwg_InstrTitle { get; set; }
    }
}
