<%@ Page Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    Inherits="NopSolutions.NopCommerce.Web.PasswordRecoveryPage" Codebehind="PasswordRecovery.aspx.cs" %>

<%@ Register TagPrefix="nopCommerce" TagName="PasswordRecovery" Src="~/Modules/CustomerPasswordRecovery.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
   
     <div style="width: 960px;">
        <div>
            <div class="Box4_top1" style="">
            </div>
            <div class="Box4_top2" style="width: 950px;">
            </div>
            <div class="Box4_top3" style="">
            </div>
        </div>
        <div style="background-color: #ffffff; padding-left: 9px; padding-right: 9px; color: #000000; height:300px">
            <nopCommerce:PasswordRecovery ID="ctrlPasswordRecovery" runat="server" />
           
        </div>
        <div>
            <div class="Box4_bot1" style="">
            </div>
            <div class="Box4_bot2" style="width: 950px;">
            </div>
            <div class="Box4_bot3" style="">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
