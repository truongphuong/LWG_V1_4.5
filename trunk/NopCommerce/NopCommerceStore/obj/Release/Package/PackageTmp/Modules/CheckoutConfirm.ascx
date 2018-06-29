<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CheckoutConfirmControl"
    CodeBehind="CheckoutConfirm.ascx.cs" %>
<div class="checkout-data">
    <div class="confirm-order">
        <div>
            <div class="div_bntBuynow1">
            </div>
            <div class="div_bntBuynow2">
                <asp:Button runat="server" ID="btnNextStep" Text="<% $NopResources:Checkout.ConfirmButton %>"
                    OnClick="btnNextStep_Click" CssClass="btnSearchBox" ValidationGroup="CheckoutConfirm" />
            </div>
            <div class="div_bntBuynow3">
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="error-block">
            <div class="message-error">
                <asp:Literal runat="server" ID="lConfirmOrderError" EnableViewState="false"></asp:Literal>
            </div>
        </div>
    </div>
</div>
