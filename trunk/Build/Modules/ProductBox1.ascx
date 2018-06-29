<%@ Control Language="C#" AutoEventWireup="false" Inherits="NopSolutions.NopCommerce.Web.Modules.ProductBox1Control"
    CodeBehind="ProductBox1.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="ProductAttributes" Src="~/Modules/ProductAttributes.ascx" %>
<div style="text-align: center;">
    <asp:HyperLink ID="hlImageLink" runat="server" />
</div>
<div style="font-size: 13px; color: #fd961d; font-weight: bold; text-align: center;
    height: 60px; margin-top: 5px;">
    <asp:HyperLink ID="hlCatalogNo" runat="server" />
    <br />
    <asp:HyperLink ID="hlProduct" runat="server" /></div>
<asp:Literal runat="server" ID="lShortDescription" Visible="false"></asp:Literal>
<div style="padding-top: 7px;">
    <div style="width: 50%; float: left; text-align: right; padding: 1px 0px 0px 0px; font-size:11px">
        <asp:Label ID="lblPrice" runat="server" CssClass="productPrice" />
        <asp:Label ID="lblOldPrice" runat="server" CssClass="oldproductPrice" />
    </div>
    <div style="width: 50%; float: right;">
            <asp:ImageButton runat="server" ID="btnAddToCart" 
             CommandArgument='<%# Eval("ProductId") %>' 
            ImageUrl="~/images/btn_buyNow.PNG" oncommand="btnAddToCart_Click" ValidationGroup="ProductDetails"
             />     
               
    </div>  
</div>
<div style="clear:both;"> 
    <asp:DataList ID="ddlVariantPrice" RepeatColumns="1" runat="server" CssClass="none"
                Width="100%" style="border-collapse:separate;"
                onitemcommand="ddlVariantPrice_ItemCommand" 
                onitemdatabound="ddlVariantPrice_ItemDataBound">
            <ItemTemplate>
            
                <div style="float:left;width: 50%;font-size:11px;"><asp:Label ID="lblPriceDisplay" CssClass="productPrice"  runat="server" /></div>
                <div style="float:left;width: 50%;">
                <asp:ImageButton ID="imgBuyNow" CommandName="AddToCart" CommandArgument='<%#Eval("ProductVariantId")%>' ImageUrl="~/images/btn_buyNow.PNG" runat="server"  /></div>
                <asp:Label ID="lblPrice" Visible="false"  runat="server" />
                <nopCommerce:ProductAttributes ID="ctrlProductAttributes" Visible="false" runat="server" ProductVariantId='<%#Eval("ProductVariantId") %>'>
                    </nopCommerce:ProductAttributes>
                
            </ItemTemplate>
        </asp:DataList>
    </div>
<div style="clear: both; height:10px;"></div>
