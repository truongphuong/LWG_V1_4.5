using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public  class EmailDirectoryBiz
    {
        private LudwigContext dbContent;

        public EmailDirectoryBiz()
        {
            dbContent = new LudwigContext();
        }

        public List<Nop_EmailDirectory> GetAllEmail()
        {
            return dbContent.Nop_EmailDirectory.OrderByDescending(t => t.EmailID).ToList();
        }

        public List<Nop_EmailDirectory> GetEmailByName(string firstname,string lastname)
        {
            var query = from email in dbContent.Nop_EmailDirectory where email.FirstName.StartsWith(firstname) && email.LastName.StartsWith(lastname) select email;
            return query.OrderByDescending(t=>t.EmailID).ToList();
        }

        public bool DeleteEmail(int emailid)
        {
            if (emailid != 0)
            {
                var item = dbContent.Nop_EmailDirectory.Where(t => t.EmailID == emailid);
                dbContent.Nop_EmailDirectory.Remove(item.First());
                dbContent.SaveChanges();
                return true;
            
            }
            return false;
        }

        public Nop_EmailDirectory GetEmailByID(int emailid)
        {
            var r = dbContent.Nop_EmailDirectory.Where(t => t.EmailID == emailid);
           
            if (r.Count() > 0)
            {
                return r.First();
            }
            else
                return null;
        }
        public List<Nop_EmailDirectory> GetEmailByFirstLetter(string firstletter)
        {
            var query = from email in dbContent.Nop_EmailDirectory where email.LastName.StartsWith(firstletter.ToLower()) || email.LastName.StartsWith(firstletter.ToUpper()) select email;
            return query.OrderByDescending(t => t.EmailID).ToList();
        }
        public bool SaveEmail(Nop_EmailDirectory email)
        {
            if (email.EmailID != 0)
            {
                Nop_EmailDirectory cur = dbContent.Nop_EmailDirectory.Where(t => t.EmailID == email.EmailID).First();
                if (cur != null)
                {
                    cur.Description = email.Description;
                    cur.EmailAddress = email.EmailAddress;
                    cur.FirstName = email.FirstName;
                    cur.LastName = email.LastName;
                    cur.PhoneNumber = email.PhoneNumber;
                    cur.PictureID = email.PictureID;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (email != null)
                {
                    dbContent.Nop_EmailDirectory.Add(email);
                }
                else
                {
                    return false;
                }
            }
            dbContent.SaveChanges();
            return true;
        }
    }
}
