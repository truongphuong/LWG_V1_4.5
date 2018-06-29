using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using NopSolutions.NopCommerce.BusinessLogic;
using NopSolutions.NopCommerce.BusinessLogic.Configuration.Settings;
using NopSolutions.NopCommerce.BusinessLogic.ExportImport;
using NopSolutions.NopCommerce.BusinessLogic.Localization;
using NopSolutions.NopCommerce.BusinessLogic.Manufacturers;
using NopSolutions.NopCommerce.BusinessLogic.Products;
using NopSolutions.NopCommerce.BusinessLogic.Utils;
using NopSolutions.NopCommerce.Common.Utils;
using NopSolutions.NopCommerce.BusinessLogic.Media;
using LWG.Business;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LWG.Core.Models;

namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class ShowEmailDirectoryList : System.Web.UI.UserControl
    {
        EmailDirectoryBiz emailbiz = new EmailDirectoryBiz();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string alpha = "";
                alpha = Request.QueryString["view"];                
                hdfalpha.Value = alpha;
                if (!string.IsNullOrEmpty(Request.QueryString["view"]))
                {
                    string FirstLetter = Request.QueryString["view"].ToUpper();
                    int FirstLetterASCII = Asc(FirstLetter);
                    if (FirstLetterASCII >= 65 && FirstLetterASCII <= 90)
                    {
                        // Filter composers by the first initial of name.]
                        ListEmailByFirstLetter(FirstLetter);
                        return;
                    }
                }

                // Display all composers
                ListAllEmail();
            }
        }
        private void ListEmailByFirstLetter(string firstletter)
        {
            try
            {


                List<Nop_EmailDirectory> persons = emailbiz.GetEmailByFirstLetter(firstletter);

                this.Literal1.Text = this.CreateHtml(persons, firstletter);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void ListAllEmail()
        {
            try
            {
                String[] htmlStr = new String[4];

                
                int total = 0;
                //total = pb.GetPersonNumber(string.Empty);

                List<Nop_EmailDirectory> emails = emailbiz.GetAllEmail();
                total = emails.Count;

                if (total == 0)
                    Response.Write("There is no Email yet.");

                int countEachColumn = 0;

                if (total < 26)
                    countEachColumn = int.Parse((Math.Ceiling((double)(total + 26) / 4.0)).ToString());
                else
                    countEachColumn = int.Parse((Math.Ceiling((double)(total + 26 * 2) / 4.0)).ToString());


                // List composers by 4 columns
                int currentControlIndex = 0; // the current column index that appending composers.
                int countAppended = 0; // the number of composers the current column had appended.
                int maxGroupCount = MaxGroup(emails);  // The max group items count.
                if (maxGroupCount > countEachColumn) countEachColumn = maxGroupCount;

                for (int i = 65; i < 91; i++)
                {
                    string firstLetter = Chr(i);
                    List<Nop_EmailDirectory> subEmails = FilterDataRows(emails, firstLetter);
                    int subCount = subEmails.Count;

                    if (subCount >= countEachColumn)
                    {
                        if (currentControlIndex >= 1 && currentControlIndex <= 2)
                            currentControlIndex += 1;
                        htmlStr[currentControlIndex] += CreateHtml(subEmails, firstLetter);
                        countAppended = countEachColumn;
                    }
                    else if (subCount + 1 > countEachColumn - countAppended)
                    {
                        if (currentControlIndex <= 2)
                            currentControlIndex += 1;
                        // Generate html
                        htmlStr[currentControlIndex] += CreateHtml(subEmails, firstLetter);

                        countAppended = subCount + 1;

                    }
                    else
                    {
                        htmlStr[currentControlIndex] += CreateHtml(subEmails, firstLetter);
                        countAppended += subCount + 1;
                    }
                }

                this.Literal1.Text = htmlStr[0];
                this.Literal2.Text = htmlStr[1];
                this.Literal3.Text = htmlStr[2];
                this.Literal4.Text = htmlStr[3];

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected List<Nop_EmailDirectory> FilterDataRows(List<Nop_EmailDirectory> emails, string FirstLetter)
        {
            return emails.Where(h => h.LastName.ToLower().StartsWith(FirstLetter.ToLower())).ToList();
        }

        /// <summary>
        /// get the max group persons count. group by FirstLetter.
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        protected int MaxGroup(List<Nop_EmailDirectory> emails)
        {
            int  max = 0;
            char letter = 'a';
            for(letter = 'a';letter<='z';letter++)
            {
                var q = emails.Where(t => t.LastName.ToLower().StartsWith(letter.ToString())).ToList();
                if (max < q.Count)
                    max = q.Count;
            }

            return max;
        }

        /// <summary>
        /// Generate html to display composers 
        /// </summary>
        /// <param name="persons">composer collection</param>
        /// <param name="firstLetter">the first initial of composers' name</param>
        /// <returns></returns>
        protected string CreateHtml(List<Nop_EmailDirectory> email, string firstLetter)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<span style='color:#FF8400; font-size:26px;'>" + firstLetter + "</span><br /><ul style='list-style:none; margin:0; padding:0;'>");

            for (int i = 0; i < email.Count; i++)
            {
                sb.AppendLine("<li><a href=\"ShowEmailDirectory.aspx?emailid=" + email[i].EmailID + "\" alt=\"Click name for details\">" + email[i].LastName + "</a></li>");
            }

            sb.AppendLine("</ul><br />");
            sb.AppendLine("");
            return sb.ToString();
        }

        /// <summary>
        /// Convert ASCII Code to INT.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private int Asc(string character)
        {
            if (character.Length == 1)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                int intAsciiCode = (int)asciiEncoding.GetBytes(character)[0];
                return (intAsciiCode);
            }
            else
            {
                //throw new Exception("Character is not valid.");
                return 0;
            }

        }

        /// <summary>
        /// Convert INT to ASCII Code.
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns>ASCII Code</returns>
        private string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                //throw new Exception("ASCII Code is not valid.");
                return string.Empty;
            }
        }
    }
}