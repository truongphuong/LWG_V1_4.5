using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Business;
using LWG.Core;
using LWG.Core.Models;

namespace LWG.Business
{
    public class CatalogTitleTypeBiz
    {
        private LudwigContext dbContext;

        public CatalogTitleTypeBiz()
        {
            dbContext = new LudwigContext();
        }

        #region Title Type
        public List<lwg_TitleType> GetListTitleType()
        {
            return dbContext.lwg_TitleType.OrderBy(p => p.Name).ToList();
        }

        public bool SaveTitleType(lwg_TitleType p)
        {
            if (p != null)
            {
                if (p.Id > 0)
                {
                    lwg_TitleType c = dbContext.lwg_TitleType.SingleOrDefault(ht => ht.Id == p.Id);
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
                    if (dbContext.lwg_TitleType.Count() > 0)
                    {
                        p.Id = dbContext.lwg_TitleType.OrderByDescending(pe => pe.Id).First().Id + 1;
                    }
                    else
                    {
                        p.Id = 1;
                    }
                    dbContext.lwg_TitleType.Add(p);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_TitleType GetTitleTypeByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_TitleType.SingleOrDefault(h => h.Id == id);
            }
            return null;
        }

        public bool DeleteTitleType(lwg_TitleType p)
        {
            if (p != null)
            {
                // must have delete instrTitle after delete TitleType
                if (!dbContext.lwg_InstrTitle.Any(it=>it.TitleTypeId == p.Id))
                {
                    dbContext.lwg_TitleType.Remove(p);
                    dbContext.SaveChanges();
                    return true;
                }                
            }
            return false;
        }
        #endregion 

        #region  InstrumentalTitle
        public List<lwg_InstrTitle> GetListInstrTitle()
        {
            return dbContext.lwg_InstrTitle.OrderBy(p => p.Name).OrderBy(p=>p.lwg_TitleType.Name).ToList();
        }

        public List<lwg_InstrTitle> GetListInstrTitle(int titleTypeID)
        {
            if (titleTypeID > 0)
            {
                return dbContext.lwg_InstrTitle.Where(lw => lw.TitleTypeId == titleTypeID).OrderByDescending(p => p.Id).ToList();
            }
            return null;
        }

        public bool SaveInstrTitle(lwg_InstrTitle p)
        {
            if (p != null)
            {
                if (p.Id > 0)
                {
                    lwg_InstrTitle c = dbContext.lwg_InstrTitle.SingleOrDefault(ht => ht.Id == p.Id);
                    if (c != null)
                    {
                        c.Name = p.Name;
                        c.TitleTypeId = p.TitleTypeId;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dbContext.lwg_InstrTitle.Count() > 0)
                    {
                        p.Id = dbContext.lwg_InstrTitle.OrderByDescending(pe => pe.Id).First().Id + 1;
                    }
                    else
                    {
                        p.Id = 1;
                    }
                    dbContext.lwg_InstrTitle.Add(p);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_InstrTitle GetInstrTitleByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_InstrTitle.SingleOrDefault(h => h.Id == id);
            }
            return null;
        }

        public bool DeleteInstrTitle(lwg_InstrTitle p)
        {
            if (p != null)
            {
                List<lwg_CatalogTitle> lst = dbContext.lwg_CatalogTitle.Where(cg => cg.InstrTitleId == p.Id).ToList();
                if (lst != null && lst.Count > 0)
                {
                    dbContext.lwg_CatalogTitle.RemoveRange(lst);
                }
                dbContext.lwg_InstrTitle.Remove(p);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        public List<lwg_CatalogTitle> GetListCatalogTitleByCatalogID(int catalogID)
        {
            if (catalogID > 0)
            {
                return dbContext.lwg_CatalogTitle.Where(p => p.CatalogId == catalogID).OrderBy(p=>p.lwg_InstrTitle.Name).OrderBy(p=>p.lwg_InstrTitle.lwg_TitleType.Name).ToList();
            }
            return null;
        }
    }
}
