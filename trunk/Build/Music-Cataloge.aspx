<%@ Page Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    CodeBehind="Music-Cataloge.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Music_Cataloge" %>

<%@ Register Src="~/Modules/CategoryNavigation.ascx" TagName="CategoryNavigation"
    TagPrefix="ctl" %>
<%@ Register Src="~/Modules/ProductFeatureCataloglwg.ascx" TagName="ProductFeatureCataloglwg"
    TagPrefix="ctl" %>
<%@ Register Src="~/Modules/GenreCatalog.ascx" TagName="GenreCatalog" TagPrefix="ctl" %>
<%@ Register Src="~/Modules/RecentProduct.ascx" TagName="RecentProduct" TagPrefix="ctl" %>
<%@ Register Src="~/Modules/TopComposer.ascx" TagName="TopComposer" TagPrefix="ctl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <label id="Music-Cat-page" style="display: none">
        0</label>
    <div style="text-align: left;">
        <div>
            <%--  menu left--%>
            <%--<nopCommerce:MenuMusicCataloge ID="MenuMusicCataloge1" runat="server" />--%>
            <div style="width: 220px; float: left;">
                <ctl:CategoryNavigation ID="ctlCategoryNavigation" runat="server" />
            </div>
            <%--  content--%>
            <div style="width: 730px; float: left; margin-left: 10px;">
                <%--  image--%>
                <div>
                    <img src="../App_Themes/darkOrange/images/banner1.jpg" height="130px" width="730px" />
                </div>
                <div class="clear-10">
                </div>
                <%--  box1--%>
                <center>
                    <div>
                        <div style="width: 100%; text-align: left;">
                            <ctl:ProductFeatureCataloglwg ID="ctlProductFeatureCataloglwg" runat="server" />
                        </div>
                    </div>
                </center>
                <%--  box2--%>
                <div>
                    <div class="clear" style="height: 15px;">
                    </div>
                    <div style="width: 230px; float: left;">
                        <div>
                            <div class="div_box_music_homepage1">
                            </div>
                            <div class="div_box_music_homepage2" style="width: 218px; text-align: left;">
                                <span class="div_box_music_header" style="display: block; padding-left: 10px;">Top Composers</span>
                            </div>
                            <div class="div_box_music_homepage3">
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div style="background-color: #e9e9e9;">
                            <div>
                                <div class="clear-5">
                                </div>
                                <div style="float: right; height: 370px; width: 1px">
                                </div>
                                <div style="font-size: 11px; line-height: 17px;">
                                    <%-- <div style="width: 30px; float: left; text-align: right; color: #727373;">
                                        1.<br />
                                        2.<br />
                                        3.<br />
                                        4.<br />
                                        5.<br />
                                        6.<br />
                                        7.<br />
                                        8.<br />
                                        9.<br />
                                        10.<br />
                                        11.<br />
                                        12.<br />
                                        13.<br />
                                        14.<br />
                                        15.<br />
                                        16.<br />
                                        17.<br />
                                        18.<br />
                                        19.<br />
                                        20.<br />
                                        21.<br />
                                    </div>
                                    <div style="width: 185px; float: left; padding-left: 10px; color: #003f63;">
                                        <a href="">Adult Contemporary <span style="color: #727373;">( 18 )</span><br />
                                        </a><a href="">Blues <span style="color: #727373;">( 115 )</span><br />
                                        </a><a href="">Broadway <span style="color: #727373;">( 146 )</span><br />
                                        </a><a href="">Children <span style="color: #727373;">( 559 )</span><br />
                                        </a><a href="">Christian <span style="color: #727373;">( 5031 )</span><br />
                                        </a><a href="">Christmas <span style="color: #727373;">( 3014 )</span><br />
                                        </a><a href="">CLassical <span style="color: #727373;">( 17189 )</span><br />
                                        </a><a href="">Comedy <span style="color: #727373;">( 13 )</span><br />
                                        </a><a href="">Country <span style="color: #727373;">( 9 )</span><br />
                                        </a><a href="">Folk <span style="color: #727373;">( 1580 )</span><br />
                                        </a><a href="">Holiday <span style="color: #727373;">( 1379 )</span><br />
                                        </a><a href="">Jazz <span style="color: #727373;">( 314 )</span><br />
                                        </a><a href="">Latin <span style="color: #727373;">( 393 )</span><br />
                                        </a><a href="">Movies, TV, Games <span style="color: #727373;">( 86 )</span><br />
                                        </a><a href="">New Age <span style="color: #727373;">( 42 )</span><br />
                                        </a><a href="">Opera <span style="color: #727373;">( 2070 )</span><br />
                                        </a><a href="">Pop <span style="color: #727373;">( 588 )</span><br />
                                        </a><a href="">Rock <span style="color: #727373;">( 185 )</span><br />
                                        </a><a href="">Urban, R&B <span style="color: #727373;">( 22 )</span><br />
                                        </a><a href="">Wedding <span style="color: #727373;">( 139 )</span><br />
                                        </a><a href="">World <span style="color: #727373;">( 8496 )</span><br />
                                        </a>
                                    </div>--%>
                                    <ctl:TopComposer ID="ctlTopComposer" runat="server"></ctl:TopComposer>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="div_box_music_homepage5">
                            </div>
                            <div class="div_box_music_homepage6" style="width: 218px;">
                            </div>
                            <div class="div_box_music_homepage7">
                            </div>
                        </div>
                    </div>
                    <div style="width: 230px; float: left; padding-left: 20px;">
                        <div>
                            <div class="div_box_music_homepage1">
                            </div>
                            <div class="div_box_music_homepage2" style="width: 218px; text-align: left;">
                                <span class="div_box_music_header" style="display: block; padding-left: 10px;">New Releases</span>
                            </div>
                            <div class="div_box_music_homepage3">
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div style="background-color: #e9e9e9;">
                            <div>
                                <div class="clear-5">
                                </div>
                                <div style="float: right; height: 370px; width: 1px">
                                </div>
                                <div style="font-size: 11px; line-height: 17px;">
                                    <ctl:RecentProduct runat="server" ID="ctlRecentProduct" Number="10" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div>
                                <div class="div_box_music_homepage5">
                                </div>
                                <div class="div_box_music_homepage6" style="width: 218px;">
                                </div>
                                <div class="div_box_music_homepage7">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="width: 230px; float: left; padding-left: 20px;">
                        <div>
                            <div class="div_box_music_homepage1">
                            </div>
                            <div class="div_box_music_homepage2" style="width: 218px; text-align: left;">
                                <span class="div_box_music_header" style="display: block; padding-left: 10px;">Genre</span>
                            </div>
                            <div class="div_box_music_homepage3">
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                        <div style="background-color: #e9e9e9;">
                            <div>
                                <div class="clear-5">
                                </div>
                                <div style="float: right; height: 370px; width: 1px">
                                </div>
                                <div style="font-size: 11px; line-height: 17px;">
                                    <ctl:GenreCatalog runat="server" ID="ctlGenreCatalog" />
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                            <div>
                                <div class="div_box_music_homepage5">
                                </div>
                                <div class="div_box_music_homepage6" style="width: 218px;">
                                </div>
                                <div class="div_box_music_homepage7">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
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
    </div>
    <div style="clear: both;">
    </div>

    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent1').className = "a_mainmenuActive";
       
    </script>

</asp:Content>
