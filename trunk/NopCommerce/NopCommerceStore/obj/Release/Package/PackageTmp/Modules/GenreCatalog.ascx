<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GenreCatalog.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Modules.GenreCatalog" %>
<asp:DataList runat="server" ID="dlGenre" OnItemDataBound="dlGenre_Bound">
    <ItemTemplate>
        <div style="width: 30px; float: left; text-align: right; color: #727373;">
            <asp:Label runat="server" ID="lblNumber"></asp:Label>.
        </div>
        <div style="width: 185px; float: left; padding-left: 10px; color: #003f63;">
            <asp:Label runat="server" ID="lblName"></asp:Label>
            <span style="color: #727373;">( <asp:Label runat="server" ID="lblProductNumber"></asp:Label> )</span>
        </div>
    </ItemTemplate>
</asp:DataList>
