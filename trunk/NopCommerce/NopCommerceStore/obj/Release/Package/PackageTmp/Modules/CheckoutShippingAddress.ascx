<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CheckoutShippingAddressControl"
    CodeBehind="CheckoutShippingAddress.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="AddressEdit" Src="~/Modules/AddressEdit.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="AddressDisplay" Src="~/Modules/AddressDisplay.ascx" %>
<div class="checkout-data">
    <div style="width: 407px; float: right;">
        <div>
            <div class="div_Licensing_homepage1">
            </div>
            <div class="div_Licensing_homepage2" style="text-align: left; width:395px">
                <div class="div_box_music_header" style="padding-left: 10px">
                    <asp:Label runat="server" ID="lEnterShippingAddress"></asp:Label></div>
            </div>
            <div class="div_Licensing_homepage3">
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="div_Licensing_homepage4" style="height: auto">
            <div style="padding: 5px 15px;">
                <div class="CheckoutShippingAddress">
                    <nopCommerce:AddressEdit ID="ctrlShippingAddress" runat="server" IsNew="true" IsBillingAddress="false"
                        ValidationGroup="EnterShippingAddress" />
                </div>
                <div class="clear">
                </div>
                <div style=" padding-left:118px;">
                    <div class="div_bntBuynow1">
                    </div>
                    <div class="div_bntBuynow2">
                        <asp:Button runat="server" ID="btnNextStep" Text="<% $NopResources:Checkout.NextButton %>"
                            OnClick="btnNextStep_Click" CssClass="btnSearchBox" ValidationGroup="EnterShippingAddress" />
                    </div>
                    <div class="div_bntBuynow3">
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
        </div>
        <div>
            <div class="div_Licensing_homepage5">
            </div>
            <div class="div_Licensing_homepage6" style="text-align: left; width:395px" >
            </div>
            <div class="div_Licensing_homepage7">
            </div>
        </div>
    </div>
    <asp:Panel runat="server" ID="pnlSelectShippingAddress">
        <div style="width: 520px; float: left;">
            <div>
                <div class="div_Licensing_homepage1">
                </div>
                <div class="div_Licensing_homepage2" style="width: 508px; text-align: left">
                    <div class="div_box_music_header" style="padding-left: 2px">
                        <%=GetLocaleResourceString("Checkout.SelectShippingAddress")%></div>
                </div>
                <div class="div_Licensing_homepage3">
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="div_Licensing_homepage4" style=" height:auto">
            <div class="clear-10"></div>
            <div style=" float:right; width:1px; height:302px"></div>
                <asp:DataList ID="dlShippingAddresses" runat="server" RepeatColumns="3" RepeatDirection="Vertical"
                    RepeatLayout="Table" ItemStyle-CssClass="item-box" ItemStyle-VerticalAlign="Top" CellPadding="10" CellSpacing="0">
                    <ItemTemplate>
                        <div class="address-item">
                            <div class="address-box" style=" height:180px;" >
                                <nopCommerce:AddressDisplay ID="adAddress" runat="server" Address='<%# Container.DataItem %>'
                                    ShowDeleteButton="false" ShowEditButton="false"></nopCommerce:AddressDisplay>
                            </div>
                            <div style="padding-left:0px; padding-top: 5px;">
                                <div class="div_bntBuynowBlack1">
                                </div>
                                <div class="div_bntBuynowBlack2">
                                    <asp:Button runat="server" CommandName="Select" ID="btnSelect" Text='<%#GetLocaleResourceString("Checkout.ShipToThisAddress")%>'
                                        OnCommand="btnSelect_Command" ValidationGroup="SelectShippingAddress" CommandArgument='<%# Eval("AddressId") %>'
                                        CssClass="btnSearchBox" />
                                </div>
                                <div class="div_bntBuynowBlack3">
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemStyle CssClass="ShippingAddressesALter" />
                </asp:DataList>
                <div class="clear-10"></div>
            </div>
            <div>
                <div class="div_Licensing_homepage5">
                </div>
                <div class="div_Licensing_homepage6" style="width: 508px; text-align: left">
                </div>
                <div class="div_Licensing_homepage7">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </asp:Panel>
    <div class="clear">
    </div>
    
</div>
