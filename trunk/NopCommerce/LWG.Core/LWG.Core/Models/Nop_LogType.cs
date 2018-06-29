using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_LogType
    {
        public Nop_LogType()
        {
            this.Nop_Log = new List<Nop_Log>();
        }

        public int LogTypeID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Nop_Log> Nop_Log { get; set; }
    }
}
