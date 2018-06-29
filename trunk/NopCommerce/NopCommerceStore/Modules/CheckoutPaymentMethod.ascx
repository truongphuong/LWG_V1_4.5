<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CheckoutPaymentMethodControl"
    CodeBehind="CheckoutPaymentMethod.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="PaypalExpressButton" Src="~/Modules/PaypalExpressButton.ascx" %>
<div class="checkout-data">
    <asp:Panel runat="server" ID="pnlRewardPoints" CssClass="userewardpoints">
        <asp:CheckBox runat="server" ID="cbUseRewardPoints" Text="Use my reward points" />
    </asp:Panel>
    <div class="clear">
    </div>
    <nopCommerce:PaypalExpressButton runat="server" ID="btnPaypalExpressButton"></nopCommerce:PaypalExpressButton>
    <div class="clear">
    </div>
    <div class="payment-methods">
        <asp:PlaceHolder runat="server" ID="phSelectPaymentMethod">
            <asp:DataList runat="server" ID="dlPaymentMethod" DataKeyField="PaymentMethodId">
                <ItemTemplate>
                    <div class="payment-method-item" style="text-align: left;">
                        <nopCommerce:GlobalRadioButton runat="server" ID="rdPaymentMethod" Checked="false"
                            GroupName="paymentMethodGroup" />
                        <%#Server.HtmlEncode(Eval("VisibleName").ToString()) %>
                        <%#Server.HtmlEncode(FormatPaymentMethodInfo(((PaymentMethod)Container.DataItem)))%>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <div class="clear">
            </div>
            <div>
                <div class="div_bntBuynow1">
                </div>
                <div class="div_bntBuynow2">
                    <asp:Button runat="server" ID="btnNextStep" Text="<% $NopResources:Checkout.NextButton %>"
                        OnClick="btnNextStep_Click" CssClass="btnSearchBox" ValidationGroup="SelectPaymentMethod" />
                </div>
                <div class="div_bntBuynow3">
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="clear">
        </div>
        <asp:Panel runat="server" ID="pnlPaymentMethodsError" Visible="false" CssClass="error-block">
            <div class="message-error">
                <asp:Label runat="server" ID="lPaymentMethodsError"></asp:Label>
            </div>
        </asp:Panel>
    </div>
</div>
