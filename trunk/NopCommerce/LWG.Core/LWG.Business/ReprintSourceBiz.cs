using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class ReprintSourceBiz
    {
        private LudwigContext dbContext;

        public ReprintSourceBiz()
        {
            dbContext = new LudwigContext();
        }

        public List<lwg_ReprintSource> GetListReprintSource()
        {
            return dbContext.lwg_ReprintSource.OrderBy(i => i.Name).ToList();
        }

        public bool SaveReprintSource(lwg_ReprintSource i)
        {
            if (i != null)
            {
                if (i.ReprintSourceId > 0)
                {
                    lwg_ReprintSource c = dbContext.lwg_ReprintSource.SingleOrDefault(it => it.ReprintSourceId == i.ReprintSourceId);
                    if (c != null)
                    {
                        c.Name = i.Name;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dbContext.lwg_ReprintSource.Count() > 0)
                    {
                        i.ReprintSourceId = dbContext.lwg_ReprintSource.OrderByDescending(pe => pe.ReprintSourceId).First().ReprintSourceId + 1;
                    }
                    else
                    {
                        i.ReprintSourceId = 1;
                    }
                    dbContext.lwg_ReprintSource.Add(i);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_ReprintSource GetByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_ReprintSource.SingleOrDefault(h => h.ReprintSourceId == id);
            }
            return null;
        }

        public bool DeleteReprintSource(lwg_ReprintSource i)
        {
            if (i != null)
            {
                if (!dbContext.lwg_Catalog.Any(cl => cl.ReprintSourceId == i.ReprintSourceId))
                {
                    dbContext.lwg_ReprintSource.Remove(i);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<lwg_ReprintSourceMapping> GetListReprintSourceMappingByCatalogID(int id)
        {
            return dbContext.lwg_ReprintSourceMapping.Where(o => o.CatalogID == id).ToList();
        }

        public bool DeleteReprintSourceMappingByID(int reprintsourceID, int catalogID)
        {
            lwg_ReprintSourceMapping lwg = dbContext.lwg_ReprintSourceMapping.SingleOrDefault(o => o.ReprintSourceID == reprintsourceID && o.CatalogID == catalogID);
            if (lwg != null)
            {
                dbContext.lwg_ReprintSourceMapping.Remove(lwg);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SaveReprintSourceMapping(lwg_ReprintSourceMapping lwg)
        {
            if (lwg != null && !dbContext.lwg_ReprintSourceMapping.Any(o => o.ReprintSourceID == lwg.ReprintSourceID && o.CatalogID == lwg.CatalogID))
            {
                dbContext.lwg_ReprintSourceMapping.Add(lwg);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteReprintSourceMappingByID(int catalogID)
        {
            List<lwg_ReprintSourceMapping> lst = dbContext.lwg_ReprintSourceMapping.Where(o => o.CatalogID == catalogID).ToList();
            if (lst != null && lst.Count >0)
            {
                dbContext.lwg_ReprintSourceMapping.RemoveRange(lst);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckAndInsertRepringSource(string reprinteSourceName, int catalogID)
        {
            lwg_ReprintSource lwg = dbContext.lwg_ReprintSource.SingleOrDefault(o => o.Name.ToLower().Equals(reprinteSourceName.ToLower()));
            if (lwg == null)
            {
                lwg = new lwg_ReprintSource();
                lwg.Name = reprinteSourceName;
                SaveReprintSource(lwg);
            }
            if (!dbContext.lwg_ReprintSourceMapping.Any(o => o.CatalogID == catalogID && o.ReprintSourceID == lwg.ReprintSourceId))
            {
                lwg_ReprintSourceMapping reprintSourceMapping = new lwg_ReprintSourceMapping();
                reprintSourceMapping.ReprintSourceID = lwg.ReprintSourceId;
                reprintSourceMapping.CatalogID = catalogID;
                dbContext.lwg_ReprintSourceMapping.Add(reprintSourceMapping);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
