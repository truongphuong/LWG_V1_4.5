using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Core.Models;
using LWG.Business;
using LumenWorks.Framework.IO.Csv;
using System.IO;

namespace NopSolutions.NopCommerce.Web.Administration.Modules
{
    public partial class DealerImport :BaseNopUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUploadDealer_Click(object sender, EventArgs e)
        {
            if (fDealerUpload.HasFile)
            {
                lblError.Text = "";
                string extension = System.IO.Path.GetExtension(fDealerUpload.PostedFile.FileName);
                if (extension.ToLower() == ".csv")
                {
                    string fileName = "csv_" + DateTime.Now.Ticks + "_" + fDealerUpload.FileName;
                    string fileNamePath = Server.MapPath(LWGUtils.GetCSVPath()) + fileName;
                    fDealerUpload.SaveAs(fileNamePath);
                    List<lwg_Dealer> dealerList = ParseCSVFileToDealerList(fileNamePath);
                    DealerBiz dealerBiz = new DealerBiz();
                    dealerBiz.SaveDealerFromList(dealerList);
                }
                else
                {
                    lblError.Text = "Invalid extension.";
                }
            }
            else
            {
                lblError.Text = "Please choose upload file";
            }
        }

        List<lwg_Dealer> ParseCSVFileToDealerList(string fullPath)
        {
            List<lwg_Dealer> dealerList = new List<lwg_Dealer>();
            CsvReader csv = new CsvReader(new StreamReader(fullPath), true);
            csv.MissingFieldAction = MissingFieldAction.ReplaceByNull;

            int fieldCount = csv.FieldCount;
            string[] headers = csv.GetFieldHeaders();
            while (csv.ReadNextRecord())
            {
                lwg_Dealer dealer = new lwg_Dealer();

                // Dealer ID
                if (csv[0] != null)
                {
                    dealer.DealerID = csv[0];
                }
                else
                {
                    LWGLog.WriteLog("import dealer", "null of dealerId");
                    continue;
                }

                // Dealer Name
                if (csv[1] != null)
                {
                    dealer.Name = csv[1];
                }
                else
                {
                    LWGLog.WriteLog("import dealer", string.Format("{0}: empty name", csv[0]));
                    continue;
                }

                // Address Line 1
                if (csv[2] != null)
                    dealer.AddressLine1 = csv[2];
                // Address Line 2
                if (csv[3] != null)
                    dealer.AddressLine2 = csv[3];
                // City
                if (csv[4] != null)
                    dealer.City = csv[4];
                // State
                if (csv[5] != null)
                    dealer.State = csv[5];
                // Zip
                if (csv[6] != null)
                    dealer.Zip = csv[6];
                // Phone
                if (csv[7] != null)
                    dealer.Phone = csv[7];
                // Fax
                if (csv[8] != null)
                    dealer.Fax = csv[8];
                // WebAddress
                if (csv[9] != null)
                    dealer.WebAddress = csv[9];
                // Contact
                if (csv[10] != null)
                    dealer.Contact = csv[10];
                // NewIssue
                if (csv[11] != null)
                    dealer.NewIssue = csv[11];

                dealerList.Add(dealer);
            }

            return dealerList;
        }
    }
}