<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Dealers.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.Dealers" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>
<script type="text/javascript">

    $(window).bind('load', function () {
        var cbHeader = $(".cbHeader input");
        var cbRowItem = $(".cbRowItem input");
        cbHeader.bind("click", function () {
            cbRowItem.each(function () { this.checked = cbHeader[0].checked; })
        });
        cbRowItem.bind("click", function () { if ($(this).checked == false) cbHeader[0].checked = false; });
    });
    
</script>
<div class="section-header">
    <div class="title">
        <img src="Common/ico-catalog.png" alt="Manage Dealers" />
        Manage Dealers
    </div>
    <div class="options">
        <div style="display: none;">
            <asp:Button ID="btnPDFExport" runat="server" Text="<% $NopResources:Admin.Products.BtnPDFExport.Text %>"
                CssClass="adminButtonBlue" ToolTip="<% $NopResources:Admin.Products.BtnPDFExport.Tooltip %>" />
        </div>
        <asp:Button ID="SearchButton" runat="server" Text="<% $NopResources:Admin.Products.SearchButton.Text %>"
            CssClass="adminButtonBlue" ToolTip="<% $NopResources:Admin.Products.SearchButton.Tooltip %>"
            OnClick="SearchButton_Click" />
        <asp:Button ID="btnImport" runat="server" Text="Import" CssClass="adminButtonBlue"
            ToolTip="Import" OnClick="btnImport_Click" />
        <input type="button" onclick="location.href='DealerAdd.aspx'" value="<%=GetLocaleResourceString("Admin.Products.AddButton.Text")%>"
            id="btnAddNew" class="adminButtonBlue" title="<%=GetLocaleResourceString("Admin.Products.AddButton.Tooltip")%>" />
        <asp:Button runat="server" Text="<% $NopResources:Admin.Products.DeleteButton.Text %>"
            CssClass="adminButtonBlue" ID="btnDelete" OnClick="btnDelete_Click" />
        <nopCommerce:ConfirmationBox runat="server" ID="cbDelete" TargetControlID="btnDelete"
            YesText="<% $NopResources:Admin.Common.Yes %>" NoText="<% $NopResources:Admin.Common.No %>"
            ConfirmText="<% $NopResources:Admin.Common.AreYouSure %>" />
    </div>
</div>
<div>
    <asp:Panel ID="pnlSearch" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearchName" runat="server" AssociatedControlID="txtSearchName"
                        Text="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearchName" Width="200px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="txtSearchID" Text="Dealer #"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearchID" Width="200px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="txtSearchAddress" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearchAddress" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
<div style="margin-top: 10px">
    <asp:GridView ID="gvDealer" runat="server" AutoGenerateColumns="false" AllowPaging="True"
        OnPageIndexChanging="gvDealer_PageIndexChanging" PageSize="50">
        <Columns>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    <asp:CheckBox ID="cbSelectAll" runat="server" CssClass="cbHeader" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="cbDealer" runat="server" CssClass="cbRowItem" />
                    <asp:HiddenField ID="hfDealerId" runat="server" Value='<%# Eval("DealerID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dealer #">
                <ItemTemplate>
                    <asp:Label ID="lblDealerID" runat="server" Text='<%# Eval("DealerID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="lblDealerName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Address">
                <ItemTemplate>
                    <div>
                        <asp:Label ID="lblAddressLine1" runat="server" Text='<%# Eval("AddressLine1") %>'></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("AddressLine2") %>'></asp:Label>
                        <asp:Label ID="lblCity" runat="server" Text='<%# Eval("City") %>'></asp:Label>,
                        <asp:Label ID="lblState" runat="server" Text='<%# Eval("State") %>'></asp:Label>
                        <asp:Label ID="lblZip" runat="server" Text='<%# Eval("Zip") %>'></asp:Label></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%"
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <a href="DealerDetails.aspx?DealerId=<%#Eval("DealerID")%>" title="Dealer details">Edit
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
