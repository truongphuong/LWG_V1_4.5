<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentProduct.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Modules.RecentProduct" %>

<asp:DataList runat="server" ID="dlRecentProduct" OnItemDataBound="dlRecentProduct_Bound">
    <ItemTemplate>
        <div style="width: 30px; float: left; text-align: right; color: #727373;">
            <asp:Label runat="server" ID="lblNumber"></asp:Label>.
        </div>
        <div style="width: 185px; float: left; padding-left: 10px; color: #003f63;">
            <asp:HyperLink runat="server" ID="hplName"></asp:HyperLink>
        </div>
    </ItemTemplate>
</asp:DataList>