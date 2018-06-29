using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class InstrTitleBiz
    {
        private LudwigContext context;

        public InstrTitleBiz()
        {
            context = new LudwigContext();
        }

        public List<lwg_InstrTitle> GetTitleByType(TitleType type)
        {
            return context.lwg_InstrTitle.Where(i => i.TitleTypeId == (int)type).ToList();
        }

        public bool CheckAndInsertInstrTitle(string titleName, int catalogID, int titleTypeID)
        {
            try
            {
                lwg_InstrTitle lwg = context.lwg_InstrTitle.SingleOrDefault(o => o.Name.ToLower().Equals(titleName.ToLower()) && o.TitleTypeId == titleTypeID);
                if (lwg == null)
                {
                    lwg = new lwg_InstrTitle();
                    lwg.TitleTypeId = titleTypeID;
                    lwg.Name = titleName;
                    CatalogTitleTypeBiz cBiz = new CatalogTitleTypeBiz();
                    cBiz.SaveInstrTitle(lwg);
                }
                if (!context.lwg_CatalogTitle.Any(o => o.CatalogId == catalogID && o.InstrTitleId == lwg.Id))
                {
                    lwg_CatalogTitle catalogTitle = new lwg_CatalogTitle();
                    catalogTitle.CatalogId = catalogID;
                    catalogTitle.InstrTitleId = lwg.Id;
                    context.lwg_CatalogTitle.Add(catalogTitle);
                    context.SaveChanges();                    
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    public enum TitleType
    {
        KEYBOARD = 1,
        STRING,
        WOODWIND,
        BRASS,
        PERCUSSION,
        CHAMBER,
        LARGE,
        BANDWIND,
        VOCAL_CHORAL
    }
}
