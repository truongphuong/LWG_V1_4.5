//------------------------------------------------------------------------------
// The contents of this file are subject to the nopCommerce Public License Version 1.0 ("License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at  http://www.nopCommerce.com/License.aspx. 
// 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. 
// See the License for the specific language governing rights and limitations under the License.
// 
// The Original Code is nopCommerce.
// The Initial Developer of the Original Code is NopSolutions.
// All Rights Reserved.
// 
// Contributor(s): _______. 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using NopSolutions.NopCommerce.BusinessLogic.Caching;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.Profile;
using NopSolutions.NopCommerce.Common;
using NopSolutions.NopCommerce.DataAccess;
using NopSolutions.NopCommerce.DataAccess.Promo.Discounts;


namespace NopSolutions.NopCommerce.BusinessLogic.Promo.Discounts
{
    /// <summary>
    /// Discount manager
    /// </summary>
    public partial class DiscountManager
    {
        #region Constants
        private const string DISCOUNTS_ALL_KEY = "Nop.discount.all-{0}-{1}";
        private const string DISCOUNTS_BY_ID_KEY = "Nop.discount.id-{0}";
        private const string DISCOUNTS_BY_PRODUCTVARIANTID_KEY = "Nop.discount.byproductvariantid-{0}-{1}";
        private const string DISCOUNTS_BY_CATEGORYID_KEY = "Nop.discount.bycategoryid-{0}-{1}";
        private const string DISCOUNTTYPES_ALL_KEY = "Nop.discounttype.all";
        private const string DISCOUNTREQUIREMENT_ALL_KEY = "Nop.discountrequirement.all";
        private const string DISCOUNTLIMITATION_ALL_KEY = "Nop.discountlimitation.all";
        private const string DISCOUNTS_PATTERN_KEY = "Nop.discount.";
        private const string DISCOUNTTYPES_PATTERN_KEY = "Nop.discounttype.";
        private const string DISCOUNTREQUIREMENT_PATTERN_KEY = "Nop.discountrequirement.";
        private const string DISCOUNTLIMITATION_PATTERN_KEY = "Nop.discountlimitation.";
        #endregion

        #region Utilities
        private static DiscountCollection DBMapping(DBDiscountCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new DiscountCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static Discount DBMapping(DBDiscount dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new Discount();
            item.DiscountId = dbItem.DiscountId;
            item.DiscountTypeId = dbItem.DiscountTypeId;
            item.DiscountRequirementId = dbItem.DiscountRequirementId;
            item.DiscountLimitationId = dbItem.DiscountLimitationId;
            item.Name = dbItem.Name;
            item.UsePercentage = dbItem.UsePercentage;
            item.DiscountPercentage = dbItem.DiscountPercentage;
            item.DiscountAmount = dbItem.DiscountAmount;
            item.StartDate = dbItem.StartDate;
            item.EndDate = dbItem.EndDate;
            item.RequiresCouponCode = dbItem.RequiresCouponCode;
            item.CouponCode = dbItem.CouponCode;
            item.Deleted = dbItem.Deleted;

            return item;
        }

        private static DiscountRequirementCollection DBMapping(DBDiscountRequirementCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new DiscountRequirementCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static DiscountRequirement DBMapping(DBDiscountRequirement dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new DiscountRequirement();
            item.DiscountRequirementId = dbItem.DiscountRequirementId;
            item.Name = dbItem.Name;

            return item;
        }

        private static DiscountTypeCollection DBMapping(DBDiscountTypeCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new DiscountTypeCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static DiscountType DBMapping(DBDiscountType dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new DiscountType();
            item.DiscountTypeId = dbItem.DiscountTypeId;
            item.Name = dbItem.Name;

            return item;
        }

        private static DiscountLimitationCollection DBMapping(DBDiscountLimitationCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new DiscountLimitationCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static DiscountLimitation DBMapping(DBDiscountLimitation dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new DiscountLimitation();
            item.DiscountLimitationId = dbItem.DiscountLimitationId;
            item.Name = dbItem.Name;

            return item;
        }

        private static DiscountUsageHistoryCollection DBMapping(DBDiscountUsageHistoryCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new DiscountUsageHistoryCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static DiscountUsageHistory DBMapping(DBDiscountUsageHistory dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new DiscountUsageHistory();
            item.DiscountUsageHistoryId = dbItem.DiscountUsageHistoryId;
            item.DiscountId = dbItem.DiscountId;
            item.CustomerId = dbItem.CustomerId;
            item.OrderId = dbItem.OrderId;
            item.CreatedOn = dbItem.CreatedOn;

            return item;
        }
        #endregion

        #region Methods

        #region Discounts

        /// <summary>
        /// Gets a preferred discount
        /// </summary>
        /// <param name="discounts">Discounts to analyze</param>
        /// <param name="amount">Amount</param>
        /// <returns>Preferred discount</returns>
        public static Discount GetPreferredDiscount(DiscountCollection discounts, 
            decimal amount)
        {
            Discount preferredDiscount = null;
            decimal maximumDiscountValue = decimal.Zero;
            foreach (var _discount in discounts)
            {
                decimal currentDiscountValue = _discount.GetDiscountAmount(amount);
                if (currentDiscountValue > maximumDiscountValue)
                {
                    maximumDiscountValue = currentDiscountValue;
                    preferredDiscount = _discount;
                }
            }

            return preferredDiscount;
        }

        /// <summary>
        /// Gets a discount
        /// </summary>
        /// <param name="discountId">Discount identifier</param>
        /// <returns>Discount</returns>
        public static Discount GetDiscountById(int discountId)
        {
            if (discountId == 0)
                return null;

            string key = string.Format(DISCOUNTS_BY_ID_KEY, discountId);
            object obj2 = NopCache.Get(key);
            if (DiscountManager.CacheEnabled && (obj2 != null))
            {
                return (Discount)obj2;
            }

            var dbItem = DBProviderManager<DBDiscountProvider>.Provider.GetDiscountById(discountId);
            var discount = DBMapping(dbItem);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.Max(key, discount);
            }
            return discount;
        }

        /// <summary>
        /// Marks discount as deleted
        /// </summary>
        /// <param name="discountId">Discount identifier</param>
        public static void MarkDiscountAsDeleted(int discountId)
        {
            Discount discount = GetDiscountById(discountId);
            if (discount != null)
            {
                UpdateDiscount(discount.DiscountId, discount.DiscountType, 
                    discount.DiscountRequirement, discount.DiscountLimitation,
                    discount.Name, discount.UsePercentage, discount.DiscountPercentage,
                    discount.DiscountAmount, discount.StartDate,
                    discount.EndDate, discount.RequiresCouponCode,
                    discount.CouponCode, true);
            }
        }

        /// <summary>
        /// Get a value indicating whether discounts that require coupon code exist
        /// </summary>
        /// <returns>A value indicating whether discounts that require coupon code exist</returns>
        public static bool HasDiscountsWithCouponCode()
        {
            var discounts = GetAllDiscounts(null);
            return discounts.Find(d => d.RequiresCouponCode) != null;
        }

        /// <summary>
        /// Gets all discounts
        /// </summary>
        /// <param name="discountType">Discount type; null to load all discount</param>
        /// <returns>Discount collection</returns>
        public static DiscountCollection GetAllDiscounts(DiscountTypeEnum? discountType)
        {
            bool showHidden = NopContext.Current.IsAdmin;
            string key = string.Format(DISCOUNTS_ALL_KEY, showHidden, discountType);
            object obj2 = NopCache.Get(key);
            if (DiscountManager.CacheEnabled && (obj2 != null))
            {
                return (DiscountCollection)obj2;
            }

            int? discountTypeId = null;
            if (discountType.HasValue)
                discountTypeId = (int)discountType.Value;

            var dbCollection = DBProviderManager<DBDiscountProvider>.Provider.GetAllDiscounts(showHidden, discountTypeId);
            var discounts = DBMapping(dbCollection);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.Max(key, discounts);
            }
            return discounts;
        }

        /// <summary>
        /// Inserts a discount
        /// </summary>
        /// <param name="discountType">The discount type</param>
        /// <param name="discountRequirement">The discount requirement</param>
        /// <param name="discountLimitation">The discount limitation</param>
        /// <param name="name">The name</param>
        /// <param name="usePercentage">A value indicating whether to use percentage</param>
        /// <param name="discountPercentage">The discount percentage</param>
        /// <param name="discountAmount">The discount amount</param>
        /// <param name="startDate">The discount start date and time</param>
        /// <param name="endDate">The discount end date and time</param>
        /// <param name="requiresCouponCode">The value indicating whether discount requires coupon code</param>
        /// <param name="couponCode">The coupon code</param>
        /// <param name="deleted">A value indicating whether the entity has been deleted</param>
        /// <returns>Discount</returns>
        public static Discount InsertDiscount(DiscountTypeEnum discountType,
            DiscountRequirementEnum discountRequirement,
            DiscountLimitationEnum discountLimitation, string name, bool usePercentage, 
            decimal discountPercentage, decimal discountAmount,
            DateTime startDate, DateTime endDate, bool requiresCouponCode, 
            string couponCode, bool deleted)
        {
            if (startDate.CompareTo(endDate) >= 0)
                throw new NopException("Start date should be less then expiration date");

            if (requiresCouponCode && String.IsNullOrEmpty(couponCode))
            {
                throw new NopException("Discount requires coupon code. Coupon code could not be empty.");
            }

            var dbItem = DBProviderManager<DBDiscountProvider>.Provider.InsertDiscount((int)discountType,
                (int)discountRequirement, (int)discountLimitation, name,
                usePercentage, discountPercentage, discountAmount,
                startDate, endDate, requiresCouponCode, couponCode, deleted);
            var discount = DBMapping(dbItem);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(DISCOUNTS_PATTERN_KEY);
            }
            return discount;
        }

        /// <summary>
        /// Updates the discount
        /// </summary>
        /// <param name="discountId">Discount identifier</param>
        /// <param name="discountType">The discount type</param>
        /// <param name="discountRequirement">The discount requirement</param>
        /// <param name="discountLimitation">The discount limitation</param>
        /// <param name="name">The name</param>
        /// <param name="usePercentage">A value indicating whether to use percentage</param>
        /// <param name="discountPercentage">The discount percentage</param>
        /// <param name="discountAmount">The discount amount</param>
        /// <param name="startDate">The discount start date and time</param>
        /// <param name="endDate">The discount end date and time</param>
        /// <param name="requiresCouponCode">The value indicating whether discount requires coupon code</param>
        /// <param name="couponCode">The coupon code</param>
        /// <param name="deleted">A value indicating whether the entity has been deleted</param>
        /// <returns>Discount</returns>
        public static Discount UpdateDiscount(int discountId, DiscountTypeEnum discountType,
            DiscountRequirementEnum discountRequirement, DiscountLimitationEnum discountLimitation,
            string name, bool usePercentage, decimal discountPercentage, decimal discountAmount,
            DateTime startDate, DateTime endDate, bool requiresCouponCode, 
            string couponCode, bool deleted)
        {
            if (startDate.CompareTo(endDate) >= 0)
                throw new NopException("Start date should be less then expiration date");

            if (requiresCouponCode && String.IsNullOrEmpty(couponCode))
            {
                throw new NopException("Discount requires coupon code. Coupon code could not be empty.");
            }

            var dbItem = DBProviderManager<DBDiscountProvider>.Provider.UpdateDiscount(discountId, (int)discountType,
                (int)discountRequirement, (int)discountLimitation, name, 
                usePercentage, discountPercentage, discountAmount, startDate, endDate,
                requiresCouponCode, couponCode, deleted);
            var discount = DBMapping(dbItem);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(DISCOUNTS_PATTERN_KEY);
            }
            return discount;
        }

        /// <summary>
        /// Adds a discount to a product variant
        /// </summary>
        /// <param name="productVariantId">Product variant identifier</param>
        /// <param name="discountId">Discount identifier</param>
        public static void AddDiscountToProductVariant(int productVariantId, int discountId)
        {
            DBProviderManager<DBDiscountProvider>.Provider.AddDiscountToProductVariant(productVariantId, discountId);
            if (DiscountManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(DISCOUNTS_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Removes a discount from a product variant
        /// </summary>
        /// <param name="productVariantId">Product variant identifier</param>
        /// <param name="discountId">Discount identifier</param>
        public static void RemoveDiscountFromProductVariant(int productVariantId, int discountId)
        {
            DBProviderManager<DBDiscountProvider>.Provider.RemoveDiscountFromProductVariant(productVariantId, discountId);
            if (DiscountManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(DISCOUNTS_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets a discount collection of a product variant
        /// </summary>
        /// <param name="productVariantId">Product variant identifier</param>
        /// <returns>Discount collection</returns>
        public static DiscountCollection GetDiscountsByProductVariantId(int productVariantId)
        {
            bool showHidden = NopContext.Current.IsAdmin;
            string key = string.Format(DISCOUNTS_BY_PRODUCTVARIANTID_KEY, productVariantId, showHidden);
            object obj2 = NopCache.Get(key);
            if (DiscountManager.CacheEnabled && (obj2 != null))
            {
                return (DiscountCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBDiscountProvider>.Provider.GetDiscountsByProductVariantId(productVariantId, showHidden);
            var discounts = DBMapping(dbCollection);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.Max(key, discounts);
            }
            return discounts;
        }

        /// <summary>
        /// Adds a discount to a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="discountId">Discount identifier</param>
        public static void AddDiscountToCategory(int categoryId, int discountId)
        {
            DBProviderManager<DBDiscountProvider>.Provider.AddDiscountToCategory(categoryId, discountId);
            if (DiscountManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(DISCOUNTS_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Removes a discount from a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <param name="discountId">Discount identifier</param>
        public static void RemoveDiscountFromCategory(int categoryId, int discountId)
        {
            DBProviderManager<DBDiscountProvider>.Provider.RemoveDiscountFromCategory(categoryId, discountId);
            if (DiscountManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(DISCOUNTS_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets a discount collection of a category
        /// </summary>
        /// <param name="categoryId">Category identifier</param>
        /// <returns>Discount collection</returns>
        public static DiscountCollection GetDiscountsByCategoryId(int categoryId)
        {
            bool showHidden = NopContext.Current.IsAdmin;
            string key = string.Format(DISCOUNTS_BY_CATEGORYID_KEY, categoryId, showHidden);
            object obj2 = NopCache.Get(key);
            if (DiscountManager.CacheEnabled && (obj2 != null))
            {
                return (DiscountCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBDiscountProvider>.Provider.GetDiscountsByCategoryId(categoryId, showHidden);
            var discounts = DBMapping(dbCollection);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.Max(key, discounts);
            }
            return discounts;
        }

        /// <summary>
        /// Adds a discount requirement
        /// </summary>
        /// <param name="productVariantId">Product variant identifier</param>
        /// <param name="discountId">Discount identifier</param>
        public static void AddDiscountRestriction(int productVariantId, int discountId)
        {
            DBProviderManager<DBDiscountProvider>.Provider.AddDiscountRestriction(productVariantId, discountId);
        }

        /// <summary>
        /// Removes discount requirement
        /// </summary>
        /// <param name="productVariantId">Product variant identifier</param>
        /// <param name="discountId">Discount identifier</param>
        public static void RemoveDiscountRestriction(int productVariantId, int discountId)
        {
            DBProviderManager<DBDiscountProvider>.Provider.RemoveDiscountRestriction(productVariantId, discountId);
        }

        #endregion

        #region Etc

        /// <summary>
        /// Gets all discount requirements
        /// </summary>
        /// <returns>Discount requirement collection</returns>
        public static DiscountRequirementCollection GetAllDiscountRequirements()
        {
            string key = string.Format(DISCOUNTREQUIREMENT_ALL_KEY);
            object obj2 = NopCache.Get(key);
            if (DiscountManager.CacheEnabled && (obj2 != null))
            {
                return (DiscountRequirementCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBDiscountProvider>.Provider.GetAllDiscountRequirements();
            var discountRequirements = DBMapping(dbCollection);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.Max(key, discountRequirements);
            }
            return discountRequirements;
        }

        /// <summary>
        /// Gets all discount types
        /// </summary>
        /// <returns>Discount type collection</returns>
        public static DiscountTypeCollection GetAllDiscountTypes()
        {
            string key = string.Format(DISCOUNTTYPES_ALL_KEY);
            object obj2 = NopCache.Get(key);
            if (DiscountManager.CacheEnabled && (obj2 != null))
            {
                return (DiscountTypeCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBDiscountProvider>.Provider.GetAllDiscountTypes();
            var discountTypeCollection = DBMapping(dbCollection);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.Max(key, discountTypeCollection);
            }
            return discountTypeCollection;
        }
        
        /// <summary>
        /// Gets all discount limitations
        /// </summary>
        /// <returns>Discount limitation collection</returns>
        public static DiscountLimitationCollection GetAllDiscountLimitations()
        {
            string key = string.Format(DISCOUNTLIMITATION_ALL_KEY);
            object obj2 = NopCache.Get(key);
            if (DiscountManager.CacheEnabled && (obj2 != null))
            {
                return (DiscountLimitationCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBDiscountProvider>.Provider.GetAllDiscountLimitations();
            var discountLimitations = DBMapping(dbCollection);

            if (DiscountManager.CacheEnabled)
            {
                NopCache.Max(key, discountLimitations);
            }
            return discountLimitations;
        }

        #endregion

        #region Discount History

        /// <summary>
        /// Deletes a discount usage history entry
        /// </summary>
        /// <param name="discountUsageHistoryId">Discount usage history entry identifier</param>
        public static void DeleteDiscountUsageHistory(int discountUsageHistoryId)
        {
            DBProviderManager<DBDiscountProvider>.Provider.DeleteDiscountUsageHistory(discountUsageHistoryId);
        }

        /// <summary>
        /// Gets a discount usage history entry
        /// </summary>
        /// <param name="discountUsageHistoryId">Discount usage history entry identifier</param>
        /// <returns>Discount usage history entry</returns>
        public static DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            if (discountUsageHistoryId == 0)
                return null;

            var dbItem = DBProviderManager<DBDiscountProvider>.Provider.GetDiscountUsageHistoryById(discountUsageHistoryId);
            var discountUsageHistory = DBMapping(dbItem);
            return discountUsageHistory;
        }

        /// <summary>
        /// Gets all discount usage history entries
        /// </summary>
        /// <param name="discountId">Discount type identifier; null to load all</param>
        /// <param name="customerId">Customer identifier; null to load all</param>
        /// <param name="orderId">Order identifier; null to load all</param>
        /// <returns>Discount usage history entries</returns>
        public static DiscountUsageHistoryCollection GetAllDiscountUsageHistoryEntries(int? discountId,
            int? customerId, int? orderId)
        {
            var dbCollection = DBProviderManager<DBDiscountProvider>.Provider.GetAllDiscountUsageHistoryEntries(discountId, customerId, orderId);
            var discountUsageHistoryEntries = DBMapping(dbCollection);
            return discountUsageHistoryEntries;
        }

        /// <summary>
        /// Inserts a discount usage history entry
        /// </summary>
        /// <param name="discountId">Discount type identifier</param>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="orderId">Order identifier</param>
        /// <param name="createdOn">A date and time of instance creation</param>
        /// <returns>Discount usage history entry</returns>
        public static DiscountUsageHistory InsertDiscountUsageHistory(int discountId,
            int customerId, int orderId, DateTime createdOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);

            var dbItem = DBProviderManager<DBDiscountProvider>.Provider.InsertDiscountUsageHistory(discountId, 
                customerId, orderId, createdOn);
            var discountUsageHistory = DBMapping(dbItem);
            return discountUsageHistory;
        }

        /// <summary>
        /// Updates the discount usage history entry
        /// </summary>
        /// <param name="discountUsageHistoryId">discount usage history entry identifier</param>
        /// <param name="discountId">Discount type identifier</param>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="orderId">Order identifier</param>
        /// <param name="createdOn">A date and time of instance creation</param>
        /// <returns>Discount</returns>
        public static DiscountUsageHistory UpdateDiscountUsageHistory(int discountUsageHistoryId, 
            int discountId, int customerId, int orderId, DateTime createdOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);

            var dbItem = DBProviderManager<DBDiscountProvider>.Provider.UpdateDiscountUsageHistory(discountUsageHistoryId,
                discountId, customerId, orderId, createdOn);
            var discountUsageHistory = DBMapping(dbItem);
            return discountUsageHistory;
        }

        #endregion

        #endregion

        #region Property
        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public static bool CacheEnabled
        {
            get
            {
                return SettingManager.GetSettingValueBoolean("Cache.DiscountManager.CacheEnabled");
            }
        }
        #endregion
    }
}
