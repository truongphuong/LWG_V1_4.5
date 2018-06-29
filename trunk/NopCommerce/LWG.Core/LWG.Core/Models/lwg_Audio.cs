using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Audio
    {
        public int AudioId { get; set; }
        public int CatalogId { get; set; }
        public string SoundFile { get; set; }
        public int DisplayOrder { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
    }
}
