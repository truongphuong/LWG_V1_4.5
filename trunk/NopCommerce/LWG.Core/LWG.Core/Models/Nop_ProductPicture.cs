using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_ProductPicture
    {
        public int ProductPictureID { get; set; }
        public int ProductID { get; set; }
        public int PictureID { get; set; }
        public int DisplayOrder { get; set; }
        public virtual Nop_Picture Nop_Picture { get; set; }
        public virtual Nop_Product Nop_Product { get; set; }
    }
}
