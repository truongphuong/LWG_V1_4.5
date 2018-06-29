using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class PublisherBiz
    {
        private LudwigContext dbContext;

        public PublisherBiz()
        {
            dbContext = new LudwigContext();            
        }

        public List<lwg_Publisher> GetListPublisher()
        {
            return dbContext.lwg_Publisher.OrderBy(p => p.Name).ToList();
        }

        public bool SavePublisher(lwg_Publisher p)
        {
            if (p != null)
            {
                if (p.PublisherId > 0)
                {
                    lwg_Publisher c = dbContext.lwg_Publisher.SingleOrDefault(ht => ht.PublisherId == p.PublisherId);
                    if (c != null)
                    {
                        c.Name = p.Name;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dbContext.lwg_Publisher.Count() > 0)
                    {
                        p.PublisherId = dbContext.lwg_Publisher.OrderByDescending(pe => pe.PublisherId).First().PublisherId + 1;
                    }
                    else
                    {
                        p.PublisherId = 1;
                    }
                    dbContext.lwg_Publisher.Add(p);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_Publisher GetByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_Publisher.SingleOrDefault(h => h.PublisherId == id);
            }
            return null;
        }

        public bool DeletePublisher(lwg_Publisher p)
        {
            if (p != null)
            {
                List<lwg_CatalogPublisher> lst = dbContext.lwg_CatalogPublisher.Where(cg => cg.PublisherId == p.PublisherId).ToList();
                if (lst != null && lst.Count > 0)
                {
                    dbContext.lwg_CatalogPublisher.RemoveRange(lst);
                }
                dbContext.lwg_Publisher.Remove(p);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckAndInsertPublisher(string publisherName, int catalogID)
        {
            lwg_Publisher lwg = dbContext.lwg_Publisher.SingleOrDefault(o => o.Name.ToLower().Equals(publisherName.ToLower()));
            if (lwg == null)
            {
                lwg = new lwg_Publisher();
                lwg.Name = publisherName;
                SavePublisher(lwg);
            }
            if (!dbContext.lwg_CatalogPublisher.Any(o => o.CatalogId == catalogID && o.PublisherId == lwg.PublisherId))
            {
                lwg_CatalogPublisher catalogPublisher = new lwg_CatalogPublisher();
                catalogPublisher.CatalogId = catalogID;
                catalogPublisher.PublisherId = lwg.PublisherId;
                dbContext.lwg_CatalogPublisher.Add(catalogPublisher);
                dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
