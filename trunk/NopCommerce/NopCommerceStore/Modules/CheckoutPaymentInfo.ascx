<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CheckoutPaymentInfoControl"
    CodeBehind="CheckoutPaymentInfo.ascx.cs" %>
<div class="checkout-data">
    <div class="payment-info">
        <div class="body">
            <asp:PlaceHolder runat="server" ID="PaymentInfoPlaceHolder"></asp:PlaceHolder>
        </div>
        <div class="clear">
        </div>
        <div class="select-button">
         <div class="div_bntBuynow1">
                    </div>
                    <div class="div_bntBuynow2">
                      
                              <asp:Button runat="server" ID="btnNextStep" Text="<% $NopResources:Checkout.NextButton %>"
                OnClick="btnNextStep_Click" CssClass="btnSearchBox" />
                    </div>
                    <div class="div_bntBuynow3">
                    </div>
                    <div class="clear"></div>
          
        </div>
    </div>
</div>
