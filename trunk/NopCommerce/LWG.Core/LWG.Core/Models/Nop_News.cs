using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_News
    {
        public Nop_News()
        {
            this.Nop_NewsComment = new List<Nop_NewsComment>();
        }

        public int NewsID { get; set; }
        public int LanguageID { get; set; }
        public string Title { get; set; }
        public string Short { get; set; }
        public string Full { get; set; }
        public bool Published { get; set; }
        public bool AllowComments { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public virtual Nop_Language Nop_Language { get; set; }
        public virtual ICollection<Nop_NewsComment> Nop_NewsComment { get; set; }
    }
}
