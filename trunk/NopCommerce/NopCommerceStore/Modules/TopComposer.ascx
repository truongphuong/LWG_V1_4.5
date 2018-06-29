<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopComposer.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Modules.TopComposerControl" %>

<asp:DataList runat="server" ID="dtlTopComposer" OnItemDataBound="dtlTopComposer_ItemDataBound">
    <ItemTemplate>
        <div style="width: 30px; float: left; text-align: right; color: #727373;">
            <asp:Label runat="server" ID="lblNumber"></asp:Label>.
        </div>
       <div style="width: 185px; float: left; padding-left: 10px; color: #003f63;">
            <asp:HyperLink runat="server" ID="lblName"></asp:HyperLink>
            <span style="color: #727373;">
            ( <asp:Label runat="server" ID="lblProductNumber"></asp:Label> )
            </span>
        </div>
    </ItemTemplate>
</asp:DataList>
