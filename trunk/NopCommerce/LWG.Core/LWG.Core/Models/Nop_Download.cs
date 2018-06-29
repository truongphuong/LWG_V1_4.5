using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_Download
    {
        public int DownloadID { get; set; }
        public bool UseDownloadURL { get; set; }
        public string DownloadURL { get; set; }
        public byte[] DownloadBinary { get; set; }
        public string ContentType { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public bool IsNew { get; set; }
    }
}
