using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class PeriodBiz
    {
        private LudwigContext dbContext;

        public PeriodBiz()
        {
            dbContext = new LudwigContext();
        }

        public List<lwg_Period> GetListPeriod()
        {
            return dbContext.lwg_Period.OrderBy(p => p.Name).ToList();
        }

        public bool SavePeriod(lwg_Period p)
        {
            if (p != null)
            {
                if (p.PeriodId > 0)
                {
                    lwg_Period c = dbContext.lwg_Period.SingleOrDefault(ht => ht.PeriodId == p.PeriodId);
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
                    if (dbContext.lwg_Period.Count() > 0)
                    {
                        p.PeriodId = dbContext.lwg_Period.OrderByDescending(pe => pe.PeriodId).First().PeriodId + 1;
                    }
                    else
                    {
                        p.PeriodId = 1;
                    }
                    dbContext.lwg_Period.Add(p);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_Period GetByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_Period.SingleOrDefault(h => h.PeriodId == id);
            }
            return null;
        }

        public bool DeletePeriod(lwg_Period p)
        {
            if (p != null)
            {
                if (!dbContext.lwg_Catalog.Any(cl => cl.PeriodId == p.PeriodId))
                {
                    dbContext.lwg_Period.Remove(p);
                    dbContext.SaveChanges();
                    return true ;
                }
            }
            return false;
        }

        public List<lwg_PeriodMapping> GetListPeriodMappingByCatalogID(int id)
        {
            return dbContext.lwg_PeriodMapping.Where(o => o.CatalogID == id).ToList();
        }

        public bool DeletePeriodMappingBuyID(int periodID, int productID)
        {
            lwg_PeriodMapping lwg = dbContext.lwg_PeriodMapping.SingleOrDefault(o => o.PeriodID == periodID && o.CatalogID == productID);
            if (lwg != null)
            {
                dbContext.lwg_PeriodMapping.Add(lwg);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SavePeriodMappingByID(lwg_PeriodMapping lwg)
        {
            if (lwg != null && !dbContext.lwg_PeriodMapping.Any(o=>o.PeriodID == lwg.PeriodID && o.CatalogID == lwg.CatalogID))
            {
                dbContext.lwg_PeriodMapping.Add(lwg);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeletePeriodMappingBuyID(int catalogID)
        {
            List<lwg_PeriodMapping> lst = dbContext.lwg_PeriodMapping.Where(o => o.CatalogID == catalogID).ToList();
            if (lst != null && lst.Count > 0)
            {
                dbContext.lwg_PeriodMapping.RemoveRange(lst);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckAndInsertPeriod( string periodName, int catalogID)
        {
            lwg_Period lwg = dbContext.lwg_Period.SingleOrDefault(o => o.Name.ToLower().Equals(periodName.ToLower()));
            if (lwg == null)
            {
                lwg = new lwg_Period();
                lwg.Name = periodName;
                SavePeriod(lwg);
            }
            if (!dbContext.lwg_PeriodMapping.Any(o => o.CatalogID == catalogID && o.PeriodID == lwg.PeriodId))
            {
                lwg_PeriodMapping periodMapping = new lwg_PeriodMapping();
                periodMapping.PeriodID = lwg.PeriodId;
                periodMapping.CatalogID = catalogID;
                dbContext.lwg_PeriodMapping.Add(periodMapping);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
