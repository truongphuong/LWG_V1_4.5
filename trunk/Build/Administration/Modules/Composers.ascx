<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Composers.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ComposersControl" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>

<div class="section-header">
    <div class="title">
        <img src="Common/ico-configuration.png" alt="<%=GetLocaleResourceString("Admin.Composers.Title")%>" />
        <%=GetLocaleResourceString("Admin.Composers.Title")%>
    </div>
    <div class="options">
        <input type="button" onclick="location.href='ComposerAdd.aspx'" value="<%=GetLocaleResourceString("Admin.Composers.AddButton.Text")%>"
            id="btnAddNew" class="adminButtonBlue" title="<%=GetLocaleResourceString("Admin.Composers.AddButton.Tooltip")%>" />
        <asp:Button ID="btnSearch" runat="server" Text="<% $NopResources:Admin.Composers.SearchButton.Text %>"
            CssClass="adminButtonBlue" 
            ToolTip="<% $NopResources:Admin.Composers.SearchButton.Tooltip %>" 
            onclick="btnSearch_Click" />
    </div>
</div>

<table width="100%">
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblProductName" Text="<% $NopResources:Admin.Composers.NameDisplay %>"
                ToolTip="<% $NopResources:Admin.Composers.NameDisplay.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtNameDisplay" CssClass="adminInput" runat="server" 
                AutoPostBack="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblManufacturer" Text="<% $NopResources:Admin.Composers.FirstLetter %>"
                ToolTip="<% $NopResources:Admin.Composers.FirstLetter.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:DropDownList ID="ddlFirstLetter" runat="server" CssClass="adminInput" 
                onselectedindexchanged="ddlFirstLetter_SelectedIndexChanged" 
                AutoPostBack="True">
                <asp:ListItem>ALL</asp:ListItem>
                <asp:ListItem>A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>C</asp:ListItem>
                <asp:ListItem>D</asp:ListItem>
                <asp:ListItem>E</asp:ListItem>
                <asp:ListItem>F</asp:ListItem>
                <asp:ListItem>G</asp:ListItem>
                <asp:ListItem>H</asp:ListItem>
                <asp:ListItem>I</asp:ListItem>
                <asp:ListItem>J</asp:ListItem>
                <asp:ListItem>K</asp:ListItem>
                <asp:ListItem>L</asp:ListItem>
                <asp:ListItem>M</asp:ListItem>
                <asp:ListItem>N</asp:ListItem>
                <asp:ListItem>O</asp:ListItem>
                <asp:ListItem>P</asp:ListItem>
                <asp:ListItem>Q</asp:ListItem>
                <asp:ListItem>R</asp:ListItem>
                <asp:ListItem>S</asp:ListItem>
                <asp:ListItem>T</asp:ListItem>
                <asp:ListItem>U</asp:ListItem>
                <asp:ListItem>V</asp:ListItem>
                <asp:ListItem>W</asp:ListItem>
                <asp:ListItem>X</asp:ListItem>
                <asp:ListItem>Y</asp:ListItem>
                <asp:ListItem>Z</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>

<asp:GridView ID="gvComposers" runat="server" AutoGenerateColumns="False" Width="100%" OnPageIndexChanging="gvComposers_PageIndexChanging" AllowPaging="true" PageSize="15">
    <Columns>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.Composers.NameDisplay %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Server.HtmlEncode(Eval("NameDisplay").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.Composers.NameList %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Server.HtmlEncode(Eval("NameList").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.Composers.NameSort %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Server.HtmlEncode(Eval("NameSort").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.Composers.FirstName %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Server.HtmlEncode((String) Eval("FirstName"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.Composers.LastName %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Server.HtmlEncode((String)Eval("LastName"))%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.Composers.DOB %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Eval("DOB")%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="<% $NopResources:Admin.Composers.DOD %>" ItemStyle-Width="10%">
            <ItemTemplate>
                <%#Eval("DOD")%>
            </ItemTemplate>
        </asp:TemplateField>


        <asp:TemplateField HeaderText="<% $NopResources:Admin.Composers.Edit %>" HeaderStyle-HorizontalAlign="Center"
            ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href="ComposerDetails.aspx?ComposerID=<%#Eval("PersonId")%>"
                    title="<%#GetLocaleResourceString("Admin.Composers.Edit.Tooltip")%>">
                    <%#GetLocaleResourceString("Admin.Composers.Edit")%>
                </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
