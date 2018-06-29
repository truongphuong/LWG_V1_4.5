using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CustomerAttribute
    {
        public int CustomerAttributeId { get; set; }
        public int CustomerId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual Nop_Customer Nop_Customer { get; set; }
    }
}
