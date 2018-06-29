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
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Hosting;
using System.Web.Configuration;
using System.Collections.Specialized;

namespace NopSolutions.NopCommerce.DataAccess.Maintenance
{
    /// <summary>
    /// Acts as a base class for deriving custom maintenance provider
    /// </summary>
    [DBProviderSectionName("nopDataProviders/MaintenanceProvider")]
    public abstract partial class DBMaintenanceProvider : BaseDBProvider
    {
        #region Methods

        /// <summary>
        /// Reindex
        /// </summary>
        public abstract void Reindex();
        /// <summary>
        /// Backup database
        /// </summary>
        /// <param name="fileName">Destination file name</param>
        public abstract void Backup(string fileName);
        /// <summary>
        /// Restore database
        /// </summary>
        /// <param name="fileName">Target file name</param>
        public abstract void RestoreBackup(string fileName);

        #endregion
    }
}
