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
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Xml;

namespace NopSolutions.NopCommerce.DataAccess.Localization
{
    /// <summary>
    /// Acts as a base class for deriving custom locale string resource provider
    /// </summary>
    [DBProviderSectionName("nopDataProviders/LocaleStringResourceProvider")]
    public abstract partial class DBLocaleStringResourceProvider : BaseDBProvider
    {
        #region Methods

        /// <summary>
        /// Deletes a locale string resource
        /// </summary>
        /// <param name="localeStringResourceId">Locale string resource identifier</param>
        public abstract void DeleteLocaleStringResource(int localeStringResourceId);

        /// <summary>
        /// Gets a locale string resource
        /// </summary>
        /// <param name="localeStringResourceId">Locale string resource identifier</param>
        /// <returns>Locale string resource</returns>
        public abstract DBLocaleStringResource GetLocaleStringResourceById(int localeStringResourceId);

        /// <summary>
        /// Gets all locale string resources by language identifier
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <returns>Locale string resource collection</returns>
        public abstract DBLocaleStringResourceCollection GetAllResourcesByLanguageId(int languageId);

        /// <summary>
        /// Inserts a locale string resource
        /// </summary>
        /// <param name="languageId">The language identifier</param>
        /// <param name="resourceName">The resource name</param>
        /// <param name="resourceValue">The resource value</param>
        /// <returns>Locale string resource</returns>
        public abstract DBLocaleStringResource InsertLocaleStringResource(int languageId,
            string resourceName, string resourceValue);

        /// <summary>
        /// Updates the locale string resource
        /// </summary>
        /// <param name="localeStringResourceId">The locale string resource identifier</param>
        /// <param name="languageId">The language identifier</param>
        /// <param name="resourceName">The resource name</param>
        /// <param name="resourceValue">The resource value</param>
        /// <returns>Locale string resource</returns>
        public abstract DBLocaleStringResource UpdateLocaleStringResource(int localeStringResourceId,
            int languageId, string resourceName, string resourceValue);

        /// <summary>
        /// Loads all locale string resources as XML
        /// </summary>
        /// <param name="languageId">The Language identifier</param>
        /// <returns>XML</returns>
        public abstract string GetAllLocaleStringResourcesAsXml(int languageId);

        /// <summary>
        /// Inserts all locale string resources from XML
        /// </summary>
        /// <param name="languageId">The Language identifier</param>
        /// <param name="xml">The XML package</param>
        public abstract void InsertAllLocaleStringResourcesFromXml(int languageId, string xml);
        
        #endregion
    }
}
