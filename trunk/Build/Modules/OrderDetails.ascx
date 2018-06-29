<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.OrderDetailsControl"
    CodeBehind="OrderDetails.ascx.cs" %>
<div class="clear">
</div>
<div class="order-details" style="margin: 0px; color: #555555">
 <div class="page-title" style="">
    <div style=" float:right; width:70px; padding-top:10px">
     <%if (!this.IsInvoice)
          { %>
         <div class="div_bntBuynow1">
            </div>
            <div class="div_bntBuynow2">
               
                    <asp:Button runat="server" ID="btnReOrder" CssClass="btnSearchBox" Text="<% $NopResources:Order.BtnReOrder.Text %>"
            ToolTip="<% $NopResources:Order.BtnReOrder.Tooltip %>" OnClick="BtnReOrder_OnClick" />
            </div>
            <div class="div_bntBuynow3">
            </div>
            <div class="clear">
            </div>
        
        <%} %></div>
        <%=GetLocaleResourceString("Order.Product(s)")%></div>
    <div class="clear">
    </div>
    <div>
        <asp:GridView ID="gvOrderProductVariants" runat="server" AutoGenerateColumns="False"
            Width="100%" >
            <Columns>
                <asp:TemplateField HeaderText="<% $NopResources:Order.ProductsGrid.Name %>" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <div style="padding-left: 10px; padding-right: 10px;">
                            <em><a href='<%#GetProductUrl(Convert.ToInt32(Eval("ProductVariantId")))%>'>
                                <%#Server.HtmlEncode(GetProductVariantName(Convert.ToInt32(Eval("ProductVariantId"))))%></a></em>
                            <%#GetAttributeDescription((OrderProductVariant)Container.DataItem)%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<% $NopResources:Order.ProductsGrid.Download %>" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <div style="padding-left: 10px; padding-right: 10px;">
                            <%#GetDownloadUrl(Container.DataItem as OrderProductVariant)%>
                        </div>
                        <div style="padding-left: 10px; padding-right: 10px;">
                            <%#GetLicenseDownloadUrl(Container.DataItem as OrderProductVariant)%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<% $NopResources:Order.ProductsGrid.Price %>" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <div style="padding-left: 10px; padding-right: 10px;">
                            <%#GetProductVariantUnitPrice(Container.DataItem as OrderProductVariant)%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Quantity" HeaderText="<% $NopResources:Order.ProductsGrid.Quantity %>"
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                <asp:TemplateField HeaderText="<% $NopResources:Order.ProductsGrid.Total %>" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <div style="padding-left: 10px; padding-right: 10px;">
                            <%#GetProductVariantSubTotal(Container.DataItem as OrderProductVariant)%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="clear">
        </div>
        <div class="checkout-attributes">
            <asp:Literal runat="server" ID="lCheckoutAttributes"></asp:Literal>
        </div>
        <div class="clear">
        </div>
       
    </div>
     <div class="clear">
    </div>
    <%if (!this.IsInvoice)
      { %>
    <div class="page-title" style="float: left; width: 300px; margin:0px;">
        <%=GetLocaleResourceString("Order.OrderInformation")%></div>
        <div style="float: right; width: 150px; padding-top: 20px">
        <div style="float: right; width: 76px;">
            <div class="div_bntBuynowBlack1">
            </div>
            <div class="div_bntBuynowBlack2">
                <asp:LinkButton runat="server" ID="lbPDFInvoice" Text="<% $NopResources:Order.GetPDFInvoice %>"
                    CssClass="btnSearchBox" ForeColor="white" OnClick="lbPDFInvoice_Click" />
            </div>
            <div class="div_bntBuynowBlack3">
            </div>
            <div class="clear">
            </div>
        </div>
        <div style="float: right; width: 45px;">
            <div class="div_bntBuynowBlack1">
            </div>
            <div class="div_bntBuynowBlack2">
                <asp:HyperLink runat="server" ID="lnkPrint" Text="<% $NopResources:Order.Print %>"
                    Target="_blank" CssClass="btnSearchBox" ForeColor="white" />
            </div>
            <div class="div_bntBuynowBlack3">
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
          <div class="clear-20" style="border-top: 3px solid #0068A2">
    </div>
    
    <div class="clear">
    </div>
    <%} %>
    <div style=" margin-bottom: 5px;">
        <b style="color: #000; font-size: 14px;">
            <%=GetLocaleResourceString("Order.Order#")%><asp:Label ID="lblOrderId" runat="server" />
        </b>
    </div>
    <table>
        <tr>
            <td valign="top" align="left" style="width: 100px">
                <b>
                    <%=GetLocaleResourceString("Order.OrderDate")%>:</b>
            </td>
            <td valign="top" align="left">
                <asp:Label ID="lblCreatedOn" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
                <b>
                    <%=GetLocaleResourceString("Order.OrderTotal")%>:</b>
            </td>
            <td valign="top" align="left">
                <asp:Label ID="lblOrderTotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
                <b>
                    <%=GetLocaleResourceString("Order.OrderStatus")%></b>
            </td>
            <td valign="top" align="left">
                <asp:Label ID="lblOrderStatus" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <div class="clear-10">
    </div>
    <asp:Panel runat="server" ID="pnlShipping">
        <div style=" margin-bottom: 5px;">
            <b style="color: #000; font-size: 14px;">
                <%=GetLocaleResourceString("Order.ShippingAddress")%>
            </b>
        </div>
        <div>
            <asp:Literal ID="lShippingFirstName" runat="server"></asp:Literal>
            <asp:Literal ID="lShippingLastName" runat="server"></asp:Literal><br />
            <div>
                <%=GetLocaleResourceString("Order.Email")%>:
                <asp:Literal ID="lShippingEmail" runat="server"></asp:Literal></div>
            <div>
                <%=GetLocaleResourceString("Order.Phone")%>:
                <asp:Literal ID="lShippingPhoneNumber" runat="server"></asp:Literal></div>
            <div>
                <%=GetLocaleResourceString("Order.Fax")%>:
                <asp:Literal ID="lShippingFaxNumber" runat="server"></asp:Literal></div>
            <asp:Panel ID="pnlShippingCompany" runat="server">
                <asp:Literal ID="lShippingCompany" runat="server"></asp:Literal></asp:Panel>
            <div>
                <asp:Literal ID="lShippingAddress1" runat="server"></asp:Literal></div>
            <asp:Panel ID="pnlShippingAddress2" runat="server">
                <asp:Literal ID="lShippingAddress2" runat="server"></asp:Literal></asp:Panel>
            <div>
                <asp:Literal ID="lShippingCity" runat="server"></asp:Literal>,
                <asp:Literal ID="lShippingStateProvince" runat="server"></asp:Literal>
                <asp:Literal ID="lShippingZipPostalCode" runat="server"></asp:Literal></div>
            <asp:Panel ID="pnlShippingCountry" runat="server">
                <asp:Literal ID="lShippingCountry" runat="server"></asp:Literal></asp:Panel>
        </div>
        <div class="clear-10">
        </div>
        <div style=" margin-bottom: 5px;">
            <b style="color: #000; font-size: 14px;">
                <%=GetLocaleResourceString("Order.ShippingMethod")%>
            </b>
        </div>
        <div>
            <asp:Label ID="lblShippingMethod" runat="server"></asp:Label>
        </div>
        <div class="clear-10">
        </div>
        <div runat="server" id="pnlTrackingNumber" style="border-bottom: 1px solid black;
            padding-bottom: 2px; margin-bottom: 5px;">
            <b style="color: #000; font-size: 14px;">
                <%=GetLocaleResourceString("Order.TrackingNumber")%>
            </b>
        </div>
        <div>
            <asp:Label ID="lblTrackingNumber" runat="server"></asp:Label></div>
        <div class="clear-10">
        </div>
        <%if (!this.IsInvoice)
          { %>
        <div style=" margin-bottom: 5px;">
            <b style="color: #000; font-size: 14px;">
                <%=GetLocaleResourceString("Order.ShippedOn")%></b>
        </div>
        <div>
            <asp:Label ID="lblShippedDate" runat="server"></asp:Label>
        </div>
        <div class="clear-10">
        </div>
        <div style=" margin-bottom: 5px;">
            <b style="color: #000; font-size: 14px;">
                <%=GetLocaleResourceString("Order.DeliveredOn")%></b>
        </div>
        <div>
            <asp:Label ID="lblDeliveredOn" runat="server"></asp:Label>
        </div>
        <div class="clear-10">
        </div>
        <%} %>
        <div style=" margin-bottom: 5px;">
            <b style="color: #000; font-size: 14px;">
                <%=GetLocaleResourceString("Order.Weight")%></b>
        </div>
        <div>
            <asp:Label ID="lblOrderWeight" runat="server"></asp:Label>
        </div>
        <div class="clear-10">
        </div>
    </asp:Panel>
    <div class="clear">
    </div>
    <%--  <div class="section-title">
        <%=GetLocaleResourceString("Order.BillingInformation")%>
    </div>--%>
    <div style=" margin-bottom: 5px;">
        <b style="color: #000; font-size: 14px;">
            <%=GetLocaleResourceString("Order.BillingAddress")%>
        </b>
    </div>
    <div>
        <asp:Literal ID="lBillingFirstName" runat="server"></asp:Literal>
        <asp:Literal ID="lBillingLastName" runat="server"></asp:Literal><br />
        <div>
            <%=GetLocaleResourceString("Order.Email")%>:
            <asp:Literal ID="lBillingEmail" runat="server"></asp:Literal></div>
        <div>
            <%=GetLocaleResourceString("Order.Phone")%>:
            <asp:Literal ID="lBillingPhoneNumber" runat="server"></asp:Literal></div>
        <div>
            <%=GetLocaleResourceString("Order.Fax")%>:
            <asp:Literal ID="lBillingFaxNumber" runat="server"></asp:Literal></div>
        <asp:Panel ID="pnlBillingCompany" runat="server">
            <asp:Literal ID="lBillingCompany" runat="server"></asp:Literal></asp:Panel>
        <div>
            <asp:Literal ID="lBillingAddress1" runat="server"></asp:Literal></div>
        <asp:Panel ID="pnlBillingAddress2" runat="server">
            <asp:Literal ID="lBillingAddress2" runat="server"></asp:Literal></asp:Panel>
        <div>
            <asp:Literal ID="lBillingCity" runat="server"></asp:Literal>,
            <asp:Literal ID="lBillingStateProvince" runat="server"></asp:Literal>
            <asp:Literal ID="lBillingZipPostalCode" runat="server"></asp:Literal></div>
        <asp:Panel ID="pnlBillingCountry" runat="server">
            <asp:Literal ID="lBillingCountry" runat="server"></asp:Literal></asp:Panel>
    </div>
    <div class="clear-10">
    </div>
    <div style=" margin-bottom: 5px;">
        <b style="color: #000; font-size: 14px;">
            <%=GetLocaleResourceString("Order.PaymentMethod")%>
        </b>
    </div>
    <div>
        <asp:Literal runat="server" ID="lPaymentMethod"></asp:Literal></div>
    <div class="clear-20" style="border-bottom: 3px solid #0068A2">
    </div>
    <table width="100%" cellspacing="0" cellpadding="2" border="0">
        <tbody>
            <tr>
                <td width="100%" align="right">
                    <b>
                        <%=GetLocaleResourceString("Order.Sub-Total")%>:</b>
                </td>
                <td align="right">
                    <span style="white-space: nowrap;">
                        <asp:Label ID="lblOrderSubtotal" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phDiscount">
                <tr>
                    <td width="100%" align="right">
                        <b>
                            <%=GetLocaleResourceString("Order.Discount")%>:</b>
                    </td>
                    <td align="right">
                        <span style="white-space: nowrap;">
                            <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                        </span>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr runat="server" id="pnlShippingTotal">
                <td width="100%" align="right">
                    <b>
                        <%=GetLocaleResourceString("Order.Shipping")%>:</b>
                </td>
                <td align="right">
                    <span style="white-space: nowrap;">
                        <asp:Label ID="lblOrderShipping" runat="server"></asp:Label>
                    </span>
                </td>
            </tr>
            <asp:PlaceHolder runat="server" ID="phPaymentMethodAdditionalFee">
                <tr>
                    <td width="100%" align="right">
                        <b>
                            <%=GetLocaleResourceString("Order.PaymentMethodAdditionalFee")%>:</b>
                    </td>
                    <td align="right">
                        <span style="white-space: nowrap;">
                            <asp:Label ID="lblPaymentMethodAdditionalFee" runat="server"></asp:Label>
                        </span>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="phTaxTotal">
                <tr>
                    <td width="100%" align="right">
                        <b>
                            <%=GetLocaleResourceString("Order.Tax")%>:</b>
                    </td>
                    <td align="right">
                        <span style="white-space: nowrap;">
                            <asp:Label ID="lblOrderTax" runat="server"></asp:Label>
                        </span>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <asp:Repeater runat="server" ID="rptrGiftCards" OnItemDataBound="rptrGiftCards_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td width="100%" align="right">
                            <b>
                                <asp:Literal runat="server" ID="lGiftCard"></asp:Literal>:</b>
                        </td>
                        <td align="right">
                            <span style="white-space: nowrap;">
                                <asp:Label ID="lblGiftCardAmount" runat="server"></asp:Label>
                            </span>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <asp:PlaceHolder runat="server" ID="phRewardPoints">
                <tr>
                    <td width="100%" align="right">
                        <b>
                            <asp:Literal runat="server" ID="lRewardPointsTitle"></asp:Literal>:</b>
                    </td>
                    <td align="right">
                        <span style="white-space: nowrap;">
                            <asp:Label ID="lblRewardPointsAmount" runat="server"></asp:Label>
                        </span>
                    </td>
                </tr>
            </asp:PlaceHolder>
            <tr>
                <td width="100%" align="right">
                    <b>
                        <%=GetLocaleResourceString("Order.OrderTotal")%>:</b>
                </td>
                <td align="right">
                    <b><span style="white-space: nowrap; color: #FD961D">
                        <asp:Label ID="lblOrderTotal2" runat="server"></asp:Label>
                    </span></b>
                </td>
            </tr>
        </tbody>
    </table>
    <div class="clear">
    </div>
     <div class="clear-20" >
    </div>
    <%if (!this.IsInvoice)
      { %>
    <div class="clear">
    </div>
    <div class="page-title" runat="server" id="pnlOrderNotesTitle">
        <%=GetLocaleResourceString("Order.Notes")%>
    </div>
    <div class="clear">
    </div>
    <div  runat="server" id="pnlOrderNotes">
        <asp:GridView ID="gvOrderNotes" runat="server" AutoGenerateColumns="False" Width="100%">
            <Columns>
                <asp:TemplateField HeaderText="<% $NopResources:Order.OrderNotes.CreatedOn %>" HeaderStyle-HorizontalAlign="Center"
                    ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%#DateTimeHelper.ConvertToUserTime((DateTime)Eval("CreatedOn")).ToString()%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="<% $NopResources:Order.OrderNotes.Note %>" ItemStyle-Width="70%"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <div style="padding-left: 10px; padding-right: 10px; text-align: left;">
                            <%#OrderManager.FormatOrderNoteText((string)Eval("Note"))%>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <%} %>
</div>
