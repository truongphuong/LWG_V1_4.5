<%@ Page Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    Inherits="NopSolutions.NopCommerce.Web.Default" CodeBehind="Default.aspx.cs" %>

<%@ Register TagPrefix="nopCommerce" TagName="TodaysPoll" Src="~/Modules/TodaysPoll.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="NewsList" Src="~/Modules/NewsList.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="HomePageCategories" Src="~/Modules/HomePageCategories.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="HomePageProducts" Src="~/Modules/HomePageProducts.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="BestSellers" Src="~/Modules/BestSellers.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="Topic" Src="~/Modules/Topic.ascx" %>
<%@ Register Src="~/Modules/ProductFeaturelwg.ascx" TagName="ProductFeaturelwg" TagPrefix="ctl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <%--banner--%>
    <div>
        <div id="header">
            <div style="visibility: visible; position: relative; margin: 0pt; background: none repeat scroll 0% 0% transparent;
                border: medium none; width: 800px; height: 300px;" id="photos" class="galleryview">
                <div class="panel">
                    <img src="../App_Themes/darkOrange/images/img1.png" width="960">
                </div>
                <div class="panel">
                    <img src="../App_Themes/darkOrange/images/img2.png" width="960">
                </div>
                <%--<div class="panel">
                    <img src="../App_Themes/darkOrange/images/img1.png" width="960">
                </div>
                <div class="panel">
                    <img src="../App_Themes/darkOrange/images/img2.png" width="960">
                </div>--%>
                <div style="top: 300px; left: 200px; width: 150px; height: 37px;">
                    <ul style="margin: 0pt; padding: 0pt; width: 150px; position: absolute; z-index: 500;
                        top: 0pt; left: 0pt; height: 25px; background: none repeat scroll 0% 0% transparent;"
                        class="filmstrip">
                        <li style="float: left; position: fixed; height: 16px; z-index: 901; margin-top: 5px;
                            margin-bottom: 0px; margin-right: 10px; padding: 0pt; cursor: pointer;">
                            <img style="border: medium none;" src="../App_Themes/darkOrange/images/silde-nav1.png"
                                alt="Effet du soleil" title="Effet du soleil"></li>
                        <li style="float: left; position: relative; height: 16px; z-index: 901; margin-top: 5px;
                            margin-bottom: 0px; margin-right: 10px; padding: 0pt; cursor: pointer;">
                            <img style="border: medium none;" src="../App_Themes/darkOrange/images/silde-nav1.png"
                                alt="Eden" title="Eden"></li>
                        <%--<li style="float: left; position: relative; height: 16px; z-index: 901; margin-top: 5px;
                            margin-bottom: 0px; margin-right: 10px; padding: 0pt; cursor: pointer;">
                            <img style="border: medium none;" src="../App_Themes/darkOrange/images/silde-nav1.png"
                                alt="Snail on the Corn" title="Snail on the Corn"></li>
                        <li style="float: left; position: relative; height: 16px; z-index: 901; margin-top: 5px;
                            margin-bottom: 0px; margin-right: 10px; padding: 0pt; cursor: pointer;">
                            <img style="border: medium none;" src="../App_Themes/darkOrange/images/silde-nav1.png"
                                alt="Flowers" title="Flowers"></li>--%>
                    </ul>
                </div>
                <div id="pointer" style="display: none;">
                </div>
            </div>
        </div>
    </div>
    <%--Featured Music--%>
    <div style="text-align: left; margin-top: 15px;">
        <div>
            <span style="color: #ffe66b; font-size: 25px; font-weight: bold;">New for <%=DateTime.Now.Year%></span>
        </div>
        <div class="clear-15">
        </div>
        <div>
            <ctl:ProductFeaturelwg ID="ctlProductFeaturelwg" runat="server"></ctl:ProductFeaturelwg>
        </div>
    </div>
    <%--Box 2--%>
    <div style="text-align: left; margin-top: 10px;">
        <div style="padding-top: 20px;">
            <div style="width: 227px; height: 325px; float: left;">
                <div>
                    <div class="div_box_music_homepage1">
                    </div>
                    <div class="div_box_music_homepage2">
                        <span class="div_box_music_header">Music Catalog</span>
                    </div>
                    <div class="div_box_music_homepage3">
                    </div>
                </div>
                <div class="div_box_music_homepage4">
                    <div style="text-align: center;">
                        <img src="../App_Themes/darkOrange/images/musiccatalog.jpg" style="padding-top: 12px;" />
                    </div>
                    <div style="color: #034568; padding-left: 18px; font-weight: bold; padding-top: 10px;
                        line-height: 15px;">
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="">Listen to a sample</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="">View scores</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="">Search catalog</a>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="div_box_music_homepage5">
                    </div>
                    <div class="div_box_music_homepage6">
                    </div>
                    <div class="div_box_music_homepage7">
                    </div>
                </div>
            </div>
            <div style="width: 227px; height: 325px; float: left; padding-left: 17px; padding-right: 9px;">
                <div>
                    <div class="div_box_music_homepage1">
                    </div>
                    <div class="div_box_music_homepage2">
                        <span class="div_box_music_header">Licensing</span>
                    </div>
                    <div class="div_box_music_homepage3">
                    </div>
                </div>
                <div class="div_box_music_homepage4">
                    <div style="text-align: center;">
                        <img src="../App_Themes/darkOrange/images/Licensing.jpg" style="padding-top: 12px;" />
                    </div>
                    <div style="color: #034568; padding-left: 18px; font-weight: bold; padding-top: 10px;
                        line-height: 15px;">
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Licensing_To_Record.aspx">To record</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Licensing_To_Videotape.aspx">To videotape</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Licensing_To_Arrange.aspx">To arrange</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Licensing_To_Sublicense.aspx">To sublicense</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Licensing_To_Copy_Emergency.aspx">To copy (emergency)</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Licensing_Scores_Parts.aspx">To scores / Parts</a>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="div_box_music_homepage5">
                    </div>
                    <div class="div_box_music_homepage6">
                    </div>
                    <div class="div_box_music_homepage7">
                    </div>
                </div>
            </div>
            <div style="width: 227px; height: 325px; float: left; padding-left: 9px; padding-right: 17px;">
                <div>
                    <div class="div_box_music_homepage1">
                    </div>
                    <div class="div_box_music_homepage2">
                        <span class="div_box_music_header">Dealer/Promotions</span>
                    </div>
                    <div class="div_box_music_homepage3">
                    </div>
                </div>
                <div class="div_box_music_homepage4">
                    <div style="text-align: center;">
                        <img src="../App_Themes/darkOrange/images/Dealers_Promotions.jpg" style="padding-top: 12px;" />
                    </div>
                    <div style="color: #034568; padding-left: 18px; font-weight: bold; padding-top: 10px;
                        line-height: 15px;">
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Dealer_Whats_New.aspx">What's new</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Dealer_List.aspx">Dealer list</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Dealer_Backstage.aspx">Backstage</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Dealer_Free_Demo_Cds.aspx">Free Recordings</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Dealer_Flyers_And_Catalogs.aspx">Flyers and catalogs </a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Dealer_Public_Appearances_Premiers.aspx">News and Events</a>
                        </div>
                        <%--<div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Dealer_How_To_Purchase_Music.aspx">How to purchase music</a>
                        </div>--%>
                    </div>
                </div>
                <div>
                    <div class="div_box_music_homepage5">
                    </div>
                    <div class="div_box_music_homepage6">
                    </div>
                    <div class="div_box_music_homepage7">
                    </div>
                </div>
            </div>
            <div style="width: 227px; height: 325px; float: right;">
                <div>
                    <div class="div_box_music_homepage1">
                    </div>
                    <div class="div_box_music_homepage2">
                        <span class="div_box_music_header">Contact</span>
                    </div>
                    <div class="div_box_music_homepage3">
                    </div>
                </div>
                <div class="div_box_music_homepage4">
                    <div style="text-align: center;">
                        <img src="../App_Themes/darkOrange/images/contact.jpg" style="padding-top: 12px;" />
                    </div>
                    <div style="color: #034568; padding-left: 18px; font-weight: bold; padding-top: 10px;
                        line-height: 15px;">
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="MeetComposers.aspx">Meet the composers</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="ShowEmailDirectoryList.aspx">Email directory of company</a>
                        </div>
                        <div style="padding-top: 2px;">
                            <img src="../App_Themes/darkOrange/images/dot_arrow.png" align="top" style="padding-top: 5px;" />&nbsp;&nbsp;&nbsp;<a
                                href="Music_Submission.aspx">Submission guidelines</a>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="div_box_music_homepage5">
                    </div>
                    <div class="div_box_music_homepage6">
                    </div>
                    <div class="div_box_music_homepage7">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
    <%--Box 3--%>
    <div style="text-align: left;">
        <div style="padding-top: 20px;">
            <div>
                <div class="Box3_top1" style="">
                </div>
                <div class="Box3_top2" style="width: 950px;">
                </div>
                <div class="Box3_top3" style="">
                </div>
            </div>
            <div class="Box3_header" style="">
                <span style="">Distributors of</span>
            </div>
            <%--<div style="background-color: #f9f9f9; color: Black; height: 252px; text-align: center;">
                <img src="../App_Themes/darkOrange/images/group_logo_adv.jpg" style="padding-top: 5px;" />
            </div>--%>
            <div style="background-color: #222121; color: Black; height: 252px; text-align: center;">
                <div style="float: left; width: 820px;">
                    <div style="float: left; padding-top: 20px; padding-left: 15px;">
                        <img src="../App_Themes/darkOrange/images/distributors_item10.png" style="padding-right: 10px;" />
                        <img src="../App_Themes/darkOrange/images/distributors_item9.png" style="padding-right: 10px;" />
                        <img src="../App_Themes/darkOrange/images/distributors_item8.png" style="padding-right: 10px;" />
                        <img src="../App_Themes/darkOrange/images/distributors_item7.png" style="padding-right: 10px;" />
                        <img src="../App_Themes/darkOrange/images/distributors_item2.png" style="padding-right: 10px;" />
                    </div>
                    <div style="float: left; padding-top: 20px; padding-left: 15px;">
                        <img src="../App_Themes/darkOrange/images/distributors_item6.png" style="padding-right: 20px;" />
                        <img src="../App_Themes/darkOrange/images/distributors_item5.png" style="padding-right: 20px;
                            padding-bottom: 20px;" />
                        <img src="../App_Themes/darkOrange/images/distributors_item4.png" style="padding-right: 30px;
                            padding-bottom: 20px;" />
                        <img src="../App_Themes/darkOrange/images/distributors_item3.png" style="padding-right: 30px;
                            padding-bottom: 25px;" />
                        <img src="../App_Themes/darkOrange/images/Distributors_item11.jpg" style="padding-right: 20px;" />
                    </div>
                </div>
                <div style="float: right; padding-top: 20px;">
                    <img src="../App_Themes/darkOrange/images/distributors_item1.png" style="padding-right: 20px;" />
                </div>
            </div>
        </div>
    </div>
    <%--  <nopCommerce:HomePageProducts ID="ctrlHomePageProducts" runat="server" />--%>
    <%--Old code--%>
    <%--
    <nopCommerce:Topic ID="topicHomePageText" runat="server" TopicName="HomePageText"
        OverrideSEO="false"></nopCommerce:Topic>
    <div class="clear">
    </div>
    <nopCommerce:HomePageCategories ID="ctrlHomePageCategories" runat="server" />
    <div class="clear">
    </div>
    <nopCommerce:HomePageProducts ID="ctrlHomePageProducts" runat="server" />
    <div class="clear">
    </div>
    <nopCommerce:BestSellers ID="ctrlBestSellers" runat="server" />
    <div class="clear">
    </div>
    <nopCommerce:NewsList ID="ctrlNewsList" runat="server" />
    <div class="clear">
    </div>
    <nopCommerce:TodaysPoll ID="ctrlTodaysPoll" runat="server" />--%>

    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent0').className = "a_mainmenuActive";
       
    </script>

</asp:Content>
