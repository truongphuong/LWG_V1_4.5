using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class ShippingConvertionBiz : BaseBiz
    {
        public ShippingConvertionBiz()
            : base()
        {
        }

        public int AddConvertion(int priceFrom,int priceTo, int chargeWeight, ShippingConvertionType type)
        {
            try
            { 
                lwg_ShippingConvertionConfig config = new lwg_ShippingConvertionConfig();
                config.PriceFrom = priceFrom;
                config.PriceTo = priceTo;
                config.Type = type.ToString();
                config.ChargeWeight = chargeWeight;

                dbContext.lwg_ShippingConvertionConfig.Add(config);                

                dbContext.SaveChanges();

                return config.ID; ;
            }
            catch (Exception ex)
            {
                LWGLog.WriteLog("Add Shipping Convertion Config", ex.ToString());
                
                return 0;
            }
        }

        private int GetMaxPriceToIsSmallerByPrice(int price)
        {
            int? maxpriceto = dbContext.lwg_ShippingConvertionConfig.Where(c => c.PriceTo < price).Max(c => c.PriceTo);
            if (maxpriceto == null)
                maxpriceto = 0;
            return maxpriceto.Value;
        }

        private int GetMinPriceFromIsLargerByPrice(int price)
        {
            int? minpricefrom = dbContext.lwg_ShippingConvertionConfig.Where(c => c.PriceFrom > price).Min(c => c.PriceFrom);
            if (minpricefrom == null)
                minpricefrom = Int32.MaxValue;
            return minpricefrom.Value;
        }
        public bool UpdateConvertion(int convertionID, int priceFrom, int priceTo, int chargeWeight, ShippingConvertionType type)
        {
            try
            {
                lwg_ShippingConvertionConfig config = dbContext.lwg_ShippingConvertionConfig.Where(c => c.ID == convertionID).FirstOrDefault();
                if (config != null)
                {
                    config.PriceFrom = priceFrom;
                    config.PriceTo = priceTo;
                    config.ChargeWeight = chargeWeight;
                    config.Type = type.ToString();

                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LWGLog.WriteLog("Update Shipping Convertion", ex.ToString());
                return false;
            }
        }

        public bool DeleteConvertion(int convertionID)
        {
            try
            {
                lwg_ShippingConvertionConfig config = dbContext.lwg_ShippingConvertionConfig.Where(c => c.ID == convertionID).FirstOrDefault();
                if (config != null)
                {
                    dbContext.lwg_ShippingConvertionConfig.Remove(config);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                LWGLog.WriteLog("Delete Shipping Convertion", ex.ToString());
                return false;
            }

        }

        public List<lwg_ShippingConvertionConfig> GetAllConvertionByType(ShippingConvertionType type)
        {
            return dbContext.lwg_ShippingConvertionConfig.Where(c => c.Type == type.ToString()).OrderBy(c=>c.PriceFrom).ThenBy(c=>c.PriceTo).ThenBy(c=>c.ChargeWeight).ThenBy(c=>c.ID).ToList();
        }

        public int GetWeightFromTotalPrice(decimal total,ShippingConvertionType type)
        {
            lwg_ShippingConvertionConfig config = null;
            if (dbContext.lwg_ShippingConvertionConfig.Any(c => total > c.PriceFrom && total <= c.PriceTo && c.Type == type.ToString()))
                config = dbContext.lwg_ShippingConvertionConfig.Where(c => c.PriceFrom < total && c.PriceTo >= total && c.Type == type.ToString()).FirstOrDefault();
            else
                if (dbContext.lwg_ShippingConvertionConfig.Any(c => total > c.PriceFrom && c.PriceTo == Int32.MaxValue && c.Type == type.ToString()))
                    config = dbContext.lwg_ShippingConvertionConfig.Where(c => c.PriceTo <= total && c.PriceFrom == Int32.MaxValue && c.Type == type.ToString()).FirstOrDefault();
                else
                    if (dbContext.lwg_ShippingConvertionConfig.Any(c => total < c.PriceTo && c.PriceFrom == 0 && c.Type == type.ToString()))
                        config = dbContext.lwg_ShippingConvertionConfig.Where(c => c.PriceTo <= total && c.PriceFrom == Int32.MaxValue && c.Type == type.ToString()).FirstOrDefault();
            if (config == null)
                return 0;

            return config.ChargeWeight;

        }
    }

    public enum ShippingConvertionType
    {
        UPS, USPS, DHL
    }
}
