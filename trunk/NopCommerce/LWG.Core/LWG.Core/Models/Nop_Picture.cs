using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Picture
    {
        public Nop_Picture()
        {
            this.Nop_ProductPicture = new List<Nop_ProductPicture>();
        }

        public int PictureID { get; set; }
        public byte[] PictureBinary { get; set; }
        public string Extension { get; set; }
        public bool IsNew { get; set; }
        public virtual ICollection<Nop_ProductPicture> Nop_ProductPicture { get; set; }
    }
}
