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
using NopSolutions.NopCommerce.DataAccess;
using NopSolutions.NopCommerce.DataAccess.Directory;

namespace NopSolutions.NopCommerce.BusinessLogic.Directory
{
    /// <summary>
    /// Language manager
    /// </summary>
    public partial class LanguageManager
    {
        #region Constants
        private const string LANGUAGES_ALL_KEY = "Nop.language.all-{0}";
        private const string LANGUAGES_BY_ID_KEY = "Nop.language.id-{0}";
        private const string LANGUAGES_PATTERN_KEY = "Nop.language.";
        #endregion

        #region Utilities
        private static LanguageCollection DBMapping(DBLanguageCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var collection = new LanguageCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                collection.Add(item);
            }

            return collection;
        }

        private static Language DBMapping(DBLanguage dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new Language();
            item.LanguageId = dbItem.LanguageId;
            item.Name = dbItem.Name;
            item.LanguageCulture = dbItem.LanguageCulture;
            item.FlagImageFileName = dbItem.FlagImageFileName;
            item.Published = dbItem.Published;
            item.DisplayOrder = dbItem.DisplayOrder;

            return item;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Deletes a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        public static void DeleteLanguage(int languageId)
        {
            var language = GetLanguageById(languageId);
            DBProviderManager<DBLanguageProvider>.Provider.DeleteLanguage(languageId);
            if (LanguageManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(LANGUAGES_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <returns>Language collection</returns>
        public static LanguageCollection GetAllLanguages()
        {
            bool showHidden = NopContext.Current.IsAdmin;
            return GetAllLanguages(showHidden);
        }

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Language collection</returns>
        public static LanguageCollection GetAllLanguages(bool showHidden)
        {
            string key = string.Format(LANGUAGES_ALL_KEY, showHidden);
            object obj2 = NopCache.Get(key);
            if (LanguageManager.CacheEnabled && (obj2 != null))
            {
                return (LanguageCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBLanguageProvider>.Provider.GetAllLanguages(showHidden);
            var languageCollection = DBMapping(dbCollection);

            if (LanguageManager.CacheEnabled)
            {
                NopCache.Max(key, languageCollection);
            }
            return languageCollection;
        }

        /// <summary>
        /// Gets a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Language</returns>
        public static Language GetLanguageById(int languageId)
        {
            if (languageId == 0)
                return null;

            string key = string.Format(LANGUAGES_BY_ID_KEY, languageId);
            object obj2 = NopCache.Get(key);
            if (LanguageManager.CacheEnabled && (obj2 != null))
            {
                return (Language)obj2;
            }

            var dbItem = DBProviderManager<DBLanguageProvider>.Provider.GetLanguageById(languageId);
            var language = DBMapping(dbItem);

            if (LanguageManager.CacheEnabled)
            {
                NopCache.Max(key, language);
            }
            return language;
        }

        /// <summary>
        /// Inserts a language
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="languageCulture">The language culture</param>
        /// <param name="flagImageFileName">The flag image file name</param>
        /// <param name="published">A value indicating whether the language is published</param>
        /// <param name="displayOrder">The display order</param>
        /// <returns>Language</returns>
        public static Language InsertLanguage(string name, string languageCulture,
            string flagImageFileName, bool published, int displayOrder)
        {
            var dbItem = DBProviderManager<DBLanguageProvider>.Provider.InsertLanguage(name,
                languageCulture, flagImageFileName, published, displayOrder);
            var language = DBMapping(dbItem);

            if (LanguageManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(LANGUAGES_PATTERN_KEY);
            }
            return language;
        }

        /// <summary>
        /// Updates a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <param name="name">The name</param>
        /// <param name="languageCulture">The language culture</param>
        /// <param name="flagImageFileName">The flag image file name</param>
        /// <param name="published">A value indicating whether the language is published</param>
        /// <param name="displayOrder">The display order</param>
        /// <returns>Language</returns>
        public static Language UpdateLanguage(int languageId,
            string name, string languageCulture,
            string flagImageFileName, bool published, int displayOrder)
        {
            var dbItem = DBProviderManager<DBLanguageProvider>.Provider.UpdateLanguage(languageId,
                name, languageCulture, flagImageFileName, published, displayOrder);
            var language = DBMapping(dbItem);
            if (LanguageManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(LANGUAGES_PATTERN_KEY);
            }

            return language;
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
                return SettingManager.GetSettingValueBoolean("Cache.LanguageManager.CacheEnabled");
            }
        }
        #endregion
    }
}
