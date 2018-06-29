<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.HeaderMenuControl"
    CodeBehind="HeaderMenu.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="SearchBox" Src="~/Modules/SearchBox.ascx" %>
<div>
    <div style="height: 39px; width: 960px; float: left; color: #111111; font-size: 15px;
        text-align: left;">
        <div id="MainMenu" class="MainMenu">
            <ul>
                <li id="sample_attach_menu_parent0" style="border-left: none"><a href="../Default.aspx"><span class="menu_col"
                    style="background-position: 632px 39px; width: 82px;"></span></a>
                    <ul>
                        <li style="">
                            <%-- <div class="clear" style="background-color: white">
                                <div class="submenu_bderTop_left" style="">
                                </div>
                                <div class="submenu_bderTop_center" style="">
                                </div>
                                <div class="submenu_bderTop_right" style="">
                                </div>
                            </div>
                            <div class="submenu_bderCenter" style="">
                            </div>
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderBot_left" style="">
                                </div>
                                <div class="submenu_bderBot_center" style="">
                                </div>
                                <div class="submenu_bderBot_right" style="">
                                </div>
                            </div>--%>
                        </li>
                    </ul>
                </li>
                <li id="sample_attach_menu_parent1"><a href="../Music-Cataloge.aspx"><span class="menu_col" style="background-position: 550px 39px;
                    width: 149px;"></span></a>
                    <ul>
                        <li style="">
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderTop_left" style="">
                                </div>
                                <div class="submenu_bderTop_center" style="">
                                </div>
                                <div class="submenu_bderTop_right" style="">
                                </div>
                            </div>
                            <div class="submenu_bderCenter" style="">
                                <asp:HyperLink ID="hplBand" runat="server" class="menuitem">
                        <div class="div_item">
                            <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                            Band
                        </div>
                                </asp:HyperLink>
                                <asp:HyperLink ID="hplFullOrchestra" runat="server" class="menuitem">
                        <div class="div_item">
                            <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                            Full Orchestra
                        </div>
                                </asp:HyperLink>
                                <asp:HyperLink ID="hplStringOrchestra" runat="server" class="menuitem">
                        <div class="div_item">
                            <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                            String Orchestra
                        </div>
                                </asp:HyperLink>
                                <asp:HyperLink ID="hplInstr_Solos_Ensembles" runat="server" class="menuitem">
                        <div class="div_item">
                            <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                            Instrumental Solos/Ensembles
                        </div>
                                </asp:HyperLink>
                                <asp:HyperLink ID="hplChoral_Vocal" runat="server" class="menuitem">
                        <div class="div_item">
                            <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                            Choral/Vocal
                        </div>
                                </asp:HyperLink>
                                <asp:HyperLink ID="hplPiano" runat="server" class="menuitem">
                        <div class="div_item1">
                            <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                            Keyboard 
                        </div>
                                </asp:HyperLink>
                            </div>
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderBot_left" style="">
                                </div>
                                <div class="submenu_bderBot_center" style="">
                                </div>
                                <div class="submenu_bderBot_right" style="">
                                </div>
                            </div>
                        </li>
                    </ul>
                </li>
                <li id="sample_attach_menu_parent2"><a href="../../Licensing_To_Record.aspx"><span class="menu_col" style="background-position: 401px 39px;
                    width: 104px;"></span></a>
                    <ul>
                        <li style="">
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderTop_left" style="">
                                </div>
                                <div class="submenu_bderTop_center" style="">
                                </div>
                                <div class="submenu_bderTop_right" style="">
                                </div>
                            </div>
                            <div class="submenu_bderCenter" style="">
                                <a href="../../Licensing_To_Record.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        To Record
                                    </div>
                                </a>
                                <%--<a href="../../Licensing_To_Videotape.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        To Videotape
                                    </div>
                                </a>--%>
                                <a href="../../Licensing_To_Arrange.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        To Arrange
                                    </div>
                                </a>
                                <%--<a href="../../Licensing_To_Sublicense.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        To Sublicense
                                    </div>
                                </a>--%>
                                <a href="../../Licensing_To_Copy_Emergency.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        To Copy (Emergency)
                                    </div>
                                </a>
                                <%--<a href="../../Licensing_Scores_Parts.aspx" class="menuitem">
                                    <div class="div_item1">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Scores/Parts
                                    </div>
                                </a>--%>
                            </div>
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderBot_left" style="">
                                </div>
                                <div class="submenu_bderBot_center" style="">
                                </div>
                                <div class="submenu_bderBot_right" style="">
                                </div>
                            </div>
                        </li>
                    </ul>
                </li>
                <li id="sample_attach_menu_parent3"><a href="../../Dealer_Whats_New.aspx"><span class="menu_col" style="background-position: 297px 39px;
                    width: 180px;"></span></a>
                    <ul>
                        <li style="">
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderTop_left" style="">
                                </div>
                                <div class="submenu_bderTop_center" style="">
                                </div>
                                <div class="submenu_bderTop_right" style="">
                                </div>
                            </div>
                            <div class="submenu_bderCenter" style="">
                                <a href="../../Dealer_Whats_New.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        What’s New
                                    </div>
                                </a><a href="../../Dealer_List.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Dealer List
                                    </div>
                                </a><a href="../../Dealer_Backstage.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Backstage (Dealers Only User ID and password required)
                                    </div>
                                </a><a href="../../Dealer_Free_Demo_Cds.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Free Recordings
                                    </div>
                                </a><a href="../../Dealer_Flyers_And_Catalogs.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Flyers and Catalogs
                                    </div>
                                </a><a href="../../Dealer_Public_Appearances_Premiers.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        News and Events
                                    </div>
                                </a><%--<a href="../../Dealer_How_To_Purchase_Music.aspx" class="menuitem">
                                    <div class="div_item1">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        How to Purchase Music
                                    </div>
                                </a>--%>
                            </div>
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderBot_left" style="">
                                </div>
                                <div class="submenu_bderBot_center" style="">
                                </div>
                                <div class="submenu_bderBot_right" style="">
                                </div>
                            </div>
                        </li>
                    </ul>
                </li>
                <li id="sample_attach_menu_parent4"><a href="../../AboutUs.aspx"><span class="menu_col" style="background-position: 117px 39px;
                    width: 117px;"></span></a>
                    <ul>
                        <li style="">
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderTop_left" style="">
                                </div>
                                <div class="submenu_bderTop_center" style="">
                                </div>
                                <div class="submenu_bderTop_right" style="">
                                </div>
                            </div>
                            <div class="submenu_bderCenter" style="">
                                <a href="../../AboutUs.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        About Us
                                    </div>
                                </a><a href="../../MeetComposers.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Meet the Composers
                                    </div>
                                </a><a href="../../Offices.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Offices
                                    </div>
                                </a><a href="../../Distribution_Companies.aspx" class="menuitem">
                                    <div class="div_item">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Related Publishers
                                    </div>
                                </a><a href="../../Music_Submission.aspx" class="menuitem">
                                    <div class="div_item1">
                                        <img src="../App_Themes/darkOrange/images/arrow_submenu_item.png" alt="" style="border: 0px;" />
                                        Music Submission
                                    </div>
                                </a>
                            </div>
                            <div class="clear" style="background-color: white">
                                <div class="submenu_bderBot_left" style="">
                                </div>
                                <div class="submenu_bderBot_center" style="">
                                </div>
                                <div class="submenu_bderBot_right" style="">
                                </div>
                            </div>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
        <div style="float: left; text-align: center; padding-top: 5px; height: 34px; width: 307px;
            text-align: left; background-image: url(../App_Themes/darkOrange/images/bg_main_menu_center.jpg);
            background-repeat: repeat;">
            <nopCommerce:SearchBox runat="server" ID="ctrlSearchBox"></nopCommerce:SearchBox>
        </div>
        <div style="background-image: url(../App_Themes/darkOrange/images/bg_main_menu_right.jpg);
            background-position: left; height: 39px; background-repeat: no-repeat; width: 21px;
            float: left;">
        </div>
    </div>
</div>
<%--<div class="headermenu">
    <div class="searchbox">
        <nopCommerce:SearchBox runat="server" ID="ctrlSearchBox">
        </nopCommerce:SearchBox>
    </div>
    <ul>
        <li><a href="<%=CommonHelper.GetStoreLocation()%>">
            <%=GetLocaleResourceString("Content.HomePage")%></a> </li>
        <% if (ProductManager.RecentlyAddedProductsEnabled)
           { %>
        <li><a href="<%=Page.ResolveUrl("~/recentlyaddedproducts.aspx")%>">
            <%=GetLocaleResourceString("Products.NewProducts")%></a> </li>
        <%} %>
        <li><a href="<%=Page.ResolveUrl("~/search.aspx")%>">
            <%=GetLocaleResourceString("Search.Search")%></a> </li>
        <li><a href="<%=Page.ResolveUrl("~/account.aspx")%>">
            <%=GetLocaleResourceString("Account.MyAccount")%></a> </li>
        <% if (BlogManager.BlogEnabled)
           { %>
        <li><a href="<%=Page.ResolveUrl("~/blog.aspx")%>">
            <%=GetLocaleResourceString("Blog.Blog")%></a> </li>
        <%} %>
        <% if (ForumManager.ForumsEnabled)
           { %>
        <li><a href="<%= SEOHelper.GetForumMainUrl()%> ">
            <%=GetLocaleResourceString("Forum.Forums")%></a></li>
        <%} %>
        <li><a href="<%=Page.ResolveUrl("~/contactus.aspx")%>">
            <%=GetLocaleResourceString("ContactUs.ContactUs")%></a> </li>
    </ul>
</div>--%>