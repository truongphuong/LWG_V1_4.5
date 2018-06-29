using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NopSolutions.NopCommerce.BusinessLogic.SEO;
using LWG.Business;
using LWG.Core.Models;


namespace NopSolutions.NopCommerce.Web
{
    public partial class MeetComposersPage : BaseNopPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string title = GetLocaleResourceString("PageTitle.MeetComposersPage");
                SEOHelper.RenderTitle(this, title, true);
                if (!string.IsNullOrEmpty(Request.QueryString["Filter"]))
                {
                    string alpha = "";
                    alpha = Request.QueryString["Filter"];
                    hdfalpha.Value = alpha;
                    string FirstLetter = Request.QueryString["Filter"].ToUpper();
                    int FirstLetterASCII = Asc(FirstLetter);
                    if (FirstLetterASCII >= 65 && FirstLetterASCII <= 90)
                    {
                        // Filter composers by the first initial of name.
                        this.divNonFilter.Visible = false;
                        this.divFilter.Visible = true;

                        ListcomposersByFirstLetter(FirstLetter);
                        return;
                    }

                }
                // Display all composers
                this.divNonFilter.Visible = true;
                this.divFilter.Visible = false;

                ListComposers();
            }
        }

        protected void ListcomposersByFirstLetter(string FirstLetter)
        {
            try
            {
                PersonBiz pb = new PersonBiz();

                List<lwg_Person> persons = pb.GetPersonByFirstLetter(FirstLetter);

                this.Literal4.Text = this.CreateHtml(persons, FirstLetter);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ListComposers()
        {
            try
            {
                String[] htmlStr = new String[4];

                PersonBiz pb = new PersonBiz();
                int total = 0;
                //total = pb.GetPersonNumber(string.Empty);

                List<lwg_Person> persons = pb.GetAllPersons(String.Empty, String.Empty);
                total = persons.Count;

                if (total == 0)
                    Response.Write("There is no composer yet.");

                int countEachColumn = 0;

                if (total < 26)
                    countEachColumn = int.Parse((Math.Ceiling((double)(total + 26) / 3.0)).ToString());
                else
                    countEachColumn = int.Parse((Math.Ceiling((double)(total + 26 * 2) / 2.6)).ToString());


                // List composers by 3 columns
                int currentControlIndex = 0; // the current column index that appending composers.
                int countAppended = 0; // the number of composers the current column had appended.
                int maxGroupCount = MaxGroup(persons);  // The max group items count.
                if (maxGroupCount > countEachColumn) countEachColumn = maxGroupCount;

                for (int i = 65; i < 91; i++)
                {
                    string firstLetter = Chr(i);
                    List<lwg_Person> subPersons = FilterDataRows(persons, firstLetter);
                    int subCount = subPersons.Count;
                    if (subCount > 0)
                    {
                        if (subCount >= countEachColumn)
                        {
                            if (currentControlIndex >= 1 && currentControlIndex <= 2)
                                currentControlIndex += 1;
                            htmlStr[currentControlIndex] += CreateHtml(subPersons, firstLetter);
                            countAppended = countEachColumn;
                        }
                        else if (subCount + 1 > countEachColumn - countAppended)
                        {
                            if (currentControlIndex < 2)
                                currentControlIndex += 1;

                            // Generate html
                            htmlStr[currentControlIndex] += CreateHtml(subPersons, firstLetter);

                            countAppended = subCount + 1;

                        }
                        else
                        {
                            htmlStr[currentControlIndex] += CreateHtml(subPersons, firstLetter);
                            countAppended += subCount + 1;
                        }
                    }

                    this.Literal1.Text = htmlStr[0];
                    this.Literal2.Text = htmlStr[1];
                    this.Literal3.Text = htmlStr[2];
                    //this.Literal4.Text = htmlStr[3];
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        /// <summary>
        /// get the max group persons count. group by FirstLetter.
        /// </summary>
        /// <param name="persons"></param>
        /// <returns></returns>
        protected int MaxGroup(List<lwg_Person> persons)
        {
            var result = (from c in persons
                          group c by new { c.FirstLetter } into g
                          select new
                          {
                              g.Key.FirstLetter,
                              count = g.Count()
                          }).Max(h => h.count);

            return int.Parse(result.ToString());
        }

        protected List<lwg_Person> FilterDataRows(List<lwg_Person> persons, string FirstLetter)
        {
            return persons.Where(h => h.FirstLetter == FirstLetter).OrderBy(h=>h.LastName).ToList();
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
        /// Generate html to display composers 
        /// </summary>
        /// <param name="persons">composer collection</param>
        /// <param name="firstLetter">the first initial of composers' name</param>
        /// <returns></returns>
        protected string CreateHtml(List<lwg_Person> persons, string firstLetter)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<span style='color:#FF8400; font-size:26px;'>" + firstLetter + "</span><br /><ul style='list-style:none; margin:0; padding:0;'>");

            for (int i = 0; i < persons.Count; i++)
            {
                sb.AppendLine("<li><a href=\"ComposerDetails.aspx?ComposerID=" + persons[i].PersonId + "\" alt=\"Click name for details\">" + persons[i].NameDisplay + "</a></li>");
            }

            sb.AppendLine("</ul><br />");
            sb.AppendLine("");
            return sb.ToString();
        }

        public override PageSslProtectionEnum SslProtected
        {
            get
            {
                return PageSslProtectionEnum.No;
            }
        }
    }
}
