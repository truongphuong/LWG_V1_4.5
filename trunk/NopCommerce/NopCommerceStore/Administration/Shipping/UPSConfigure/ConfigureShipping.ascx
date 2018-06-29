<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Administration.Shipping.UPSConfigure.ConfigureShipping"
    CodeBehind="ConfigureShipping.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="DecimalTextBox" Src="../../Modules/DecimalTextBox.ascx" %>
<script type="text/javascript" language="javascript">

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
      
</script>
<table>
    <tr>
        <td style="vertical-align: top">
            <table class="adminContent">
                <tr>
                    <td class="adminTitle">
                        URL:
                    </td>
                    <td class="adminData">
                        <asp:TextBox runat="server" ID="txtURL" CssClass="adminInput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        Access Key:
                    </td>
                    <td class="adminData">
                        <asp:TextBox runat="server" ID="txtAccessKey" CssClass="adminInput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        Username:
                    </td>
                    <td class="adminData">
                        <asp:TextBox runat="server" ID="txtUsername" CssClass="adminInput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        Password:
                    </td>
                    <td class="adminData">
                        <asp:TextBox runat="server" ID="txtPassword" CssClass="adminInput"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        UPS Customer Classification:
                    </td>
                    <td class="adminData">
                        <asp:DropDownList ID="ddlUPSCustomerClassification" runat="server" CssClass="adminInput">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        UPS Pickup Type:
                    </td>
                    <td class="adminData">
                        <asp:DropDownList ID="ddlUPSPickupType" runat="server" CssClass="adminInput">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        UPS Packaging Type:
                    </td>
                    <td class="adminData">
                        <asp:DropDownList ID="ddlUPSPackagingType" runat="server" CssClass="adminInput">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        Additional handling charge [<%=CurrencyManager.PrimaryStoreCurrency.CurrencyCode%>]:
                    </td>
                    <td class="adminData">
                        <nopCommerce:DecimalTextBox runat="server" ID="txtAdditionalHandlingCharge" Value="0"
                            RequiredErrorMessage="From is required" MinimumValue="0" MaximumValue="999999"
                            RangeErrorMessage="The value must be from 0 to 999999" CssClass="adminInput">
                        </nopCommerce:DecimalTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        Shipped from country:
                    </td>
                    <td class="adminData">
                        <asp:DropDownList ID="ddlShippedFromCountry" runat="server" CssClass="adminInput">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        Shipped from zip:
                    </td>
                    <td class="adminData">
                        <asp:TextBox runat="server" ID="txtShippedFromZipPostalCode" CssClass="adminInput"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
        <td style="vertical-align: top;">
            <table>
                <tr>
                    <td style="vertical-align: top; padding-left:10px">
                    </td>
                    <td style="vertical-align: top;">
                        <fieldset>
                            <legend>Carrier services:</legend>
                            <asp:CheckBoxList ID="chkListUPSServices" runat="server">
                            </asp:CheckBoxList>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right; vertical-align: top">
                    </td>
                    <td>
                        <fieldset>
                            <legend>Weight Charge:</legend>
                            <div>
                                <asp:GridView ID="gvConvertion" runat="server" AutoGenerateColumns="false" OnRowCommand="gvConvertion_RowCommand"
                                    DataKeyNames="ID" OnRowDeleting="gvConvertion_RowDeleting" OnRowDataBound="gvConvertion_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="From (USD)">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdID" runat="server" Value='<%#Eval("ID") %>' />
                                                <asp:TextBox ID="txtFrom" onkeypress="return isNumberKey(event)" Text='<%#Eval("PriceFrom") %>'
                                                    runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvFrom" runat="server" ControlToValidate="txtFrom"
                                                    Display='Dynamic' ValidationGroup="UpdateConvertion">*</asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To (USD)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtTo" onkeypress="return isNumberKey(event)" Text='<%#Eval("PriceTo") %>'
                                                    runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvTo" runat="server" ControlToValidate="txtTo" Display='Dynamic'
                                                    ValidationGroup="UpdateConvertion">*</asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Charge weight (lb)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtChargeWeight" onkeypress="return isNumberKey(event)" Text='<%#Eval("ChargeWeight") %>'
                                                    runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvChargeWeight" runat="server" ControlToValidate="txtChargeWeight"
                                                    Display='Dynamic' ValidationGroup="UpdateConvertion">*</asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnUpdate" Text="Update" CommandName="UpdateConvertion" CssClass="adminButton"
                                                    ValidationGroup="UpdateConvertion" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure to delete?');"
                                                    CommandName="Delete" CssClass="adminButton" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div style="margin-top: 20px">
                                <table>
                                    <tr>
                                        <td>
                                            Order total from [USD]
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPriceFrom" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvFrom" runat="server" ControlToValidate="txtPriceFrom"
                                                Display='Dynamic' ValidationGroup="AddConvertion">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Order total to [USD]
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="upnlPriceTo" runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox ID="txtPriceTo" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPriceTo"
                                                        Display='Dynamic' ValidationGroup="AddConvertion">*</asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Charge weight [lb]
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtChargeWeight" onkeypress="return isNumberKey(event)" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtChargeWeight"
                                                Display='Dynamic' ValidationGroup="AddConvertion">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Button ID="btnAddConvertion" ValidationGroup="AddConvertion" runat="server"
                                    Text="Add new" CssClass="adminButton" OnClick="btnAddConvertion_Click" />
                            </div>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
