using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_HtmlContent
    {
        public long ID { get; set; }
        public string ContentHtml { get; set; }
        public bool IsDelete { get; set; }
    }
}
