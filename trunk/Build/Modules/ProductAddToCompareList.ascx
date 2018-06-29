<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.ProductAddToCompareList"
    CodeBehind="ProductAddToCompareList.ascx.cs" %>
<div style="padding-left: 10px;">
    <div class="div_bntBuynow1">
    </div>
    <div class="div_bntBuynow2">
      
            <asp:Button runat="server" ID="btnAddToCompareList" Text="<% $NopResources:Products.AddToCompareList %>"
            OnClick="btnAddToCompareList_Click" CausesValidation="false" CssClass="btnSearchBox" />
    </div>
    <div class="div_bntBuynow3">
    </div>
    <div class="clear">
    </div>
</div>
