﻿//------------------------------------------------------------------------------
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
using System.Text;
using NopSolutions.NopCommerce.DataAccess;
using NopSolutions.NopCommerce.DataAccess.Security;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.Caching;
using NopSolutions.NopCommerce.BusinessLogic.Profile;
using NopSolutions.NopCommerce.Common;

namespace NopSolutions.NopCommerce.BusinessLogic.Security
{
    /// <summary>
    /// IP Blacklist manager implementation
    /// </summary>
    public partial class IpBlacklistManager
    {
        #region Constants
        private const string BLACKLIST_ALLIP_KEY = "Nop.blacklist.ip.all";
        private const string BLACKLIST_ALLNETWORK_KEY = "Nop.blacklist.network.all";
        private const string BLACKLIST_IP_PATTERN_KEY = "Nop.blacklist.ip.";
        private const string BLACKLIST_NETWORK_PATTERN_KEY = "Nop.blacklist.network.";
        #endregion

        #region Utilities
        private static BannedIpAddress DBMapping(DBBannedIpAddress dbItem)
        {
            if (dbItem == null)
                return null;

            var ipAddress = new BannedIpAddress();
            ipAddress.BannedIpAddressId = dbItem.BannedIpAddressId;
            ipAddress.Address = dbItem.Address;
            ipAddress.Comment = dbItem.Comment;
            ipAddress.CreatedOn = dbItem.CreatedOn;
            ipAddress.UpdatedOn = dbItem.UpdatedOn;
            return ipAddress;
        }

        private static BannedIpAddressCollection DBMapping(DBBannedIpAddressCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var ipCollection = new BannedIpAddressCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                ipCollection.Add(item);
            }
            return ipCollection;
        }

        private static BannedIpNetwork DBMapping(DBBannedIpNetwork dbItem)
        {
            if (dbItem == null)
                return null;

            var ipNetwork = new BannedIpNetwork();
            ipNetwork.BannedIpNetworkId = dbItem.BannedIpNetworkId;
            ipNetwork.StartAddress = dbItem.StartAddress;
            ipNetwork.EndAddress = dbItem.EndAddress;
            ipNetwork.IpException = dbItem.IpException;
            ipNetwork.Comment = dbItem.Comment;
            ipNetwork.CreatedOn = dbItem.CreatedOn;
            ipNetwork.UpdatedOn = dbItem.UpdatedOn;
            return ipNetwork;
        }

        private static BannedIpNetworkCollection DBMapping(DBBannedIpNetworkCollection dbCollection)
        {
            if (dbCollection == null)
                return null;

            var ipCollection = new BannedIpNetworkCollection();
            foreach (var dbItem in dbCollection)
            {
                var item = DBMapping(dbItem);
                ipCollection.Add(item);
            }
            return ipCollection;
        }

        /// <summary>
        /// This encodes the string representation of an IP address to a uint, but
        /// backwards so that it can be used to compare addresses. This function is
        /// used internally for comparison and is not valid for valid encoding of
        /// IP address information.
        /// </summary>
        /// <param name="ipAddress">A string representation of the IP address to convert</param>
        /// <returns>Returns a backwards uint representation of the string.</returns>
        private static uint IpAddressToLongBackwards(string ipAddress)
        {
            var oIP = System.Net.IPAddress.Parse(ipAddress);
            byte[] byteIP = oIP.GetAddressBytes();

            uint ip = (uint)byteIP[0] << 24;
            ip += (uint)byteIP[1] << 16;
            ip += (uint)byteIP[2] << 8;
            ip += (uint)byteIP[3];

            return ip;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets an IP address by its identifier
        /// </summary>
        /// <param name="ipAddressId">IP Address unique identifier</param>
        /// <returns>An IP address</returns>
        public static BannedIpAddress GetBannedIpAddressById(int ipAddressId)
        {
            if (ipAddressId == 0)
                return null;

            var dbItem = DBProviderManager<DBBlacklistProvider>.Provider.GetIpAddressById(ipAddressId);
            var ipAddress = DBMapping(dbItem);
            return ipAddress;
        }

        /// <summary>
        /// Gets all IP addresses
        /// </summary>
        /// <returns>An IP address collection</returns>
        public static BannedIpAddressCollection GetBannedIpAddressAll()
        {
            string key = BLACKLIST_ALLIP_KEY;
            object obj2 = NopCache.Get(key);
            if (CacheEnabled && (obj2 != null))
            {
                return (BannedIpAddressCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBBlacklistProvider>.Provider.GetIpAddressAll();
            var collection = DBMapping(dbCollection);

            if (IpBlacklistManager.CacheEnabled)
            {
                NopCache.Max(key, collection);
            }
            return collection;
        }

        /// <summary>
        /// Inserts an IP address
        /// </summary>
        /// <param name="address">IP address</param>
        /// <param name="comment">Reason why the IP was banned</param>
        /// <param name="createdOn">When the record was inserted</param>
        /// <param name="updatedOn">When the record was last updated</param>
        /// <returns>IP Address</returns>
        public static BannedIpAddress InsertBannedIpAddress(string address, string comment, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            address = address.Trim();

            var dbItem = DBProviderManager<DBBlacklistProvider>.Provider.InsertBannedIpAddress(address, comment, createdOn, updatedOn);
            var ipAddress = DBMapping(dbItem);

            if (IpBlacklistManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(BLACKLIST_IP_PATTERN_KEY);
            }
            return ipAddress;
        }

        /// <summary>
        /// Updates an IP address
        /// </summary>
        /// <param name="ipAddressId">IP address unique identifier</param>
        /// <param name="address">IP address</param>
        /// <param name="comment">Reason why the IP was banned</param>
        /// <param name="createdOn">When the record was inserted</param>
        /// <param name="updatedOn">When the record was last updated</param>
        /// <returns>IP address</returns>
        public static BannedIpAddress UpdateBannedIpAddress(int ipAddressId, string address, string comment, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            address = address.Trim();

            var dbItem = DBProviderManager<DBBlacklistProvider>.Provider.UpdateBannedIpAddress(ipAddressId, address, comment, createdOn, updatedOn);
            var ipAddress = DBMapping(dbItem);
            if (IpBlacklistManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(BLACKLIST_IP_PATTERN_KEY);
            }
            return ipAddress;
        }

        /// <summary>
        /// Deletes an IP address by its identifier
        /// </summary>
        /// <param name="ipAddressId">IP address unique identifier</param>
        public static void DeleteBannedIpAddress(int ipAddressId)
        {
            DBProviderManager<DBBlacklistProvider>.Provider.DeleteBannedIpAddress(ipAddressId);
            if (IpBlacklistManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(BLACKLIST_IP_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Gets an IP network by its Id
        /// </summary>
        /// <param name="bannedIpNetworkId">IP network unique identifier</param>
        /// <returns>IP network</returns>
        public static BannedIpNetwork GetBannedIpNetworkById(int bannedIpNetworkId)
        {
            if (bannedIpNetworkId == 0)
                return null;

            var dbItem = DBProviderManager<DBBlacklistProvider>.Provider.GetIpNetworkById(bannedIpNetworkId);
            var ipNetwork = DBMapping(dbItem);
            return ipNetwork;
        }

        /// <summary>
        /// Gets all IP networks
        /// </summary>
        /// <returns>IP network collection</returns>
        public static BannedIpNetworkCollection GetBannedIpNetworkAll()
        {
            string key = BLACKLIST_ALLNETWORK_KEY;
            object obj2 = NopCache.Get(key);
            if (IpBlacklistManager.CacheEnabled && (obj2 != null))
            {
                return (BannedIpNetworkCollection)obj2;
            }

            var dbCollection = DBProviderManager<DBBlacklistProvider>.Provider.GetIpNetworkAll();
            var collection = DBMapping(dbCollection);

            if (IpBlacklistManager.CacheEnabled)
            {
                NopCache.Max(key, collection);
            }
            return collection;
        }

        /// <summary>
        /// Inserts an IP network
        /// </summary>
        /// <param name="startAddress">First IP address in the range</param>
        /// <param name="endAddress">Last IP address in the range </param>
        /// <param name="comment">Reason why the IP network was banned</param>
        /// <param name="ipException">Exception IPs in the range</param>
        /// <param name="createdOn">When the record was inserted</param>
        /// <param name="updatedOn">When the record was last updated</param>
        /// <returns></returns>
        public static BannedIpNetwork InsertBannedIpNetwork(string startAddress, string endAddress, string comment, string ipException, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            startAddress = startAddress.Trim();
            endAddress = endAddress.Trim();

            var dbItem = DBProviderManager<DBBlacklistProvider>.Provider.InsertBannedIpNetwork(startAddress, endAddress, comment, ipException, createdOn, updatedOn);
            var ipNetwork = DBMapping(dbItem);

            if (IpBlacklistManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(BLACKLIST_NETWORK_PATTERN_KEY);
            }
            return ipNetwork;
        }

        /// <summary>
        /// Updates an IP network
        /// </summary>
        /// <param name="bannedIpNetwork">IP network unique identifier</param>
        /// <param name="startAddress">First IP address in the range</param>
        /// <param name="endAddress">Last IP address in the range</param>
        /// <param name="comment">Reason why the IP network was banned</param>
        /// <param name="ipException">Exception IPs in the range</param>
        /// <param name="createdOn">When the record was created</param>
        /// <param name="updatedOn">When the record was last updated</param>
        /// <returns></returns>
        public static BannedIpNetwork UpdateBannedIpNetwork(int bannedIpNetwork, string startAddress, string endAddress, string comment, string ipException, DateTime createdOn, DateTime updatedOn)
        {
            createdOn = DateTimeHelper.ConvertToUtcTime(createdOn);
            updatedOn = DateTimeHelper.ConvertToUtcTime(updatedOn);

            startAddress = startAddress.Trim();
            endAddress = endAddress.Trim();

            var dbItem = DBProviderManager<DBBlacklistProvider>.Provider.UpdateBannedIpNetwork(bannedIpNetwork, startAddress, endAddress, comment, ipException, createdOn, updatedOn);
            var ipNetwork = DBMapping(dbItem);
            if (IpBlacklistManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(BLACKLIST_NETWORK_PATTERN_KEY);
            }
            return ipNetwork;
        }

        /// <summary>
        /// Deletes an IP network
        /// </summary>
        /// <param name="bannedIpNetwork">IP network unique identifier</param>
        public static void DeleteBannedIpNetwork(int bannedIpNetwork)
        {
            DBProviderManager<DBBlacklistProvider>.Provider.DeleteBannedIpNetwork(bannedIpNetwork);
            if (IpBlacklistManager.CacheEnabled)
            {
                NopCache.RemoveByPattern(BLACKLIST_NETWORK_PATTERN_KEY);
            }
        }

        /// <summary>
        /// Checks if an IP from the IpAddressCollection or the IpNetworkCollection is banned
        /// </summary>
        /// <param name="ipAddress">IP address</param>
        /// <returns>False or true</returns>
        public static bool IsIpAddressBanned(BannedIpAddress ipAddress)
        {
            // Check if the IP is valid
            if (!IsValidIp(ipAddress.Address.Trim()))
                throw new NopException("The following isn't a valid IP address: " + ipAddress.Address);

            // Check if the IP is in the banned IP addresses
            var ipAddressCollection = GetBannedIpAddressAll();
            //if (ipAddressCollection.Contains(ipAddress))
            foreach (var ip in ipAddressCollection)
                if (IsEqual(ipAddress.Address, ip.Address))
                    return true;

            // Check if the IP is in the banned IP networks
            var ipNetworkCollection = GetBannedIpNetworkAll();

            foreach (var ipNetwork in ipNetworkCollection)
            {
                // Get the first and last IPs in the network
                string[] rangeItem = ipNetwork.ToString().Split("-".ToCharArray());
                
                // Get the exceptions as a list
                var exceptionItem = new List<string>();
                exceptionItem.AddRange(ipNetwork.IpException.ToString().Split(";".ToCharArray()));
                // Check if the IP is an exception 
                if(exceptionItem.Contains(ipAddress.Address.ToString()))
                    return false;

                // Check if the 1st IP is valid
                if (!IsValidIp(rangeItem[0].Trim()))
                    throw new NopException("The following isn't a valid IP address: " + rangeItem[0]);

                // Check if the 2nd IP is valid
                if (!IsValidIp(rangeItem[1].Trim()))
                    throw new NopException("The following isn't a valid IP address: " + rangeItem[1]);

                //Check if the IP is in the given range
                if (IsGreaterOrEqual(ipAddress.Address.ToString(), rangeItem[0].Trim())
                    && IsLessOrEqual(ipAddress.Address.ToString(), rangeItem[1].Trim()))
                    return true;
            }
            // Return false otherwise
            return false;
        }

        /// <summary>
        /// Check if the ip is valid.
        /// </summary>
        /// <param name="ipAddress">The string representation of an IP address</param>
        /// <returns>True if the IP is valid.</returns>
        public static bool IsValidIp(string ipAddress)
        {
            try
            {
                var ip = System.Net.IPAddress.Parse(ipAddress);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares two IP addresses for equality. 
        /// </summary>
        /// <param name="ipAddress1">The first IP to compare</param>
        /// <param name="ipAddress2">The second IP to compare</param>
        /// <returns>True if equal, false if not.</returns>
        public static bool AreEqual(string ipAddress1, string ipAddress2)
        {
            // convert to long in case there is any zero padding in the strings
            return IpAddressToLongBackwards(ipAddress1) == IpAddressToLongBackwards(ipAddress2);
        }

        /// <summary>
        /// Compares two string representations of an Ip address to see if one
        /// is greater than the other
        /// </summary>
        /// <param name="toCompare">The IP address on the left hand side of the greater 
        /// than operator</param>
        /// <param name="compareAgainst">The Ip address on the right hand side of the 
        /// greater than operator</param>
        /// <returns>True if ToCompare is greater than CompareAgainst, else false</returns>       
        public static bool IsGreater(string toCompare, string compareAgainst)
        {
            // convert to long in case there is any zero padding in the strings
            return IpAddressToLongBackwards(toCompare) > IpAddressToLongBackwards(compareAgainst);
        }

        /// <summary>
        /// Compares two string representations of an Ip address to see if one
        /// is less than the other
        /// </summary>
        /// <param name="toCompare">The IP address on the left hand side of the less 
        /// than operator</param>
        /// <param name="compareAgainst">The Ip address on the right hand side of the 
        /// less than operator</param>
        /// <returns>True if ToCompare is greater than CompareAgainst, else false</returns>
        public static bool IsLess(string toCompare, string compareAgainst)
        {
            // convert to long in case there is any zero padding in the strings
            return IpAddressToLongBackwards(toCompare) < IpAddressToLongBackwards(compareAgainst);
        }

        /// <summary>
        /// Determines whether a specified object is equal to another object
        /// </summary>
        /// <param name="toCompare">The IP address on the left hand side of the less 
        /// than operator</param>
        /// <param name="compareAgainst">The Ip address on the right hand side of the 
        /// less than operator</param>
        /// <returns>Result</returns>
        public static bool IsEqual(string toCompare, string compareAgainst)
        {
            return IpAddressToLongBackwards(toCompare) == IpAddressToLongBackwards(compareAgainst);
        }

        /// <summary>
        /// Compares two string representations of an Ip address to see if one
        /// is greater than or equal to the other.
        /// </summary>
        /// <param name="toCompare">The IP address on the left hand side of the greater 
        /// than or equal operator</param>
        /// <param name="compareAgainst">The Ip address on the right hand side of the 
        /// greater than or equal operator</param>
        /// <returns>True if ToCompare is greater than or equal to CompareAgainst, else false</returns>
        public static bool IsGreaterOrEqual(string toCompare, string compareAgainst)
        {
            // convert to long in case there is any zero padding in the strings
            return IpAddressToLongBackwards(toCompare) >= IpAddressToLongBackwards(compareAgainst);
        }

        /// <summary>
        /// Compares two string representations of an Ip address to see if one
        /// is less than or equal to the other.
        /// </summary>
        /// <param name="toCompare">The IP address on the left hand side of the less 
        /// than or equal operator</param>
        /// <param name="compareAgainst">The Ip address on the right hand side of the 
        /// less than or equal operator</param>
        /// <returns>True if ToCompare is greater than or equal to CompareAgainst, else false</returns>
        public static bool IsLessOrEqual(string toCompare, string compareAgainst)
        {
            // convert to long in case there is any zero padding in the strings
            return IpAddressToLongBackwards(toCompare) <= IpAddressToLongBackwards(compareAgainst);
        }

        /// <summary>
        /// Converts a uint representation of an Ip address to a string.
        /// </summary>
        /// <param name="ipAddress">The IP address to convert</param>
        /// <returns>A string representation of the IP address.</returns>
        public static string LongToIpAddress(uint ipAddress)
        {
            return new System.Net.IPAddress(ipAddress).ToString();
        }

        /// <summary>
        /// Converts a string representation of an IP address to a uint. This
        /// encoding is proper and can be used with other networking functions such
        /// as the System.Net.IPAddress class.
        /// </summary>
        /// <param name="ipAddress">The Ip address to convert.</param>
        /// <returns>Returns a uint representation of the IP address.</returns>
        public static uint IpAddressToLong(string ipAddress)
        {
            var oIP = System.Net.IPAddress.Parse(ipAddress);
            byte[] byteIP = oIP.GetAddressBytes();

            uint ip = (uint)byteIP[3] << 24;
            ip += (uint)byteIP[2] << 16;
            ip += (uint)byteIP[1] << 8;
            ip += (uint)byteIP[0];

            return ip;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether cache is enabled
        /// </summary>
        public static bool CacheEnabled
        {
            get
            {
                return SettingManager.GetSettingValueBoolean("Cache.IpBlacklistManager.CacheEnabled");
            }
        }
        #endregion
    }
}
