<%@ Page Language="C#" MasterPageFile="~/MasterPages/OneColumn.master" AutoEventWireup="true"
    Inherits="NopSolutions.NopCommerce.Web.CheckoutPaymentMethodPage" CodeBehind="CheckoutPaymentMethod.aspx.cs" %>

<%@ Register Src="~/Modules/OrderProgress.ascx" TagName="OrderProgress" TagPrefix="nopCommerce" %>
<%@ Register TagPrefix="nopCommerce" TagName="CheckoutPaymentMethod" Src="~/Modules/CheckoutPaymentMethod.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="OrderSummary" Src="~/Modules/OrderSummary.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">
    <div class="checkout-page">
        <nopCommerce:OrderProgress ID="OrderProgressControl" runat="server" OrderProgressStep="Payment" />
        <div class="clear">
        </div>
        <div class="page-title">
           <%=GetLocaleResourceString("Checkout.SelectPaymentMethod")%>
        </div>
        <div class="clear">
        </div>
        <nopCommerce:CheckoutPaymentMethod ID="ctrlCheckoutPaymentMethod" runat="server" />
        <div class="clear">
        </div>
        <div class="page-title">
            <%=GetLocaleResourceString("Checkout.OrderSummary")%>
        </div>
        <div class="clear">
        </div>
        <div>
            <nopCommerce:OrderSummary ID="OrderSummaryControl" runat="server" IsShoppingCart="false">
            </nopCommerce:OrderSummary>
        </div>
    </div>
</asp:Content>
