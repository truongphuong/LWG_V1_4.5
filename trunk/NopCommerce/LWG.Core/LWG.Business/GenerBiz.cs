using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Business;
using LWG.Core.Models;

namespace LWG.Business
{
    public class GenerBiz
    {
        private LudwigContext dbContext;

        public GenerBiz()
        {
            dbContext = new LudwigContext();
        }

        public List<lwg_Genre> GetListGenre()
        {
            return dbContext.lwg_Genre.OrderBy(p => p.Name).ToList();
        }

        public List<lwg_CatalogGenre> GetListCatalogGenre(int catalogID)
        {
            return dbContext.lwg_CatalogGenre.Where(p => p.CatalogId == catalogID).OrderByDescending(p => p.lwg_Genre.Name).ToList();    
        }

        public bool SaveGenre(lwg_Genre p)
        {
            if (p != null)
            {
                if (p.GerneId > 0)
                {
                    lwg_Genre c = dbContext.lwg_Genre.SingleOrDefault(ht => ht.GerneId == p.GerneId);
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
                    if (dbContext.lwg_Genre.Count() > 0)
                    {
                        p.GerneId = dbContext.lwg_Genre.OrderByDescending(pe => pe.GerneId).First().GerneId + 1;
                    }
                    else
                    {
                        p.GerneId = 1;
                    }
                    dbContext.lwg_Genre.Add(p);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_Genre GetByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_Genre.SingleOrDefault(h => h.GerneId == id);
            }
            return null;
        }

        public bool DeleteGenre(lwg_Genre p)
        {
            if (p != null)
            {
                List<lwg_CatalogGenre> lst = dbContext.lwg_CatalogGenre.Where(cg => cg.GerneId == p.GerneId).ToList();
                if (lst != null && lst.Count > 0)
                {
                    dbContext.lwg_CatalogGenre.RemoveRange(lst);
                }
                dbContext.lwg_Genre.Remove(p);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCatalogGenre(int genreID, int productID)
        {
            if (genreID > 0 && productID > 0)
            {
                lwg_CatalogGenre lwg = dbContext.lwg_CatalogGenre.SingleOrDefault(p=>p.GerneId==genreID && p.CatalogId==productID);
                if (lwg != null)
                {
                    dbContext.lwg_CatalogGenre.Remove(lwg);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool CheckAndInsertGenre(string genreName, int catalogID)
        {
            lwg_Genre lwg = dbContext.lwg_Genre.SingleOrDefault(o => o.Name.ToLower().Equals(genreName.ToLower()));
            if (lwg == null)
            {
                lwg = new lwg_Genre();
                lwg.Name = genreName;
                SaveGenre(lwg);
            }
            if (!dbContext.lwg_CatalogGenre.Any(o => o.CatalogId == catalogID && o.GerneId == lwg.GerneId))
            {
                lwg_CatalogGenre catalogGenre = new lwg_CatalogGenre();
                catalogGenre.CatalogId = catalogID;
                catalogGenre.GerneId = lwg.GerneId;
                dbContext.lwg_CatalogGenre.Add(catalogGenre);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
