using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Log
    {
        public int LogID { get; set; }
        public int LogTypeID { get; set; }
        public int Severity { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string IPAddress { get; set; }
        public int CustomerID { get; set; }
        public string PageURL { get; set; }
        public string ReferrerURL { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_LogType Nop_LogType { get; set; }
    }
}
