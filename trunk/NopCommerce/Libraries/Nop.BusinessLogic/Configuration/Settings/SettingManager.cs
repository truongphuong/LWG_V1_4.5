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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using NopSolutions.NopCommerce.BusinessLogic.Caching;
using NopSolutions.NopCommerce.DataAccess;
using NopSolutions.NopCommerce.DataAccess.Configuration.Settings;

namespace NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings
{
    /// <summary>
    /// Setting manager
    /// </summary>
    public partial class SettingManager
    {
        #region Constants
        private const string SETTINGS_ALL_KEY = "Nop.setting.all";
        #endregion

        #region Utilities
        private static SettingDictionary DBMapping(DBSettingCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var dictionary = new SettingDictionary();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                dictionary.Add(item.Name.ToLowerInvariant(), item);
            }

            return dictionary;
        }

        private static Setting DBMapping(DBSetting dbItem)
        {
            if (dbItem == null)
                return null;

            var item = new Setting();
            item.SettingId = dbItem.SettingId;
            item.Name = dbItem.Name;
            item.Value = dbItem.Value;
            item.Description = dbItem.Description;

            return item;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets a setting
        /// </summary>
        /// <param name="settingId">Setting identifer</param>
        /// <returns>Setting</returns>
        public static Setting GetSettingById(int settingId)
        {
            if (settingId == 0)
                return null;

            var dbItem = DBProviderManager<DBSettingProvider>.Provider.GetSettingById(settingId);
            var setting = DBMapping(dbItem);
            return setting;
        }

        /// <summary>
        /// Deletes a setting
        /// </summary>
        /// <param name="settingId">Setting identifer</param>
        public static void DeleteSetting(int settingId)
        {
            DBProviderManager<DBSettingProvider>.Provider.DeleteSetting(settingId);

            if (SettingManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(SETTINGS_ALL_KEY);
            }
        }

        /// <summary>
        /// Gets all settings
        /// </summary>
        /// <returns>Setting collection</returns>
        public static SettingDictionary GetAllSettings()
        {
            string key = SETTINGS_ALL_KEY;
            object obj2 = NopCache.Get(key);
            if (SettingManager.CacheEnabled && (obj2 != null))
            {
                return (SettingDictionary)obj2;
            }

            var dbCollection = DBProviderManager<DBSettingProvider>.Provider.GetAllSettings();
            var settings = DBMapping(dbCollection);

            if (SettingManager.CacheEnabled)
            {
                NopCache.Max(key, settings);
            }
            return settings;
        }

         /// <summary>
        /// Inserts/updates a param
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>Setting</returns>
        public static Setting SetParam(string name, string value)
        {
            var setting = GetSettingByName(name);
            if (setting != null)
                return SetParam(name, value, setting.Description);
            else
                return SetParam(name, value, string.Empty);
        }

        /// <summary>
        /// Inserts/updates a param
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public static Setting SetParam(string name, string value, string description)
        {
            var setting = GetSettingByName(name);
            if (setting != null)
            {
                if (setting.Name != name || setting.Value != value || setting.Description != description)
                    setting = UpdateSetting(setting.SettingId, name, value, description);
            }
            else
                setting = AddSetting(name, value, description);

            return setting;
        }

        /// <summary>
        /// Inserts/updates a param in US locale
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>Setting</returns>
        public static Setting SetParamNative(string name, decimal value)
        {
            return SetParamNative(name, value, string.Empty);
        }

        /// <summary>
        /// Inserts/updates a param in US locale
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public static Setting SetParamNative(string name, decimal value, string description)
        {
            string valueStr = value.ToString(new CultureInfo("en-US"));
            return SetParam(name, valueStr, description);
        }

        /// <summary>
        /// Adds a setting
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public static Setting AddSetting(string name, string value, string description)
        {
            var dbItem = DBProviderManager<DBSettingProvider>.Provider.AddSetting(name, value, description);
            var setting = DBMapping(dbItem);

            if (SettingManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(SETTINGS_ALL_KEY);
            }

            return setting;
        }

        /// <summary>
        /// Updates a setting
        /// </summary>
        /// <param name="settingId">Setting identifier</param>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="description">The description</param>
        /// <returns>Setting</returns>
        public static Setting UpdateSetting(int settingId, string name, string value, string description)
        {
            var dbItem = DBProviderManager<DBSettingProvider>.Provider.UpdateSetting(settingId, name, value, description);
            var setting = DBMapping(dbItem);
            if (SettingManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(SETTINGS_ALL_KEY);
            }

            return setting;
        }

        /// <summary>
        /// Gets a boolean value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public static bool GetSettingValueBoolean(string name)
        {
            return GetSettingValueBoolean(name, false);
        }

        /// <summary>
        /// Gets a boolean value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public static bool GetSettingValueBoolean(string name, bool defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return bool.Parse(value);
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets an integer value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public static int GetSettingValueInteger(string name)
        {
            return GetSettingValueInteger(name, 0);
        }

        /// <summary>
        /// Gets an integer value of a setting
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public static int GetSettingValueInteger(string name, int defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return int.Parse(value);
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets a decimal value of a setting in US locale
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public static decimal GetSettingValueDecimalNative(string name)
        {
            return GetSettingValueDecimalNative(name, decimal.Zero);
        }

        /// <summary>
        /// Gets a decimal value of a setting in US locale
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public static decimal GetSettingValueDecimalNative(string name, decimal defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return decimal.Parse(value, new CultureInfo("en-US"));
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets a setting value
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>The setting value</returns>
        public static string GetSettingValue(string name)
        {
            var setting = GetSettingByName(name);
            if (setting != null)
                return setting.Value;
            return string.Empty;
        }

        /// <summary>
        /// Gets a setting value
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The setting value</returns>
        public static string GetSettingValue(string name, string defaultValue)
        {
            string value = GetSettingValue(name);
            if (!String.IsNullOrEmpty(value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// Get a setting by name
        /// </summary>
        /// <param name="name">The setting name</param>
        /// <returns>Setting instance</returns>
        public static Setting GetSettingByName(string name)
        {
            if (String.IsNullOrEmpty(name))
                return null;

            name = name.Trim().ToLowerInvariant();

            var settings = GetAllSettings();
            if (settings.ContainsKey(name))
            {
                var setting = settings[name];
                return setting;
            }
            return null;
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
                return true;
            }
        }

        /// <summary>
        /// Gets or sets a store name
        /// </summary>
        public static string StoreName
        {
            get
            {
                string storeName = SettingManager.GetSettingValue("Common.StoreName");
                return storeName;
            }
            set
            {
                SettingManager.SetParam("Common.StoreName", value);
            }
        }

        /// <summary>
        /// Gets or sets a store URL (ending with "/")
        /// </summary>
        public static string StoreUrl
        {
            get
            {
                string storeUrl = SettingManager.GetSettingValue("Common.StoreURL");
                if (!storeUrl.EndsWith("/"))
                    storeUrl += "/";
                return storeUrl;
            }
            set
            {
                SettingManager.SetParam("Common.StoreURL", value);
            }
        }

        #endregion
    }
}
