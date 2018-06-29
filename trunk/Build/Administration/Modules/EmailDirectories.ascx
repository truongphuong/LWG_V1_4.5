<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailDirectories.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.EmailDirectories" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="SelectCategoryControl" Src="SelectCategoryControl.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ConfirmationBox" Src="ConfirmationBox.ascx" %>

<div class="section-header">
    <div class="title">
        <img src="" alt="Email Directory" />
        Directory
    </div>
    <div class="options">
        <asp:Button ID="SearchButton" runat="server" Text="Search"
            CssClass="adminButtonBlue" ToolTip="Search" onclick="SearchButton_Click" />             
        <input type="button" onclick="location.href='EmailDirectoryDetail.aspx'" value="Add New"
            id="btnAddNew" class="adminButtonBlue" title="Add new" />
        <asp:Button runat="server" Text="Delete selected"
            CssClass="adminButtonBlue" ID="btnDelete" onclick="btnDelete_Click"/>
            <nopCommerce:ConfirmationBox runat="server" ID="cbDelete" TargetControlID="btnDelete"
    YesText="Yes" NoText="No"
    ConfirmText="Are you sure?" />
    </div>
</div>

<table width="100%">
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblFirstName" Text="First name:"
                ToolTip="First name" ToolTipImage="~/Administration/Common/ico-help.gif" />
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtFirstName" CssClass="adminInput" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            <nopCommerce:ToolTipLabel runat="server" ID="lblLastName" Text="Last name:"
                ToolTip="Last name" ToolTipImage="~/Administration/Common/ico-help.gif" />


        </td>
        <td class="adminData">
            <asp:TextBox ID="txtLastName" CssClass="adminInput" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>

<script type="text/javascript">

    $(window).bind('load', function() {
        var cbHeader = $(".cbHeader input");
        var cbRowItem = $(".cbRowItem input");
        cbHeader.bind("click", function() {
            cbRowItem.each(function() { this.checked = cbHeader[0].checked; })
        });
        cbRowItem.bind("click", function() { if ($(this).checked == false) cbHeader[0].checked = false; });
    });
    
</script>
<asp:GridView ID="gvEmails" runat="server" AutoGenerateColumns="False" Width="100%"
     AllowPaging="true" PageSize="15" onpageindexchanging="gvEmails_PageIndexChanging">
    <Columns>
        <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
            <HeaderTemplate>
                <asp:CheckBox ID="cbSelectAll" runat="server" CssClass="cbHeader" />
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="cbEmail" runat="server" CssClass="cbRowItem" />
                <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("EmailID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="First Name" ItemStyle-Width="60%">
            <ItemTemplate>
                <%#Server.HtmlEncode(Eval("FirstName").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Last Name" ItemStyle-Width="60%">
            <ItemTemplate>
                <%#Server.HtmlEncode(Eval("LastName").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center"
            ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <a href="EmailDirectoryDetail.aspx?EmailId=<%#Eval("EmailID")%>" title="Edit">
                    Edit
                </a>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<asp:Label runat="server" ID="lblNoFound" Text="No Email Found"
    Visible="false"></asp:Label>
