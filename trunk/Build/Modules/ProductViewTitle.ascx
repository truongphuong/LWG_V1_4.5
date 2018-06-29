<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductViewTitle.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Modules.ProductViewTitle" %>
<table style="width:217px; padding-left:3px; padding-right:3px;" border="0" cellpadding="0" cellspacing="0" class="noclass" >
<tr>
        <td style="height:10px">
        </td>
    </tr>
    <tr>
        <td>
           <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:HyperLink ID="hpProductName" runat="server" style="color:#0068a2; font-size:12px; font-weight:bolder"></asp:HyperLink>
                </td>
                <td style="text-align:right; vertical-align:top;">
                    <asp:Label ID="lblPrice" runat="server" Text="" ForeColor="Red" style="font-weight:bold; font-size:11px"></asp:Label>
                </td>
            </tr>
           </table> 
        </td>
    </tr>
    <tr>
        <td style="margin-top:5px; margin-bottom:5px;">
        <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
        <asp:Repeater ID="rptrCategoryBreadcrumb" runat="server">
        <ItemTemplate>
            <a href='<%#SEOHelper.GetCategoryUrl(Convert.ToInt32(Eval("CategoryId"))) %>'>
                <%#Server.HtmlEncode(Eval("Name").ToString()) %></a>
        </ItemTemplate>
        <SeparatorTemplate>
            -
        </SeparatorTemplate>
        <FooterTemplate>
            
        </FooterTemplate>
    </asp:Repeater>
        </td>
    </tr>
    <tr>
        <td>
        <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:HyperLink ID="hlCatalogNo" runat="server"></asp:HyperLink>
                </td>
                <td style="text-align:right">
                    <asp:HyperLink ID="hlViewMore" runat="server" ForeColor="OrangeRed">view more</asp:HyperLink>
                </td>
            </tr>
           </table> 
        </td>
    </tr>
    <tr>
        <td style="height:10px">
        </td>
    </tr>
</table>
