using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_OrderNote
    {
        public int OrderNoteID { get; set; }
        public int OrderID { get; set; }
        public string Note { get; set; }
        public bool DisplayToCustomer { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_Order Nop_Order { get; set; }
    }
}
