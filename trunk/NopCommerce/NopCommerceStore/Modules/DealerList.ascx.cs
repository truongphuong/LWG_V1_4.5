using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LWG.Core.Models;
using System.Text;
using LWG.Business;
using System.Collections;

namespace NopSolutions.NopCommerce.Web.Modules
{
    public partial class DealerList : BaseNopUserControl
    {
        //private const string allStatesOutOfUS = "allout";
        private const string allStatesOfUS = "all";
        private const double columnRatio = 2.6;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSortType();

                if (!string.IsNullOrEmpty(Request.QueryString["Filter"]))
                {
                    string alpha = "";
                    alpha = Request.QueryString["Filter"];
                    hdfalpha.Value = alpha;
                    string FirstLetter = Request.QueryString["Filter"].ToUpper();
                    int FirstLetterASCII = Asc(FirstLetter);
                    if (FirstLetterASCII >= 65 && FirstLetterASCII <= 90)
                    {
                        ListDealerByFirstLetter(FirstLetter);
                        ddlSortType.ClearSelection();
                        ddlSortType.Items.FindByText("Name").Selected = true;
                        divAlphabet.Visible = true;
                        divState.Visible = false;
                        return;
                    }
                }

                if (!string.IsNullOrEmpty(Request.QueryString["State"]))
                {
                    string state = string.Empty;
                    state = Request.QueryString["State"].ToUpper();
                    DealerBiz dealerBiz = new DealerBiz();
                    if (dealerBiz.IsExistState(state))
                    {
                        ListDealerByState(state);
                        ddlSortType.ClearSelection();
                        ddlSortType.Items.FindByText("State").Selected = true;

                        divState.Visible = true;
                        divAlphabet.Visible = false;
                        ltrStateMenu.Text = CreateSelectionStateMenu(dealerBiz.GetAllStateOfUS(), state, false);
                        ltrOutofUsState.Text = CreateSelectionStateMenu(dealerBiz.GetAllStateOutOfUS(), state, true);
                        return;
                    }
                    else
                        if (state.ToLower() == allStatesOfUS)
                        {
                            ListDealers(DealerSortType.State);
                            ddlSortType.ClearSelection();
                            ddlSortType.Items.FindByText("State").Selected = true;
                            divState.Visible = true;
                            divAlphabet.Visible = false;
                            ltrStateMenu.Text = CreateSelectionStateMenu(dealerBiz.GetAllStateOfUS(), state.ToLower(), false);
                            ltrOutofUsState.Text = CreateSelectionStateMenu(dealerBiz.GetAllStateOutOfUS(), state.ToLower(), true);
                            return;
                        }
                }


                // default load all dealer
                ListDealers(DealerSortType.Name);
                divAlphabet.Visible = true;
                divState.Visible = false;
            }
        }

        private void LoadSortType()
        {
            string[] names = Enum.GetNames(typeof(DealerSortType));
            Array values = Enum.GetValues(typeof(DealerSortType));
            Hashtable ht = new Hashtable();
            for (int i = 0; i < names.Length; i++)
                ht.Add(names[i], (int)values.GetValue(i));
            ddlSortType.DataSource = ht;
            ddlSortType.DataTextField = "Key";
            ddlSortType.DataValueField = "Value";
            ddlSortType.DataBind();
        }
        private string CreateHtml(List<lwg_Dealer> dealerList, string firstLetter, bool bShowFirstLetter)
        {
            StringBuilder sb = new StringBuilder();
            if (bShowFirstLetter)
                sb.AppendLine("<span style='color:#FF8400; font-size:26px;'>" + firstLetter + "</span><br/>");
            else
                sb.Append("<div style='height:30px'></div>");
            sb.Append("<ul style='list-style:none; margin:0; padding:0;'>");
            sb.AppendLine("<div>");
            foreach (lwg_Dealer dealer in dealerList)
            {
                sb.AppendLine(string.Format("<div class='dealerName'><span>{0}</span></div>", dealer.Name));
                if (!string.IsNullOrEmpty(dealer.AddressLine1))
                {
                    sb.AppendLine(string.Format("<div class='dealerAddress'><span>{0}</span></div>", dealer.AddressLine1));
                }
                if (!string.IsNullOrEmpty(dealer.AddressLine2))
                {
                    sb.AppendLine(string.Format("<div class='dealerAddress'><span>{0}</span></div>", dealer.AddressLine2));
                }
                if (!string.IsNullOrEmpty(dealer.City) && !string.IsNullOrEmpty(dealer.State))
                {
                    sb.AppendLine(string.Format("<div class='dealerAddress'><span>{0}, {1} {2} </span></div>", dealer.City, dealer.State, dealer.Zip));
                }
                if (!string.IsNullOrEmpty(dealer.Phone) && dealer.Phone != "0")
                {
                    sb.AppendLine(string.Format("<div class='dealerAddress'><span>Phone: {0}</span></div>", dealer.Phone));
                }
                if (!string.IsNullOrEmpty(dealer.Fax) && dealer.Fax != "0")
                {
                    sb.AppendLine(string.Format("<div class='dealerAddress'><span>Fax: {0}</span></div>", dealer.Fax));
                }
                if (!string.IsNullOrEmpty(dealer.WebAddress))
                {
                    sb.AppendLine(string.Format("<div class='dealerWebLink'><a href='{0}' target='_blank'>{1}</a></div>", dealer.WebAddress.Contains("http://") ? dealer.WebAddress : string.Format("http://{0}", dealer.WebAddress), dealer.WebAddress));
                }
                sb.Append("<div style='padding-bottom:10px'></div>");
            }
            sb.AppendLine("</div>");
            return sb.ToString();
        }

        protected void ListDealerByFirstLetter(string FirstLetter)
        {
            try
            {
                DealerBiz pb = new DealerBiz();

                List<lwg_Dealer> dealers = pb.GetDealersByFirstLetter(FirstLetter);
                int total = dealers.Count;
                int countEachColumn = int.Parse((Math.Ceiling((double)(total / 2.5)).ToString()));
                this.ltrDealers1.Text = this.CreateHtml(dealers.Take(countEachColumn).ToList(), FirstLetter, true);
                this.ltrDealers2.Text = this.CreateHtml(dealers.Skip(countEachColumn).Take(countEachColumn).ToList(), FirstLetter, false);
                this.ltrDealers3.Text = this.CreateHtml(dealers.Skip(countEachColumn * 2).Take(countEachColumn).ToList(), FirstLetter, false);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private string CreateSelectionStateMenu(List<string> stateList, string activeState, bool outOfUS)
        {
            StringBuilder sb = new StringBuilder();
            if (!outOfUS)
                if (activeState.ToLower() == allStatesOfUS)
                    sb.AppendFormat("<a class='a_active' href='Dealer_List.aspx?state={0}' alt=''>All</a>", allStatesOfUS);
                else
                    sb.AppendFormat("<a href='Dealer_List.aspx?state={0}' alt=''>All</a>", allStatesOfUS);

            foreach (string state in stateList)
            {
                if (state.ToLower() == activeState.ToLower())
                    sb.Append(string.Format("<a class='a_active' href='Dealer_List.aspx?state={0}' alt=''>{0}</a>", state));
                else
                    sb.Append(string.Format("<a href='Dealer_List.aspx?state={0}' alt=''>{0}</a>", state));
            }
            return sb.ToString();

        }
        protected void ListDealerByState(string State)
        {
            try
            {
                DealerBiz dealerBiz = new DealerBiz();

                List<lwg_Dealer> dealers = dealerBiz.GetDealersByState(State);
                int total = dealers.Count;
                int countEachColumn = int.Parse((Math.Ceiling((double)(total / 3.0)).ToString()));
                this.ltrDealers1.Text = this.CreateHtml(dealers.Take(countEachColumn).ToList(), State, true);
                this.ltrDealers2.Text = this.CreateHtml(dealers.Skip(countEachColumn).Take(countEachColumn).ToList(), State, false);
                this.ltrDealers3.Text = this.CreateHtml(dealers.Skip(countEachColumn * 2).Take(countEachColumn).ToList(), State, false);

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void ListDealers(DealerSortType sortType)
        {
            try
            {
                String[] htmlStr = new String[3];

                DealerBiz dealerBiz = new DealerBiz();
                int total = 0;
                lblOutOfUS.Visible = false;
                // List composers by 3 columns
                int currentControlIndex = 0; // the current column index that appending composers.
                int countAppended = 0; // the number of composers the current column had appended.
                if (sortType == DealerSortType.Name)
                {
                    #region sort by firtletter of name

                    List<lwg_Dealer> dealers = dealerBiz.GetAllDealers();
                    total = dealers.Count;

                    if (total == 0)
                        Response.Write("There is no dealer yet.");

                    int countEachColumn = 0;

                    countEachColumn = int.Parse((Math.Ceiling((double)(total / columnRatio)).ToString()));

                    int maxGroupCount = MaxFirstLetterGroup(dealers);  // The max group items count.
                    if (maxGroupCount > countEachColumn) countEachColumn = maxGroupCount;


                    for (int i = 65; i < 91; i++)
                    {
                        string firstLetter = Chr(i);
                        List<lwg_Dealer> subDealers = FilterDealerByFirstLetter(dealers, firstLetter);
                        int subCount = subDealers.Count;
                        if (subCount > 0)
                        {
                            if (subCount >= countEachColumn)
                            {
                                if (currentControlIndex >= 1 && currentControlIndex <= 2)
                                    currentControlIndex += 1;
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, firstLetter, true);
                                countAppended = countEachColumn;
                            }
                            else if (subCount + 1 > countEachColumn - countAppended)
                            {
                                if (currentControlIndex < 2)
                                    currentControlIndex += 1;

                                // Generate html
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, firstLetter, true);

                                countAppended = subCount + 1;

                            }
                            else
                            {
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, firstLetter, true);
                                countAppended += subCount + 1;
                            }
                        }


                    }
                    this.ltrDealers1.Text = htmlStr[0];
                    this.ltrDealers2.Text = htmlStr[1];
                    this.ltrDealers3.Text = htmlStr[2];
                    #endregion
                }
                else
                {
                    #region  sort by state
                    lblOutOfUS.Visible = true;
                    #region US Dealers
                    List<lwg_Dealer> dealers = dealerBiz.GetAllUSDealers();
                    total = dealers.Count;

                    if (total == 0)
                        Response.Write("There is no dealer yet.");

                    int countEachColumn = 0;

                    countEachColumn = int.Parse((Math.Ceiling((double)(total / columnRatio)).ToString()));

                    int maxGroupCount = MaxStateGroup(dealers);  // The max group items count.
                    if (maxGroupCount > countEachColumn) countEachColumn = maxGroupCount;

                    List<string> stateList = dealerBiz.GetAllStateOfUS();
                    foreach (string state in stateList)
                    {
                        List<lwg_Dealer> subDealers = FilterDealerByState(dealers, state);
                        int subCount = subDealers.Count;
                        if (subCount > 0)
                        {
                            if (subCount >= countEachColumn)
                            {
                                if (currentControlIndex >= 1 && currentControlIndex <= 2)
                                    currentControlIndex += 1;
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, state, true);
                                countAppended = countEachColumn;
                            }
                            else if (subCount + 1 > countEachColumn - countAppended + 5)
                            {
                                if (currentControlIndex < 2)
                                    currentControlIndex += 1;

                                // Generate html
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, state, true);

                                countAppended = subCount + 1;

                            }
                            else
                            {
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, state, true);
                                countAppended += subCount + 1;
                            }
                        }
                    }

                    this.ltrDealers1.Text = htmlStr[0];
                    this.ltrDealers2.Text = htmlStr[1];
                    this.ltrDealers3.Text = htmlStr[2];
                    #endregion
                    #region Out of US Dealers
                    dealers = dealerBiz.GetAllOutOfUSDealers();
                    total = dealers.Count;

                    if (total == 0)
                        return;

                    htmlStr = new String[3];
                    countEachColumn = 0;
                    countAppended = 0;
                    currentControlIndex = 0;
                    countEachColumn = int.Parse((Math.Ceiling((double)(total / columnRatio)).ToString()));

                    stateList = dealerBiz.GetAllStateOutOfUS();
                    foreach (string state in stateList)
                    {
                        List<lwg_Dealer> subDealers = FilterDealerByState(dealers, state);
                        int subCount = subDealers.Count;
                        if (subCount > 0)
                        {
                            if (subCount >= countEachColumn)
                            {
                                if (currentControlIndex >= 1 && currentControlIndex <= 2)
                                    currentControlIndex += 1;
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, state, true);
                                countAppended = countEachColumn;
                            }
                            else if (subCount + 1 > countEachColumn - countAppended + 5)
                            {
                                if (currentControlIndex < 2)
                                    currentControlIndex += 1;

                                // Generate html
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, state, true);

                                countAppended = subCount + 1;

                            }
                            else
                            {
                                htmlStr[currentControlIndex] += CreateHtml(subDealers, state, true);
                                countAppended += subCount + 1;
                            }
                        }


                    }
                    this.ltrDealers4.Text = htmlStr[0];
                    this.ltrDealers5.Text = htmlStr[1];
                    this.ltrDealers6.Text = htmlStr[2];
                    #endregion
                    #endregion
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected List<lwg_Dealer> FilterDealerByFirstLetter(List<lwg_Dealer> dealers, string FirstLetter)
        {
            return dealers.Where(d => d.Name.Substring(0, 1) == FirstLetter).OrderBy(d => d.Name).ToList();
        }

        protected List<lwg_Dealer> FilterDealerByState(List<lwg_Dealer> dealers, string state)
        {
            return dealers.Where(d => d.State == state).OrderBy(d => d.Name).ToList();
        }

        private int MaxFirstLetterGroup(List<lwg_Dealer> dealers)
        {
            var result = (from c in dealers
                          group c by new { FirstLetter = c.Name.Substring(0, 1) } into g
                          select new
                          {
                              g.Key.FirstLetter,
                              count = g.Count()
                          }).Max(h => h.count);

            return int.Parse(result.ToString());
        }
        private int MaxStateGroup(List<lwg_Dealer> dealers)
        {
            var result = (from c in dealers
                          group c by new { c.State } into g
                          select new
                          {
                              g.Key.State,
                              count = g.Count()
                          }).Max(h => h.count);

            return int.Parse(result.ToString());
        }
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

        protected void ddlSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSortType.SelectedItem.Text == "Name")
            {
                Response.Redirect(string.Format("{0}?filter=all", Request.Path));
            }
            else
                if (ddlSortType.SelectedItem.Text == "State")
                {
                    Response.Redirect(string.Format("{0}?state=all", Request.Path));
                }
        }
    }
    enum DealerSortType { Name, State }
}