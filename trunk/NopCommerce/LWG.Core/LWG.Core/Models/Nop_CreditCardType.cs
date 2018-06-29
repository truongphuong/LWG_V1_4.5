using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_CreditCardType
    {
        public int CreditCardTypeID { get; set; }
        public string Name { get; set; }
        public string SystemKeyword { get; set; }
        public int DisplayOrder { get; set; }
        public bool Deleted { get; set; }
    }
}
