<%@ Page Title="" Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="LicenseManagement.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.LicenseManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <div class="section-header">
        <div class="title">
            <img src="Common/ico-configuration.png" alt="Licensing Requests" />
            Licensing Requests
        </div>
        <div class="options">            
            <asp:Button ID="btnSearch" runat="server" Text="Search"
                CssClass="adminButtonBlue" 
                ToolTip="Click to search licensing request" 
                onclick="btnSearch_Click" />
        </div>
    </div>
    <table width="100%">
        <tr>
            <td>
                From
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtFrom"></asp:TextBox>
                <ajaxToolkit:CalendarExtender runat="server" ID="calFrom"
                TargetControlID="txtFrom" PopupPosition="Right"></ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                To
            </td>
            <td>
                <asp:TextBox runat="server" ID="txtTo"></asp:TextBox>
                <ajaxToolkit:CalendarExtender runat="server" ID="calTo"
                TargetControlID="txtTo" PopupPosition="Right"></ajaxToolkit:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                Type
            </td>
            <td>
                <asp:DropDownList runat="server" ID="drpType"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="pnList">
        <asp:GridView runat="server" ID="grvLicense" AutoGenerateColumns="false" 
        OnRowDataBound="grvLicense_RowDataBound" OnRowCommand="grvLicense_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="LicenseID" />
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate>
                        <asp:Literal runat="server" ID="ltrType"></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Phone" DataField="Phone" />
                <asp:BoundField HeaderText="Address" DataField="Address" />
                <asp:BoundField HeaderText="City" DataField="City" />
                <asp:BoundField HeaderText="State" DataField="State" />
                <asp:BoundField HeaderText="Zipcode" DataField="Zipcode" />
                <asp:BoundField HeaderText="Requested Date" DataField="CreatedDate" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkbtnDelete" runat="server" CommandName="DLT" CommandArgument='<%# Eval("LicenseID") %>' Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
