<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DealerImport.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.DealerImport" %>
<div class="section-header">
    <div class="title">
        <img src="Common/ico-catalog.png" alt="Add a new Dealer" />
        Import dealers from .csv file <a href="Dealer.aspx" title="Back to dealer list">(Back to
            dealer list)</a>
    </div>
    <div class="options">
    </div>
</div>
<div>
    <asp:FileUpload ID="fDealerUpload" runat="server" />
    <asp:Button ID="btnUploadDealer" runat="server" Text="Upload" CssClass="adminButton"
        OnClick="btnUploadDealer_Click" />
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</div>