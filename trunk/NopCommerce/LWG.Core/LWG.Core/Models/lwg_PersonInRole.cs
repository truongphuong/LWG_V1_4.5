using System;
using System.Collections.Generic;

namespace LWG.Core.Models
{
    public partial class lwg_PersonInRole
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
        public int CatalogId { get; set; }
        public virtual lwg_Catalog lwg_Catalog { get; set; }
        public virtual lwg_Person lwg_Person { get; set; }
        public virtual lwg_Role lwg_Role { get; set; }
    }
}
