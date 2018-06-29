using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LWG.Core.Models;

namespace LWG.Business
{
    public class DealerBiz:BaseBiz
    {
        public List<lwg_Dealer> GetAllDealers()
        {
            return dbContext.lwg_Dealer.OrderBy(d=>d.Name).ToList();
        }

        public List<lwg_Dealer> GetAllDealersBySearch(string id,string name, string address)
        {
            return dbContext.lwg_Dealer.Where(
                d => 
                    (string.IsNullOrEmpty(id)||d.DealerID.Contains(id))&&
                    (string.IsNullOrEmpty(name) || d.Name.Contains(name)) &&                     
                    (string.IsNullOrEmpty(address)||d.AddressSearch.Contains(address))                  
                    ).OrderBy(d=>d.Name).ToList();
        }

        public List<lwg_Dealer> GetAllUSDealers()
        {
            var queryStatesOfUS = from states in dbContext.Nop_StateProvince
                                  where states.CountryID == 1
                                  select states.Abbreviation;
            var USDealers = from dealers in dbContext.lwg_Dealer
                            where queryStatesOfUS.Contains(dealers.State)
                            select dealers;
            return USDealers.ToList();
        }

        public List<lwg_Dealer> GetAllOutOfUSDealers()
        {
            var queryStatesOfUS = from states in dbContext.Nop_StateProvince
                                  where states.CountryID == 1
                                  select states.Abbreviation;
            var USDealers = from dealers in dbContext.lwg_Dealer
                            where !queryStatesOfUS.Contains(dealers.State)
                            select dealers;
            return USDealers.ToList();
        }

        public bool AddDealer(lwg_Dealer _newDealer)
        {
            bool success = true;
            try
            {
                _newDealer.AddressSearch = string.Format("{0}{1}{2}{3}{4}", _newDealer.AddressLine1.Trim(), string.IsNullOrEmpty(_newDealer.AddressLine2.Trim()) ? string.Empty : " " + _newDealer.AddressLine2.Trim()
                    , string.IsNullOrEmpty(_newDealer.City.Trim())?string.Empty:" "+_newDealer.City.Trim(), string.IsNullOrEmpty(_newDealer.State.Trim())?string.Empty:" "+_newDealer.State.Trim(), string.IsNullOrEmpty(_newDealer.Zip.Trim()) ? string.Empty : " " +_newDealer.Zip.Trim());
                dbContext.lwg_Dealer.Add(_newDealer);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {                
                LWGLog.WriteLog("Add Dealer", ex.Message);
                success = false;
            }
            return success;
        }
        public bool UpdateDealer(lwg_Dealer _updateDealer,string newDealerID)
        {
            bool success = true;
            try
            {
                lwg_Dealer updateDealer = dbContext.lwg_Dealer.Where(d => d.DealerID == _updateDealer.DealerID).FirstOrDefault();
                if (updateDealer != null)
                {
                    if (string.IsNullOrEmpty(newDealerID))
                    {
                        updateDealer.AddressLine1 = _updateDealer.AddressLine1;
                        updateDealer.AddressLine2 = _updateDealer.AddressLine2;
                        updateDealer.City = _updateDealer.City;
                        updateDealer.Contact = _updateDealer.Contact;
                        updateDealer.Fax = _updateDealer.Fax;
                        updateDealer.Name = _updateDealer.Name;
                        updateDealer.NewIssue = _updateDealer.NewIssue;
                        updateDealer.Phone = _updateDealer.Phone;
                        updateDealer.WebAddress = _updateDealer.WebAddress;
                        updateDealer.Zip = _updateDealer.Zip;
                        updateDealer.State = _updateDealer.State;
                        updateDealer.AddressSearch = string.Format("{0}{1}{2}{3}{4}", _updateDealer.AddressLine1.Trim(), string.IsNullOrEmpty(_updateDealer.AddressLine2.Trim()) ? string.Empty : " " + _updateDealer.AddressLine2.Trim()
                    , string.IsNullOrEmpty(_updateDealer.City.Trim()) ? string.Empty : " " + _updateDealer.City.Trim(), string.IsNullOrEmpty(_updateDealer.State.Trim()) ? string.Empty : " " + _updateDealer.State.Trim(), string.IsNullOrEmpty(_updateDealer.Zip.Trim()) ? string.Empty : " " + _updateDealer.Zip.Trim());

                        dbContext.SaveChanges();
                    }
                    else
                    {
                        lwg_Dealer newDealer = new lwg_Dealer();
                        newDealer.DealerID = newDealerID;
                        newDealer.AddressLine1 = _updateDealer.AddressLine1;
                        newDealer.AddressLine2 = _updateDealer.AddressLine2;
                        newDealer.City = _updateDealer.City;
                        newDealer.Contact = _updateDealer.Contact;
                        newDealer.Fax = _updateDealer.Fax;
                        newDealer.Name = _updateDealer.Name;
                        newDealer.NewIssue = _updateDealer.NewIssue;
                        newDealer.Phone = _updateDealer.Phone;
                        newDealer.WebAddress = _updateDealer.WebAddress;
                        newDealer.Zip = _updateDealer.Zip;
                        newDealer.State = _updateDealer.State;
                        newDealer.AddressSearch = string.Format("{0}{1}{2}{3}{4}", _updateDealer.AddressLine1.Trim(), string.IsNullOrEmpty(_updateDealer.AddressLine2.Trim()) ? string.Empty : " " + _updateDealer.AddressLine2.Trim()
                    , string.IsNullOrEmpty(_updateDealer.City.Trim()) ? string.Empty : " " + _updateDealer.City.Trim(), string.IsNullOrEmpty(_updateDealer.State.Trim()) ? string.Empty : " " + _updateDealer.State.Trim(), string.IsNullOrEmpty(_updateDealer.Zip.Trim()) ? string.Empty : " " + _updateDealer.Zip.Trim());

                        dbContext.lwg_Dealer.Remove(updateDealer); // remove old dealer
                        dbContext.lwg_Dealer.Add(newDealer);// add new dealer

                        dbContext.SaveChanges();
                    }
                }
                else
                {
                    LWGLog.WriteLog("Update Dealer", string.Format("DealerID = {0} does not exist!",_updateDealer.DealerID));
                    success = false;
                }
            }
            catch (Exception ex)
            {
                LWGLog.WriteLog("Update Dealer", ex.Message);
                success = false;
            }
            return success;
        }

        public bool IsDealerExist(string dealerId)
        {
            return dbContext.lwg_Dealer.Any(d => d.DealerID == dealerId);
        }

        public void SaveDealerFromList(List<lwg_Dealer> list)
        {
            foreach (lwg_Dealer dealer in list)
            {
                if (IsDealerExist(dealer.DealerID))
                {
                    UpdateDealer(dealer,string.Empty);
                }
                else
                {
                    AddDealer(dealer);
                }
            }
        }
        
        public List<lwg_Dealer> GetDealersByFirstLetter(string firstLetter)
        {
            return dbContext.lwg_Dealer.Where(d => d.Name.StartsWith(firstLetter)).OrderBy(d=>d.Name).ToList();
        }

        public List<lwg_Dealer> GetDealersByState(string state)
        {
            return dbContext.lwg_Dealer.Where(d => d.State == state).OrderBy(d=>d.Name).ToList();
        }

        public List<string> GetAllState()
        {
            return dbContext.lwg_Dealer.OrderBy(d=>d.State).Select(d => d.State).Distinct().ToList();
        }

        public List<string> GetAllStateOfUS()
        {
            var queryStatesOfUS = from states in dbContext.Nop_StateProvince
                                  where states.CountryID == 1
                                  select states.Abbreviation;
            var USDealers = from dealers in dbContext.lwg_Dealer
                            where queryStatesOfUS.Contains(dealers.State)
                            select dealers;
            return USDealers.OrderBy(d => d.State).Select(d => d.State).Distinct().ToList();
        }

        public List<string> GetAllStateOutOfUS()
        {
            var queryStatesOfUS = from states in dbContext.Nop_StateProvince
                                  where states.CountryID == 1
                                  select states.Abbreviation;
            var USDealers = from dealers in dbContext.lwg_Dealer
                            where !queryStatesOfUS.Contains(dealers.State)
                            select dealers;
            return USDealers.OrderBy(d => d.State).Select(d => d.State).Distinct().ToList();
        }

        public bool IsExistState(string state)
        {
            return dbContext.lwg_Dealer.Any(d => d.State == state);
        }

        public bool DeleteDealer(string dealerID)
        {
            lwg_Dealer dealerDeleted = dbContext.lwg_Dealer.Where(d => d.DealerID == dealerID).FirstOrDefault();
            if (dealerDeleted != null)
            {
                dbContext.lwg_Dealer.Remove(dealerDeleted);
                dbContext.SaveChanges();

                return true;
            }
            return false;
        }

        public lwg_Dealer GetDealerByDealerID(string customerID)
        {
            return dbContext.lwg_Dealer.Where(d => d.DealerID == customerID).FirstOrDefault();
        }
    }
}
