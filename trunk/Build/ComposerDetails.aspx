<%@ Page Language="C#" MasterPageFile="~/MasterPages/OneColumn.master" AutoEventWireup="true"
    CodeBehind="ComposerDetails.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.ComposerDetailsPage" %>

<%@ Register src="Modules/ComposerViewTitle.ascx" tagname="ComposerViewTitle" tagprefix="lwg_uc" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph1" runat="server">
    <div class="html-header">
        Home / Authors, Composers and Clinicians / <span style="color: #0068a2;">
            <asp:Label ID="lblName" runat="server"></asp:Label></span>
    </div>
    <div class="clear-15">
    </div>
    <div>
        <div style="width: 700px; float: left; margin-right: 10px; background-color: #FFFFFF;">
            <table cellpadding="4" cellspacing="4" width="100%">
                <tr>
                    <td colspan="2" align="justify" style="color: #0068a2; font-size: 28px; padding-bottom: 15px;">
                        <asp:Literal ID="litName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="justify" valign="top" width="100px">
                        <asp:Image ID="iPicture" Width="100px" runat="server" AlternateText="Picture" />
                    </td>
                    <td align="justify" valign="top" style="min-height: 500px; vertical-align: top;">
                   
                        <span style="color: #F37032; font-size: 14px; font-weight: bold;">
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal></span><br />
                        <br />
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                      
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="right" class="alink">
                     <div style="border-top:1px dotted black;padding-top:20px;">
                     
                        <div style="width:200px;text-align:center;">
                        <asp:Image runat="server" ImageUrl="~/App_Themes/darkOrange/Images/back.png" />
                        <div class="clear-10"></div>
                        <a href="MeetComposers.aspx">Back To Main Listing</a>
                        </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left; width: 221px;">
            <div style="background-image: url(App_Themes/darkOrange/Images/bg_viewtitle.png);
                margin-top: 1px; background-repeat: no-repeat; height: 34px;
                width: 221px;">
                <a style="text-decoration: none;margin:6px 0px 0px 10px;float:left;"><span style="color:White; font-size: 16px;">
                    View Titles</span></a>
            </div>
            <div style="width:217px;">
                
                <lwg_uc:ComposerViewTitle ID="ComposerViewTitle1" runat="server" />
                
            </div>
            
            <%--<div style="background-image: url(App_Themes/darkOrange/Images/btnMeetthe1.png);
                margin-top: 1px; background-repeat: no-repeat; height: 27px; padding-top: 7px;
                padding-left: 12px; width: 224px; padding-bottom: 5px;">
                <a href="" style="text-decoration: none;"><span style="color: #666666; font-size: 16px;">
                    Upcoming Engagements</span></a>
            </div>
            <div style="background-image: url(App_Themes/darkOrange/Images/btnMeetthe1.png);
                margin-top: 1px; background-repeat: no-repeat; height: 27px; padding-top: 7px;
                padding-left: 12px; width: 224px; padding-bottom: 5px;">
                <a href="" style="text-decoration: none;"><span style="color: #666666; font-size: 16px;">
                    Clinician Opportunities</span></a>
            </div>--%>
        </div>
    </div>
    <div class="clear">
    </div>
    
    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent4').className = "a_mainmenuActive";
       
    </script>
    
</asp:Content>
