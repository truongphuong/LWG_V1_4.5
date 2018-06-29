<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CatalogComposer.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.CatalogComposerControl" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>
<asp:Panel ID="pnlContent" runat="server">
    <asp:UpdatePanel ID="pnlUpdate1" runat="server">
        <ContentTemplate>
            <div class="section-header">
                <div class="title">
                    <img src="Common/ico-configuration.png" alt="<%=GetLocaleResourceString("Admin.CatalogComposer.Title")%>" />
                    <%=GetLocaleResourceString("Admin.CatalogComposer.Title")%>
                </div>
            </div>
            <table width="100%">
                <tr>
                    <td style="text-align:left;" colspan="2">
                        Please use search function below to select a person first.
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <nopCommerce:ToolTipLabel runat="server" ID="lblProductName" Text="<% $NopResources:Admin.CatalogComposer.FirstName %>"
                            ToolTip="<% $NopResources:Admin.CatalogComposer.FirstName.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:TextBox ID="txtFirstName" CssClass="adminInput" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <nopCommerce:ToolTipLabel runat="server" ID="ToolTipLabel1" Text="<% $NopResources:Admin.CatalogComposer.LastName %>"
                            ToolTip="<% $NopResources:Admin.CatalogComposer.LastName.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:TextBox ID="txtLastName" CssClass="adminInput" runat="server" AutoPostBack="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                    </td>
                    <td class="adminData">
                        <asp:Button ID="btnSearch" runat="server" Text="<% $NopResources:Admin.CatalogComposer.SearchButton.Text %>"
                            CssClass="adminButtonBlue" ToolTip="<% $NopResources:Admin.CatalogComposer.SearchButton.Tooltip %>"
                            OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                    </td>
                    <td class="adminData">
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <nopCommerce:ToolTipLabel runat="server" ID="lblManufacturer" Text="<% $NopResources:Admin.CatalogComposer.Person %>"
                            ToolTip="<% $NopResources:Admin.CatalogComposer.Person.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:DropDownList ID="ddlPeople" runat="server" DataTextField="NameDisplay" DataValueField="PersonId"
                            CssClass="adminInput">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <nopCommerce:ToolTipLabel runat="server" ID="ToolTipLabel2" Text="<% $NopResources:Admin.CatalogComposer.Role %>"
                            ToolTip="<% $NopResources:Admin.CatalogComposer.Role.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <asp:DropDownList ID="ddlRole" runat="server" DataTextField="Name" DataValueField="RoleId"
                            CssClass="adminInput">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                    </td>
                    <td class="adminData">
                        <asp:Button ID="btnAddPeopleRoleCatalog" runat="server" Text="<% $NopResources:Admin.CatalogComposer.Add.Text %>"
                            CssClass="adminButtonBlue" ToolTip="<% $NopResources:Admin.CatalogComposer.Add.Tooltip %>"
                            OnClick="btnAddPeopleRoleCatalog_Click" />
                        <br />
                        <asp:Literal ID="ltrMessageNote" runat="server" Visible="false">
                         You need to insert data at extra attribute tab before you can add Composer for this product.     
                        </asp:Literal>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gvComposers" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowDataBound="gvComposers_RowDataBound" OnRowCommand="gvComposers_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="<% $NopResources:Admin.CatalogComposer.NamePeople %>"
                        ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrNamePeople" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<% $NopResources:Admin.CatalogCOmposer.NameRole %>"
                        ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrNameRole" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<% $NopResources:Admin.CatalogComposer.Remove %>"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnRemove" runat="server" CommandName="REMOVE" Text="<% $NopResources:Admin.CatalogComposer.Remove %>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>           
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnAddPeopleRoleCatalog" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <span>You need to save the product before you can add Composer for this product page.
    </span>
</asp:Panel>
