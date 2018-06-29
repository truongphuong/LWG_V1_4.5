using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class Nop_EmailDirectory
    {
        public int EmailID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Description { get; set; }
        public Nullable<int> PictureID { get; set; }
    }
}
