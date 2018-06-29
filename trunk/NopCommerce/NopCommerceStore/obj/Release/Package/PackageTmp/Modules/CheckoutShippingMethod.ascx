<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CheckoutShippingMethodControl"
    CodeBehind="CheckoutShippingMethod.ascx.cs" %>
<div class="checkout-data">
    <div class="shipping-options">
        <asp:Panel runat="server" ID="phSelectShippingMethod">
            <asp:DataList runat="server" ID="dlShippingOptions">
                <ItemTemplate>
                    <div class="shipping-option-item">
                        <div class="option-name">
                            <nopCommerce:GlobalRadioButton runat="server" ID="rdShippingOption" Checked="false"
                                GroupName="shippingOptionGroup" />
                            <%#Server.HtmlEncode(Eval("Name").ToString()) %>
                            <%#Server.HtmlEncode(FormatShippingOption(((ShippingOption)Container.DataItem)))%>
                            <asp:HiddenField ID="hfShippingRateComputationMethodId" runat="server" Value='<%# Eval("ShippingRateComputationMethodId") %>' />
                            <asp:HiddenField ID="hfName" runat="server" Value='<%# Eval("Name") %>' />
                        </div>
                        <div class="option-description">
                            <%#Eval("Description") %>
                        </div>
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
                        OnClick="btnNextStep_Click" CssClass="btnSearchBox" ValidationGroup="SelectShippingMethod" />
                </div>
                <div class="div_bntBuynow3">
                </div>
                <div class="clear">
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlOutSideUS" style="font-size:13px"  runat="server">
            <div style="margin-bottom:20px">
                Thank you for shopping with us. Shipping to oversea address (outside US) will be
                processed by phone,fax, or email. Please contact us for more information.
            </div>
            <div>
                Phone: (800) 434-6340 or (561) 241-6169
            </div>
            <div>
                Fax: (561) 241-6347
            </div>
            <div>
                Email: orders@ludwigmasters.com
            </div>
        </asp:Panel>
        <div class="clear">
        </div>
        <div class="error-block">
            <div class="message-error">
                <asp:Literal runat="server" ID="lShippingMethodsError" EnableViewState="false"></asp:Literal>
            </div>
        </div>
    </div>
</div>
