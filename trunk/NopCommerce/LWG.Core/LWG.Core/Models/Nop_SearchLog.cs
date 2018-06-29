using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_SearchLog
    {
        public int SearchLogID { get; set; }
        public string SearchTerm { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }
}
