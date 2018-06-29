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
using NopSolutions.NopCommerce.DataAccess;
using NopSolutions.NopCommerce.DataAccess.Tax;

namespace NopSolutions.NopCommerce.BusinessLogic.Tax
{
    /// <summary>
    /// Tax category manager
    /// </summary>
    public partial class TaxCategoryManager
    {
        #region Constants
        private const string TAXCATEGORIES_ALL_KEY = "Nop.taxcategory.all";
        private const string TAXCATEGORIES_BY_ID_KEY = "Nop.taxcategory.id-{0}";
        private const string TAXCATEGORIES_PATTERN_KEY = "Nop.taxcategory.";
        #endregion

        #region Utilities
        private static TaxCategoryCollection DBMapping(DBTaxCategoryCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new TaxCategoryCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static TaxCategory DBMapping(DBTaxCategory dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new TaxCategory();
            item.TaxCategoryId = dbItem.TaxCategoryId;
            item.Name = dbItem.Name;
            item.DisplayOrder = dbItem.DisplayOrder;
            item.CreatedOn = dbItem.CreatedOn;
            item.UpdatedOn = dbItem.UpdatedOn;

            return item;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Deletes a tax category
        /// </summary>
        /// <param name="taxCategoryId">The tax category identifier</param>
        public static void DeleteTaxCategory(int taxCategoryId)
        {
            DBProviderManager<DBTaxCategoryProvider>.Provider.DeleteTaxCategory(taxCategoryId);
            if (TaxCategoryManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(TAXCATEGORIES_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets all tax categories
        /// </summary>
        /// <returns>Tax category collection</returns>
        public static TaxCategoryCollection GetAllTaxCategories()
        {
            string key = string.Format(TAXCATEGORIES_ALL_KEY);
            object obj2 = NopCache.Get(key);
            if (TaxCategoryManager.CacheEnabled && (obj2 != null))
            {
                return (TaxCategoryCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBTaxCategoryProvider>.Provider.GetAllTaxCategories();
            var taxCategoryCollection = DBMapping(dbCollection);

            if (TaxCategoryManager.CacheEnabled)
            {
                NopCache.Max(key, taxCategoryCollection);
            }
            return taxCategoryCollection;
        }

        /// <summary>
        /// Gets a tax category
        /// </summary>
        /// <param name="taxCategoryId">Tax category identifier</param>
        /// <returns>Tax category</returns>
        public static TaxCategory GetTaxCategoryById(int taxCategoryId)
        {
            if (taxCategoryId == 0)
                return null;

            string key = string.Format(TAXCATEGORIES_BY_ID_KEY, taxCategoryId);
            object obj2 = NopCache.Get(key);
            if (TaxCategoryManager.CacheEnabled && (obj2 != null))
            {
                return (TaxCategory)obj2;
            }

            var dbItem = DBProviderManager<DBTaxCategoryProvider>.Provider.GetTaxCategoryById(taxCategoryId);
            var taxCategory = DBMapping(dbItem);

            if (TaxCategoryManager.CacheEnabled)
            {
                NopCache.Max(key, taxCategory);
            }
            return taxCategory;
        }

        /// <summary>
        /// Inserts a tax category
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="displayOrder">The display order</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <returns>Tax category</returns>
        public static TaxCategory InsertTaxCategory(string name,
            int displayOrder, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            var dbItem = DBProviderManager<DBTaxCategoryProvider>.Provider.InsertTaxCategory(name,
                 displayOrder, createdOn, updatedOn);
            var taxCategory = DBMapping(dbItem);

            if (TaxCategoryManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(TAXCATEGORIES_PATTERN_KEY);
            }
            return taxCategory;
        }

        /// <summary>
        /// Updates the tax category
        /// </summary>
        /// <param name="taxCategoryId">The tax category identifier</param>
        /// <param name="name">The name</param>
        /// <param name="displayOrder">The display order</param>
        /// <param name="createdOn">The date and time of instance creation</param>
        /// <param name="updatedOn">The date and time of instance update</param>
        /// <returns>Tax category</returns>
        public static TaxCategory UpdateTaxCategory(int taxCategoryId, string name,
            int displayOrder, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            var dbItem = DBProviderManager<DBTaxCategoryProvider>.Provider.UpdateTaxCategory(taxCategoryId, name,
                displayOrder, createdOn, updatedOn);
            var taxCategory = DBMapping(dbItem);

            if (TaxCategoryManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(TAXCATEGORIES_PATTERN_KEY);
            }
            return taxCategory;
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public static bool CacheEnabled
        {
            get
            {
                return SettingManager.GetSettingValueBoolean("Cache.TaxCategoryManager.CacheEnabled");
            }
        }
        #endregion
    }
}
