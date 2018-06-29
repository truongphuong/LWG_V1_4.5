<%@ Page Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    CodeBehind="Dealer_Backstage.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Dealer_Backstage" %>

<%@ Register Src="Modules/Dealers_Promotions.ascx" TagName="Dealers_Promotions" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <div style="text-align: left;">
        <div style="float: left; width: 227px;">
            <uc1:Dealers_Promotions ID="Dealers_Promotions1" runat="server" />
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
                    Home / Dealers/Promotions / <span style="color: #0068a2;">Backstage</span>
                </div>
                <div class="html-title">
                    Backstage
                </div>
                <div>
                    
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
    </div>

    <script type="text/javascript" language="javascript">
        var i;
        for (i = 1; i <= 5; i++) {
            var t = "D" + i;
            var temp = document.getElementById(t);
            temp.removeAttribute("class");
        }
        var temp1 = document.getElementById("D2");
        temp1.setAttribute("class", "active");        
    </script>
    
    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent3').className = "a_mainmenuActive";
       
    </script>

</asp:Content>
