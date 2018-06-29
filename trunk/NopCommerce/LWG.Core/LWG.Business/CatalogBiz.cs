using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class CatalogBiz
    {
        private LudwigContext dbContext;

        public CatalogBiz()
        {
            dbContext = new LudwigContext();
        }

        public List<lwg_Catalog> GetListCatalogs(int take, int skip, bool IsDelete, ref int total)
        {
            var query = dbContext.lwg_Catalog.OrderByDescending(t => t.CatalogId);
            total = query.Count();
            return query.Take(take).Skip(skip).ToList();
        }

        public List<lwg_Catalog> GetAllCatalog(ref int total)
        {
            var query = dbContext.lwg_Catalog.OrderByDescending(t => t.CatalogId);
            total = query.Count();
            return query.Take(total).ToList();
        }

        public List<lwg_Catalog> GetRecentCatalog(int number) 
        {
            var query = dbContext.lwg_Catalog.OrderByDescending(c => c.CatalogId);
            return query.Take(number).ToList();
        }

        public int GetTotalCatalogOfGenre(int genreID) 
        {
            return dbContext.lwg_CatalogGenre.Count(cg => cg.GerneId == genreID);
        }

        public bool SaveCatalog(lwg_Catalog c)
        {
            try
            {
                if (c != null)
                {
                    if (dbContext.lwg_Catalog.Any(ct => ct.CatalogId == c.CatalogId))
                    {
                        lwg_Catalog h = dbContext.lwg_Catalog.SingleOrDefault(ht => ht.CatalogId == c.CatalogId);
                        if (h != null)
                        {
                            //TODO: all file catalog
                            c.ArrangerGroupId = h.ArrangerGroupId;  // allow null
                            c.Blurb = h.Blurb;
                            //p.CatalogId // increase by code
                            c.CatalogNumber = h.CatalogNumber;
                            c.Duration = h.Duration;
                            c.Format1 = h.Format1;
                            c.Format10 = h.Format10;
                            c.Format2 = h.Format2;
                            c.Format3 = h.Format3;
                            c.Format4 = h.Format4;
                            c.Format5 = h.Format5;
                            c.Format6 = h.Format6;
                            c.Format7 = h.Format7;
                            c.Format8 = h.Format8;
                            c.Format9 = h.Format9;
                            c.FSCprodcode = h.FSCprodcode;
                            c.Grade = h.Grade; // type : byte ?
                            c.InstrumentalId = h.InstrumentalId;

                            c.KaldbNumber = h.KaldbNumber;
                            c.pages = h.pages;
                            c.PDF = h.PDF;
                            c.PeriodId = h.PeriodId;
                            c.Price1 = h.Price1;  // allow null
                            c.Price2 = h.Price2;  // allow null
                            c.Price3 = h.Price3;  // allow null
                            c.Price4 = h.Price4;  // allow null
                            c.Price5 = h.Price5;  // allow null
                            c.Price6 = h.Price6;  // allow null
                            c.Price7 = h.Price7;  // allow null
                            c.Price8 = h.Price8;  // allow null
                            c.Price9 = h.Price9;  // allow null
                            c.Price10 = h.Price10;  // allow null

                            c.PTSprodcode = h.PTSprodcode;
                            c.QTFile1 = h.QTFile1;
                            c.QTFile2 = h.QTFile2;
                            c.QTFile3 = h.QTFile3;
                            c.QTFile4 = h.QTFile4;
                            c.QTFile5 = h.QTFile5;
                            c.QTFile6 = h.QTFile6;
                            c.QTFile7 = h.QTFile7;
                            c.QTFile8 = h.QTFile8;
                            c.QTFile9 = h.QTFile9;
                            c.QTFile10 = h.QTFile10;
                            c.QTFile11 = h.QTFile11;
                            c.recid = h.recid; // what's recid ?
                            c.ReprintSourceId = h.ReprintSourceId;

                            c.S4MasterSeries = h.S4MasterSeries;
                            c.S5MasterCategories = h.S5MasterCategories;
                            c.SeriesId = h.SeriesId;

                            c.SoundFile1 = h.SoundFile1;
                            c.SoundFile2 = h.SoundFile2;
                            c.SoundFile3 = h.SoundFile3;
                            c.SoundFile4 = h.SoundFile4;
                            c.SoundFile5 = h.SoundFile5;
                            c.SoundFile6 = h.SoundFile6;
                            c.SoundFile7 = h.SoundFile7;
                            c.SoundFile8 = h.SoundFile8;
                            c.SoundFile9 = h.SoundFile9;
                            c.SoundFile10 = h.SoundFile10;
                            c.SoundFile11 = h.SoundFile11;
                            c.SoundFile12 = h.SoundFile12;
                            c.SoundFile13 = h.SoundFile13;
                            c.SoundFile14 = h.SoundFile14;
                            c.SoundFile15 = h.SoundFile15;
                            c.SoundIcon = h.SoundIcon;
                            c.Subtitle = h.Subtitle;
                            c.TextLang = h.TextLang;
                            c.TitleDisplay = h.TitleDisplay;
                            c.TitleList = h.TitleList;
                            c.TitleSort = h.TitleSort;
                            c.Track01 = h.Track01;
                            c.Track02 = h.Track02;
                            c.Track03 = h.Track03;
                            c.Track04 = h.Track04;
                            c.Track05 = h.Track05;
                            c.Track06 = h.Track06;
                            c.Track07 = h.Track07;
                            c.Track08 = h.Track08;
                            c.Track09 = h.Track09;
                            c.Track10 = h.Track10;
                            c.Xform1 = h.Xform1;
                            c.Xform2 = h.Xform2;
                            c.Xform3 = h.Xform3;
                            c.Xform4 = h.Xform4;
                            c.Xform5 = h.Xform5;
                            
                            c.InstrDetail = h.InstrDetail;
                            c.VocAccomp = h.VocAccomp;

                            c.Year = h.Year;
                            c.CopyrightYear = h.CopyrightYear;
                            c.TableofContents = h.TableofContents;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        dbContext.lwg_Catalog.Add(c);
                    }
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }

        public bool DeleteCatalog(lwg_Catalog h)
        {
            if (h != null)
            {
                if (h.CatalogId > 0)
                {
                    //Delete catalogTitle
                    List<lwg_CatalogTitle> lstTitle = dbContext.lwg_CatalogTitle.Where(t => t.CatalogId == h.CatalogId).ToList();
                    dbContext.lwg_CatalogTitle.RemoveRange(lstTitle);
                    //Delete CatalogInstrumentSearch
                    List<lwg_CatalogInstrumentSearch> lstInstrumentSearch = dbContext.lwg_CatalogInstrumentSearch.Where(s => s.CatalogId == h.CatalogId).ToList();
                    dbContext.lwg_CatalogInstrumentSearch.RemoveRange(lstInstrumentSearch);
                    // Delete CatalogPublisher
                    List<lwg_CatalogPublisher> lstCP = dbContext.lwg_CatalogPublisher.Where(cp => cp.CatalogId == h.CatalogId).ToList();
                    dbContext.lwg_CatalogPublisher.RemoveRange(lstCP);
                    //Delete CatalogCategory
                    //List<lwg_CatalogCategory> lstCC = dbContext.CatalogCategories.Where(cc => cc.CatalogId == h.CatalogId).ToList();
                    //dbContext.lwg_CatalogCategories.DeleteAllOnSubmit(lstCC);
                    //Delete CatalogNameSearch
                    List<lwg_CatalogNameSearch> lstNameSearch = dbContext.lwg_CatalogNameSearch.Where(cn => cn.CatalogId == h.CatalogId).ToList();
                    dbContext.lwg_CatalogNameSearch.RemoveRange(lstNameSearch);
                    //Delete CatalogTitleSearch
                    List<lwg_CatalogTitleSearch> lstTitleSearch = dbContext.lwg_CatalogTitleSearch.Where(cts => cts.CatalogId == h.CatalogId).ToList();
                    dbContext.lwg_CatalogTitleSearch.RemoveRange(lstTitleSearch);
                    //Delete CatalogGenre
                    List<lwg_CatalogGenre> lstGenre = dbContext.lwg_CatalogGenre.Where(cg => cg.CatalogId == h.CatalogId).ToList();
                    dbContext.lwg_CatalogGenre.RemoveRange(lstGenre);
                    //Delete catalogPeople
                    List<lwg_PersonInRole> lstPersonInRole = dbContext.lwg_PersonInRole.Where(cp => cp.CatalogId == h.CatalogId).ToList();
                    dbContext.lwg_PersonInRole.RemoveRange(lstPersonInRole);
                    //Delete CatalogComposer
                    //List<lwg_CatalogComposer> lstComposer = dbContext.lwg_CatalogComposers.Where(cp => cp.CatalogId == h.CatalogId).ToList();
                    //dbContext.lwg_CatalogComposers.DeleteAllOnSubmit(lstComposer);
                    //Delete Catalog
                    
                    // delete period
                    new PeriodBiz().DeletePeriodMappingBuyID(h.CatalogId);
                    // delete ReprintSource
                    new ReprintSourceBiz().DeleteReprintSourceMappingByID(h.CatalogId);
                    // delete Series
                    new SeriesBiz().DeleteSeriesMappingByID(h.CatalogId);
                    // delete audio
                    new AudioBiz().DeleteAudiosById(h.CatalogId);
                    // delete video 
                    new VideoBiz().DeleteVideosById(h.CatalogId);
                    dbContext.lwg_Catalog.Remove(h);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public lwg_Catalog GetByID(long catalogID)
        {
            if (catalogID > 0)
            {
                return dbContext.lwg_Catalog.SingleOrDefault(h => h.CatalogId == catalogID);
            }
            return null;
        }

        public bool DeleteCatalogTitle(int instrTitleID, int catalogID)
        {
            if (instrTitleID > 0 && catalogID > 0)
            {
                lwg_CatalogTitle lwg = dbContext.lwg_CatalogTitle.SingleOrDefault(p => p.InstrTitleId == instrTitleID && p.CatalogId==catalogID);
                if (lwg != null)
                {
                    dbContext.lwg_CatalogTitle.Remove(lwg);
                    dbContext.SaveChanges();
                    return true;
                }                
            }
            return false;
        }

        #region SaveCatalog extend

        public bool SaveCatalogInstrumentalSearch(lwg_CatalogInstrumentSearch lwg)
        {
            if (lwg != null && lwg.CatalogId > 0 && !string.IsNullOrEmpty(lwg.IntrText))
            {
                if (dbContext.lwg_CatalogInstrumentSearch.Any(lc => lc.CatalogId == lwg.CatalogId))
                {
                    lwg_CatalogInstrumentSearch cis = dbContext.lwg_CatalogInstrumentSearch.Where(lc => lc.CatalogId == lwg.CatalogId).FirstOrDefault();
                    cis.IntrText = lwg.IntrText;                   
                }
                else
                {
                    lwg_CatalogInstrumentSearch cis = new lwg_CatalogInstrumentSearch();
                    if (dbContext.lwg_CatalogInstrumentSearch.Count() > 0)
                    {
                        cis.Id = dbContext.lwg_CatalogInstrumentSearch.OrderByDescending(lc => lc.Id).First().Id + 1;
                    }
                    else
                    {
                        cis.Id = 1;
                    }                    
                    cis.CatalogId = lwg.CatalogId;
                    cis.IntrText = lwg.IntrText;
                    dbContext.lwg_CatalogInstrumentSearch.Add(cis);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCatalogInstrumentalSearch(int id)
        {
            lwg_CatalogInstrumentSearch cis = dbContext.lwg_CatalogInstrumentSearch.SingleOrDefault(c => c.Id == id);
            if (cis != null)
            {
                dbContext.lwg_CatalogInstrumentSearch.Remove(cis);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SaveCatalogTitleSearch(lwg_CatalogTitleSearch lwg)
        {
            if (lwg!=null &&lwg.CatalogId > 0 && !string.IsNullOrEmpty(lwg.Title))
            {
                if (dbContext.lwg_CatalogTitleSearch.Any(lc => lc.CatalogId == lwg.CatalogId))
                {
                    lwg_CatalogTitleSearch cis = dbContext.lwg_CatalogTitleSearch.Where(lc => lc.CatalogId == lwg.CatalogId).FirstOrDefault();
                    cis.Title = lwg.Title;                    
                }
                else
                {
                    lwg_CatalogTitleSearch cis = new lwg_CatalogTitleSearch();
                    if (dbContext.lwg_CatalogTitleSearch.Count() > 0)
                    {
                        cis.Id = dbContext.lwg_CatalogTitleSearch.OrderByDescending(lc => lc.Id).First().Id + 1;
                    }
                    else
                    {
                        cis.Id = 1;
                    }
                    cis.CatalogId = lwg.CatalogId;
                    cis.Title = lwg.Title;
                    dbContext.lwg_CatalogTitleSearch.Add(cis);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteCatalogTitleSearch(int id)
        {
            lwg_CatalogTitleSearch cis = dbContext.lwg_CatalogTitleSearch.SingleOrDefault(c => c.Id == id);
            if (cis != null)
            {
                dbContext.lwg_CatalogTitleSearch.Remove(cis);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SaveCatalogTitle(int catalogID, int instrTitleID)
        {
            if (catalogID > 0 && instrTitleID > 0)
            {
                //List<lwg_CatalogTitle> lst = dbContext.lwg_CatalogTitles.Where(lg => lg.CatalogId == catalogID).ToList();
                //dbContext.lwg_CatalogTitles.DeleteAllOnSubmit(lst);
                if (!dbContext.lwg_CatalogTitle.Any(p => p.CatalogId == catalogID && p.InstrTitleId == instrTitleID))
                {
                    lwg_CatalogTitle ct = new lwg_CatalogTitle();
                    ct.CatalogId = catalogID;
                    ct.InstrTitleId = instrTitleID;
                    dbContext.lwg_CatalogTitle.Add(ct);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool SaveCatalogNameSearch(lwg_CatalogNameSearch lwg)
        {
            if (lwg !=null && lwg.CatalogId> 0 && !string.IsNullOrEmpty(lwg.Name))
            {
                if (dbContext.lwg_CatalogNameSearch.Any(lc => lc.CatalogId ==lwg.CatalogId))
                {
                    lwg_CatalogNameSearch cns = dbContext.lwg_CatalogNameSearch.Where(lc => lc.CatalogId ==lwg.CatalogId).FirstOrDefault();
                    cns.Name = lwg.Name;                     
                }
                else
                {
                    lwg_CatalogNameSearch cns = new lwg_CatalogNameSearch();
                    if (dbContext.lwg_CatalogNameSearch.Count() > 0)
                    {
                        cns.Id = dbContext.lwg_CatalogNameSearch.OrderByDescending(lc => lc.Id).First().Id + 1;
                    }
                    else
                    {
                        cns.Id = 1;
                    }
                    cns.CatalogId = lwg.CatalogId;
                    cns.Name = lwg.Name;
                    dbContext.lwg_CatalogNameSearch.Add(cns);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool SaveCatalogGenre(int catalogID, int genreID)
        {
            if (catalogID > 0 && genreID > 0)
            {
                //List<lwg_CatalogGenre> lst = dbContext.lwg_CatalogGenres.Where(lg => lg.CatalogId == catalogID).ToList();
                //dbContext.lwg_CatalogGenres.DeleteAllOnSubmit(lst);
                if (!dbContext.lwg_CatalogGenre.Any(p => p.CatalogId == catalogID && p.GerneId == genreID))
                {
                    lwg_CatalogGenre cg = new lwg_CatalogGenre();
                    cg.CatalogId = catalogID;
                    cg.GerneId = genreID;
                    dbContext.lwg_CatalogGenre.Add(cg);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool SaveCatalogPublisher(int catalogID, int publisherID)
        {
            if (catalogID > 0 && publisherID > 0)
            {
                List<lwg_CatalogPublisher> lst = dbContext.lwg_CatalogPublisher.Where(lg => lg.CatalogId == catalogID).ToList();
                dbContext.lwg_CatalogPublisher.RemoveRange(lst);
                lwg_CatalogPublisher cp = new lwg_CatalogPublisher();
                cp.CatalogId = catalogID;
                cp.PublisherId = publisherID;
                dbContext.lwg_CatalogPublisher.Add(cp);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public string GetNameSearchByCatalogID(int catalogID)
        {
            lwg_CatalogNameSearch lg = dbContext.lwg_CatalogNameSearch.Where(lw => lw.CatalogId == catalogID).FirstOrDefault();
            if (lg != null)
            {
                return lg.Name;
            }
            return string.Empty;
        }

        public string GetTitleSearchByCatalogID(int catalogID)
        {
            lwg_CatalogTitleSearch lg = dbContext.lwg_CatalogTitleSearch.Where(lw => lw.CatalogId == catalogID).FirstOrDefault();
            if (lg != null)
            {
                return lg.Title;
            }
            return string.Empty;
        }

        public string GetInstrSearchByCatalogID(int catalogID)
        {
            lwg_CatalogInstrumentSearch lg = dbContext.lwg_CatalogInstrumentSearch.Where(lw => lw.CatalogId == catalogID).FirstOrDefault();
            if (lg != null)
            {
                return lg.IntrText;
            }
            return string.Empty;
        }

        public int GetGenreIdByCatalogID(int catalogID)
        {
            lwg_CatalogGenre lg = dbContext.lwg_CatalogGenre.Where(lwg => lwg.CatalogId == catalogID).FirstOrDefault();
            if (lg != null)
            {
                return lg.GerneId;
            }
            return 0;
        }

        public int GetPublisherIDByCatalogID(int catalogID)
        {
            lwg_CatalogPublisher lg = dbContext.lwg_CatalogPublisher.Where(lwg => lwg.CatalogId == catalogID).FirstOrDefault();
            if (lg != null)
            {
                return lg.PublisherId;
            }
            return 0;
        }

        public int GetInstrTitleIDByCatalogID(int catalogID)
        {
            lwg_CatalogTitle lg = dbContext.lwg_CatalogTitle.Where(lwg => lwg.CatalogId == catalogID).FirstOrDefault();
            if (lg != null)
            {
                return lg.InstrTitleId;
            }
            return 0;
        }
        #endregion

        public List<lwg_Catalog> GetListLWGCatalog(string catNo  )
        {
            if ( !string.IsNullOrEmpty(catNo))
            {
              return dbContext.lwg_Catalog.Where(o => o.CatalogNumber.Trim().ToUpper().Equals(catNo.Trim().ToUpper())).ToList();
            }
            return null;
        }
    }
}
