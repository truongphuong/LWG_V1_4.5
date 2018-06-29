using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class SeriesBiz
    {
        private LudwigContext dbContext;

        public SeriesBiz()
        {
            dbContext = new LudwigContext();
        }

        public List<lwg_Series> GetListSeries()
        {
            return dbContext.lwg_Series.OrderBy(p => p.Name).ToList();
        }

        public bool SaveSeries(lwg_Series p)
        {
            if (p != null)
            {
                if (p.SeriesId > 0)
                {
                    lwg_Series c = dbContext.lwg_Series.SingleOrDefault(ht => ht.SeriesId == p.SeriesId);
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
                    if (dbContext.lwg_Series.Count() > 0)
                    {
                        p.SeriesId = dbContext.lwg_Series.OrderByDescending(pe => pe.SeriesId).First().SeriesId + 1;
                    }
                    else
                    {
                        p.SeriesId = 1;
                    }
                    dbContext.lwg_Series.Add(p);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_Series GetByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_Series.SingleOrDefault(h => h.SeriesId == id);
            }
            return null;
        }

        public bool DeleteSeries(lwg_Series p)
        {
            if (p != null)
            {
                if (!dbContext.lwg_Catalog.Any(cl => cl.SeriesId == p.SeriesId))
                {
                    dbContext.lwg_Series.Remove(p);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<lwg_SeriesMapping> GetListSeriesMappingByCatalogID(int id)
        {
            return dbContext.lwg_SeriesMapping.Where(o => o.CatalogID == id).ToList();
        }

        public bool DeleteSeriesMappingByID(int seriesID, int catalogID)
        {
            lwg_SeriesMapping lwg = dbContext.lwg_SeriesMapping.SingleOrDefault(o => o.SeriesID == seriesID && o.CatalogID == catalogID);
            if (lwg != null)
            {
                dbContext.lwg_SeriesMapping.Remove(lwg);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SaveSeriesMapping(lwg_SeriesMapping lwg)
        {
            if (lwg != null && !dbContext.lwg_SeriesMapping.Any(o=>o.SeriesID == lwg.SeriesID && o.CatalogID == lwg.CatalogID))
            {
                dbContext.lwg_SeriesMapping.Add(lwg);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSeriesMappingByID(int catalogID)
        {
            List<lwg_SeriesMapping> lst = dbContext.lwg_SeriesMapping.Where(o =>o.CatalogID == catalogID).ToList();
            if (lst != null && lst.Count >0)
            {
                dbContext.lwg_SeriesMapping.RemoveRange(lst);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckAndInsertSeries(string seriesName, int catalogID)
        {
            lwg_Series lwg = dbContext.lwg_Series.SingleOrDefault(o => o.Name.ToLower().Equals(seriesName.ToLower()));
            if (lwg == null)
            {
                lwg = new lwg_Series();
                lwg.Name = seriesName;
                SaveSeries(lwg);
            }
            if (!dbContext.lwg_SeriesMapping.Any(o => o.CatalogID == catalogID && o.SeriesID == lwg.SeriesId))
            {
                lwg_SeriesMapping seriesMapping = new lwg_SeriesMapping();
                seriesMapping.CatalogID = catalogID;
                seriesMapping.SeriesID = lwg.SeriesId;
                dbContext.lwg_SeriesMapping.Add(seriesMapping);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
