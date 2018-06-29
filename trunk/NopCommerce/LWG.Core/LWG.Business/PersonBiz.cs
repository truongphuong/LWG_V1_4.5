using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class PersonBiz
    {
        private LudwigContext dbContext;

        public PersonBiz()
        {
            dbContext = new LudwigContext();
        }

        public List<lwg_Person> GetListPerson(int take, int skip, bool IsDelete, ref int total)
        {
            if (IsDelete)
            {
                var query = dbContext.lwg_Person.OrderByDescending(h => h.PersonId);
                total = query.Count();
                return query.Take(take).Skip(skip).ToList();
            }
            else
            {

                var query = dbContext.lwg_Person.OrderByDescending(t => t.PersonId);
                total = query.Count();
                return query.Take(take).Skip(skip).ToList();
            }
        }

        public List<lwg_Person> GetAllPersons(string NameDisplay, string FirstLetter)
        {
            var query = dbContext.lwg_Person.OrderBy(p => p.FirstName);

            List<lwg_Person> persons = query.ToList();

            if (!string.IsNullOrEmpty(NameDisplay))
            {
                persons = persons.Where(p => p.NameDisplay.Contains(NameDisplay)).ToList();
            }
            if (!string.IsNullOrEmpty(FirstLetter) & FirstLetter != "ALL")
            {
                persons = persons.Where(p => p.FirstLetter == FirstLetter).ToList();
            }

            return persons;
        }

        public int GetPersonNumber(string FirstLetter)
        {
            if (string.IsNullOrEmpty(FirstLetter))
            {
                var query = dbContext.lwg_Person;
                return query.Count();
            }
            else
            {
                var query = dbContext.lwg_Person.Where(h => h.FirstLetter == FirstLetter);
                return query.Count();
            }
        }

        public List<lwg_Person> GetPersonByFirstLetter(string FirstLetter)
        {
            var query = dbContext.lwg_Person.Where(h => h.FirstLetter == FirstLetter).OrderBy(t => t.LastName);
            return query.ToList();
        }

        public bool SavePerson(lwg_Person h)
        {
            if (h != null)
            {
                if (h.PersonId > 0)
                {
                    lwg_Person c = dbContext.lwg_Person.SingleOrDefault(ht => ht.PersonId == h.PersonId);
                    if (c != null)
                    {
                        c.Biography = h.Biography;
                        c.DOB = h.DOB;
                        c.DOD = h.DOD;
                        c.FirstLetter = h.FirstLetter;
                        c.FirstName = h.FirstName;
                        c.LastName = h.LastName;
                        c.NameDisplay = h.NameDisplay;
                        c.NameList = h.NameList;
                        c.NameSort = h.NameSort;
                        c.PictureID = h.PictureID;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dbContext.lwg_Person.Count() > 0)
                    {
                        h.PersonId = dbContext.lwg_Person.Max(ct => ct.PersonId) + 1;
                    }
                    else
                    {
                        h.PersonId = 1;
                    }
                    dbContext.lwg_Person.Add(h);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeletePerson(long PersonId)
        {
            lwg_Person person = GetByID(PersonId);
            if (person != null)
            {
                dbContext.lwg_Person.Remove(person);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_Person GetByID(long PersonId)
        {
            if (PersonId > 0)
            {
                return dbContext.lwg_Person.SingleOrDefault(h => h.PersonId == PersonId);
            }
            return null;
        }

        public List<lwg_Person> GetListPerson(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return dbContext.lwg_Person.OrderBy(lw => lw.FirstLetter).ToList();
            }
            else
            {
                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    return dbContext.lwg_Person.Where(lw => lw.FirstName.Contains(firstName) || lw.LastName.Contains(lastName)).ToList();
                }
                else
                {
                    if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                    {
                        return dbContext.lwg_Person.Where(lw => lw.LastName.Contains(lastName)).ToList();
                    }
                    else
                    {
                        return dbContext.lwg_Person.Where(lw => lw.FirstName.Contains(firstName)).ToList();
                    }
                }
            }
        }

        public List<lwg_PersonInRole> GetListPersonInRoleByCatalogID(int catalogID)
        {
            if (catalogID > 0)
            {
                return dbContext.lwg_PersonInRole.Where(lg => lg.CatalogId == catalogID).ToList();
            }
            return null;
        }

        public bool SavePersonInRole(lwg_PersonInRole p)
        {
            if (p != null && !dbContext.lwg_PersonInRole.Any(lw => lw.RoleId == p.RoleId && lw.PersonId == p.PersonId && lw.CatalogId == p.CatalogId))
            {
                if (dbContext.lwg_PersonInRole.Count() > 0)
                {
                    p.Id = dbContext.lwg_PersonInRole.OrderByDescending(lw => lw.Id).First().Id + 1;
                }
                else
                {
                    p.Id = 1;
                }
                dbContext.lwg_PersonInRole.Add(p);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeletePersonInRole(int id)
        {
            if (id > 0)
            {
                lwg_PersonInRole lg = dbContext.lwg_PersonInRole.SingleOrDefault(lw => lw.Id == id);
                if (lg != null)
                {
                    dbContext.lwg_PersonInRole.Remove(lg);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<lwg_Person> GetTopComposer(int number)
        {
            if (number > 0)
            {
                List<lwg_Person> lstResult = new List<lwg_Person>();
                var query = from temp in dbContext.lwg_PersonInRole
                            where temp.RoleId == LWGUtils.COMPOSER_ROLE_ID
                            group temp by temp.PersonId into g
                            orderby g.Count() descending
                            select g.Key;
                int j = 0;
                var lwg_PersonTmp = dbContext.lwg_Person.ToList();
                foreach (int i in query)
                {
                    if (j < number)
                    {
                        lwg_Person lwg = lwg_PersonTmp.SingleOrDefault(lg => lg.PersonId == i);
                        if (lwg != null)
                        {
                            lstResult.Insert(lstResult.Count, lwg);
                        }
                        j++;
                    }
                    else
                    {
                        break;
                    }
                }
                return lstResult;    
            }
            return null;
        }

        public int CountTotalProductWithComposerRole(int personId)
        {
            if (personId > 0)
            {
                return dbContext.lwg_PersonInRole.Where(lg => lg.PersonId == personId && lg.RoleId == LWGUtils.COMPOSER_ROLE_ID).Count();
            }
            return 0;
        }

        public List<Nop_Product> GetAllProductWithComposerId(int composerid, int recordCount)
        {
            return dbContext.Nop_Product.Where(p => dbContext.lwg_PersonInRole.Any(pir => pir.CatalogId == p.ProductId && pir.PersonId == composerid)).Take(recordCount).ToList();                             
        }
        public List<Nop_Product> GetAllProductWithComposerId(int composerid)
        {
            return dbContext.Nop_Product.Where(p => dbContext.lwg_PersonInRole.Any(pir => pir.CatalogId == p.ProductId && pir.PersonId == composerid)).ToList();
        }


        public lwg_Person GetPersonByName(string fName, string lName)
        {
            List<lwg_Person> lst = dbContext.lwg_Person.Where(o => o.FirstName.ToUpper().Equals(fName.ToUpper()) && o.LastName.ToLower().Equals(lName.ToLower())).ToList();
            if (lst != null && lst.Count > 0)
            {
                return lst.First();
            }
            return null;
        }

        public lwg_Person SaveImport(lwg_Person p)
        {              
            if (dbContext.lwg_Person.Count() > 0)
            {
                p.PersonId = dbContext.lwg_Person.Max(ct => ct.PersonId) + 1;
            }
            else
            {
                p.PersonId = 1;
            }
            dbContext.lwg_Person.Add(p);           
            dbContext.SaveChanges();
            return p;
                        
        }
    }
}
