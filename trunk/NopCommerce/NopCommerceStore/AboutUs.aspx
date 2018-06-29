<%@ Page Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    Inherits="NopSolutions.NopCommerce.Web.AboutUs" CodeBehind="AboutUs.aspx.cs" %>

<%@ Register TagPrefix="nopCommerce" TagName="Topic" Src="~/Modules/Topic.ascx" %>
<%@ Register Src="Modules/Contact_Us.ascx" TagName="Contact_Us" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <!--Slide-->
    <div style="text-align: left;">
        <div style="float: left; width: 227px;">
            <uc1:Contact_Us ID="Contact_Us2" runat="server" />
        </div>
        <div style="width: 720px; float: left; margin-left: 10px; background-color: #FFFFFF;">
            <div style="height: 7px;">
                <div class="ftb_bot4">
                </div>
                <div class="ftb_bot5" style="width: 706px;">
                </div>
                <div class="ftb_bot6">
                </div>
            </div>
            <div style="height: 712px; background-color: #ffffff; padding-left: 15px; padding-right: 15px;
                color: #000000">
                <div class="html-header">
                    Home / Contact Us / <span style="color: #0068a2;">About Us</span>
                </div>
                <div>
                    <nopCommerce:Topic ID="topicAboutUs" runat="server" TopicName="AboutUs"></nopCommerce:Topic>
                </div>
            </div>
            <div style="height: 7px;">
                <div class="ftb_bot1">
                </div>
                <div class="ftb_bot2" style="width: 706px;">
                </div>
                <div class="ftb_bot3">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>

    <script type="text/javascript" language="javascript">
        var i;
        for (i = 1; i <= 5; i++) {
            var t = "C" + i;
            var temp = document.getElementById(t);
            temp.removeAttribute("class");
        }
        var temp1 = document.getElementById("C1");
        temp1.setAttribute("class", "active");        
    </script>
    
    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent4').className = "a_mainmenuActive";
       
    </script>

</asp:Content>
