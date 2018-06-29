using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_Person
    {
        public lwg_Person()
        {
            this.lwg_PersonInRole = new List<lwg_PersonInRole>();
        }

        public int PersonId { get; set; }
        public string NameDisplay { get; set; }
        public string NameList { get; set; }
        public string NameSort { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string DOD { get; set; }
        public string Biography { get; set; }
        public string FirstLetter { get; set; }
        public Nullable<int> PictureID { get; set; }
        public virtual ICollection<lwg_PersonInRole> lwg_PersonInRole { get; set; }
    }
}
