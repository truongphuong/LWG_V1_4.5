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
using System.Configuration.Provider;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NopSolutions.NopCommerce.DataAccess.Directory
{
    /// <summary>
    /// State/province provider for SQL Server
    /// </summary>
    public partial class SqlStateProvinceProvider : DBStateProvinceProvider
    {
        #region Fields
        private string _sqlConnectionString;
        #endregion

        #region Utilities
        private DBStateProvince GetStateProvinceFromReader(IDataReader dataReader)
        {
            var item = new DBStateProvince();
            item.StateProvinceId = NopSqlDataHelper.GetInt(dataReader, "StateProvinceID");
            item.CountryId = NopSqlDataHelper.GetInt(dataReader, "CountryID");
            item.Name = NopSqlDataHelper.GetString(dataReader, "Name");
            item.Abbreviation = NopSqlDataHelper.GetString(dataReader, "Abbreviation");
            item.DisplayOrder = NopSqlDataHelper.GetInt(dataReader, "DisplayOrder");
            return item;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Initializes the provider with the property values specified in the application's configuration file. This method is not intended to be used directly from your code
        /// </summary>
        /// <param name="name">The name of the provider instance to initialize</param>
        /// <param name="config">A NameValueCollection that contains the names and values of configuration options for the provider.</param>
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            base.Initialize(name, config);

            string connectionStringName = config["connectionStringName"];
            if (String.IsNullOrEmpty(connectionStringName))
                throw new ProviderException("Connection name not specified");
            this._sqlConnectionString = NopSqlDataHelper.GetConnectionString(connectionStringName);
            if ((this._sqlConnectionString == null) || (this._sqlConnectionString.Length < 1))
            {
                throw new ProviderException(string.Format("Connection string not found. {0}", connectionStringName));
            }
            config.Remove("connectionStringName");

            if (config.Count > 0)
            {
                string key = config.GetKey(0);
                if (!string.IsNullOrEmpty(key))
                {
                    throw new ProviderException(string.Format("Provider unrecognized attribute. {0}", new object[] { key }));
                }
            }
        }

        /// <summary>
        /// Deletes a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        public override void DeleteStateProvince(int stateProvinceId)
        {
            Database db = NopSqlDataHelper.CreateConnection(_sqlConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("Nop_StateProvinceDelete");
            db.AddInParameter(dbCommand, "StateProvinceID", DbType.Int32, stateProvinceId);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Gets a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <returns>State/province</returns>
        public override DBStateProvince GetStateProvinceById(int stateProvinceId)
        {
            DBStateProvince item = null;
            Database db = NopSqlDataHelper.CreateConnection(_sqlConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("Nop_StateProvinceLoadByPrimaryKey");
            db.AddInParameter(dbCommand, "StateProvinceID", DbType.Int32, stateProvinceId);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    item = GetStateProvinceFromReader(dataReader);
                }
            }
            return item;
        }

        /// <summary>
        /// Gets a state/province 
        /// </summary>
        /// <param name="abbreviation">The state/province abbreviation</param>
        /// <returns>State/province</returns>
        public override DBStateProvince GetStateProvinceByAbbreviation(string abbreviation)
        {
            DBStateProvince item = null;
            Database db = NopSqlDataHelper.CreateConnection(_sqlConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("Nop_StateProvinceLoadByAbbreviation");
            db.AddInParameter(dbCommand, "Abbreviation", DbType.String, abbreviation);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    item = GetStateProvinceFromReader(dataReader);
                }
            }
            return item;
        }

        /// <summary>
        /// Gets a state/province collection by country identifier
        /// </summary>
        /// <param name="countryId">Country identifier</param>
        /// <returns>State/province collection</returns>
        public override DBStateProvinceCollection GetStateProvincesByCountryId(int countryId)
        {
            var result = new DBStateProvinceCollection();
            if (countryId == 0)
                return result;
            Database db = NopSqlDataHelper.CreateConnection(_sqlConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("Nop_StateProvinceLoadAllByCountryID");
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, countryId);
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    var item = GetStateProvinceFromReader(dataReader);
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Inserts a state/province
        /// </summary>
        /// <param name="countryId">The country identifier</param>
        /// <param name="name">The name</param>
        /// <param name="abbreviation">The abbreviation</param>
        /// <param name="displayOrder">The display order</param>
        /// <returns>State/province</returns>
        public override DBStateProvince InsertStateProvince(int countryId,
            string name, string abbreviation, int displayOrder)
        {
            DBStateProvince item = null;
            Database db = NopSqlDataHelper.CreateConnection(_sqlConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("Nop_StateProvinceInsert");
            db.AddOutParameter(dbCommand, "StateProvinceID", DbType.Int32, 0);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, countryId);
            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "Abbreviation", DbType.String, abbreviation);
            db.AddInParameter(dbCommand, "DisplayOrder", DbType.Int32, displayOrder);
            if (db.ExecuteNonQuery(dbCommand) > 0)
            {
                int stateProvinceId = Convert.ToInt32(db.GetParameterValue(dbCommand, "@StateProvinceID"));
                item = GetStateProvinceById(stateProvinceId);
            }
            return item;
        }

        /// <summary>
        /// Updates a state/province
        /// </summary>
        /// <param name="stateProvinceId">The state/province identifier</param>
        /// <param name="countryId">The country identifier</param>
        /// <param name="name">The name</param>
        /// <param name="abbreviation">The abbreviation</param>
        /// <param name="displayOrder">The display order</param>
        /// <returns>State/province</returns>
        public override DBStateProvince UpdateStateProvince(int stateProvinceId,
            int countryId, string name, string abbreviation, int displayOrder)
        {
            DBStateProvince item = null;
            Database db = NopSqlDataHelper.CreateConnection(_sqlConnectionString);
            DbCommand dbCommand = db.GetStoredProcCommand("Nop_StateProvinceUpdate");
            db.AddInParameter(dbCommand, "StateProvinceID", DbType.Int32, stateProvinceId);
            db.AddInParameter(dbCommand, "CountryID", DbType.Int32, countryId);
            db.AddInParameter(dbCommand, "Name", DbType.String, name);
            db.AddInParameter(dbCommand, "Abbreviation", DbType.String, abbreviation);
            db.AddInParameter(dbCommand, "DisplayOrder", DbType.Int32, displayOrder);
            if (db.ExecuteNonQuery(dbCommand) > 0)
                item = GetStateProvinceById(stateProvinceId);

            return item;
        }
        #endregion
    }
}
