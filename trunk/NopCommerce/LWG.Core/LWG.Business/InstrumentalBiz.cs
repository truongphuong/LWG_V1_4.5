using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class InstrumentalBiz
    {
        private LudwigContext dbContext;

        public InstrumentalBiz()
        {
            dbContext = new LudwigContext();
        }

        public List<lwg_Instrumental> GetListInstrumental()
        {
            return dbContext.lwg_Instrumental.OrderBy(i => i.ShortName).ToList();
        }

        public bool SaveInstrumental(lwg_Instrumental i)
        {
            if (i != null)
            {
                if (i.InstrumentalId > 0)
                {
                    lwg_Instrumental c = dbContext.lwg_Instrumental.SingleOrDefault(it => it.InstrumentalId == i.InstrumentalId);
                    if (c != null)
                    {
                        c.LongName = i.LongName;
                        c.ShortName = i.ShortName;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dbContext.lwg_Instrumental.Count() > 0)
                    {
                        i.InstrumentalId = dbContext.lwg_Instrumental.OrderByDescending(pe => pe.InstrumentalId).First().InstrumentalId + 1;
                    }
                    else
                    {
                        i.InstrumentalId = 1;
                    }
                    dbContext.lwg_Instrumental.Add(i);
                }
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public lwg_Instrumental GetByID(int id)
        {
            if (id > 0)
            {
                return dbContext.lwg_Instrumental.SingleOrDefault(h => h.InstrumentalId == id);
            }
            return null;
        }

        public bool DeleteInstrumental(lwg_Instrumental i)
        {
            if (i != null)
            {
                if (!dbContext.lwg_Catalog.Any(cl => cl.InstrumentalId == i.InstrumentalId))
                {
                    dbContext.lwg_Instrumental.Remove(i);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public int CheckAndInsertInstrumental(string instrumentalName)
        {
            try
            {
                lwg_Instrumental lwg = dbContext.lwg_Instrumental.SingleOrDefault(o => o.ShortName.ToLower().Equals(instrumentalName.ToLower()));
                if (lwg == null)
                {
                    lwg = new lwg_Instrumental();
                    lwg.ShortName = instrumentalName;
                    lwg.LongName = instrumentalName;
                    SaveInstrumental(lwg);
                }
                return lwg.InstrumentalId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
