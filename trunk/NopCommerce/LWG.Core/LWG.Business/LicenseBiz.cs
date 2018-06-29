using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class LicenseBiz
    {
        private LudwigContext context;

        public LicenseBiz()
        {
            context = new LudwigContext();
        }

        public bool InsertLicense(lwg_LicenseForm license)
        {
            if (license == null) return false;

            try
            {
                license.CreatedDate = DateTime.Now;
                context.lwg_LicenseForm.Add(license);
                context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public List<lwg_LicenseForm> GetAllLicense()
        {
            return context.lwg_LicenseForm.Where(lwg=>lwg.IsDelete==false).ToList();
        }

        public lwg_LicenseForm GetById(int id)
        {
            return context.lwg_LicenseForm.SingleOrDefault(f => f.LicenseID == id && f.IsDelete==false);
        }

        public List<lwg_LicenseForm> Search(DateTime from, DateTime to, int type)
        {
            if (type == 0)
            {
                return context.lwg_LicenseForm.Where(l =>l.IsDelete==false && l.CreatedDate >= from && l.CreatedDate <= to).ToList();
            }
            else
            {
                return context.lwg_LicenseForm.Where(l =>l.IsDelete==false && l.CreatedDate >= from && l.CreatedDate <= to && l.LicenseType == type).ToList();
            }
        }

        public static string GetLicenseType(int type)
        {
            switch (type)
            {
                case 1:
                    return "Record";
                case 2:
                    return "Videotape";
                case 3:
                    return "Arrange";
                case 4:
                    return "Sublicense";
                case 5:
                    return "Copy Emergency";
                case 6:
                    return "Scores/Parts";
                default:
                    return string.Empty;
            }
        }

        public bool DeleteLiscense(int id)
        { 
            if(id >0)
            {
                lwg_LicenseForm lwg = context.lwg_LicenseForm.SingleOrDefault(lg => lg.IsDelete == false && lg.LicenseID == id);
                if (lwg != null)
                {
                    lwg.IsDelete = true;                    
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }

    public enum LicenseType : int
    {
        Record = 1,
        VideoTape,
        Arrange,
        Sublicense,
        CopyEmergency,
        ScoresParts
    }
}
