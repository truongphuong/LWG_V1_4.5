<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CustomerPasswordRecoveryControl"
    CodeBehind="CustomerPasswordRecovery.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="SimpleTextBox" Src="~/Modules/SimpleTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="EmailTextBox" Src="~/Modules/EmailTextBox.ascx" %>
<div style="margin: 0px;">
    <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
        margin-bottom: 5px; border-bottom: solid 1px #000000;">
        <%=GetLocaleResourceString("Account.ResetYourPassword")%>
    </div>
    <div class="clear">
    </div>
    <div class="body">
        <div runat="server" id="pnlResult" visible="false">
            <strong>
                <asp:Literal runat="server" ID="lResult" EnableViewState="false"></asp:Literal>
            </strong>
        </div>
    </div>
    <div class="body" runat="server" id="pnlRecover" visible="false">
        <table>
            <tr>
                <td style="width: 200px; text-align: left; vertical-align: middle;">
                    <%=GetLocaleResourceString("Account.E-Mail")%>:
                </td>
                <td>
                    <nopCommerce:EmailTextBox runat="server" ID="txtEmail" ValidationGroup="PasswordRecovery"
                        Width="250px"></nopCommerce:EmailTextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: left; vertical-align: middle;">
                    <div>
                        <div class="div_bntBuynow1">
                        </div>
                        <div class="div_bntBuynow2">
                            <asp:Button runat="server" ID="btnPasswordRecovery" Text="<% $NopResources:Account.PasswordRecovery.RecoverButton %>"
                                ValidationGroup="PasswordRecovery" OnClick="btnPasswordRecovery_Click" CssClass="btnSearchBox">
                            </asp:Button>
                        </div>
                        <div class="div_bntBuynow3">
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="body" runat="server" id="pnlNewPassword" visible="false">
        <table>
            <tr>
                <td style="width: 100px; text-align: left; vertical-align: middle;">
                    <%=GetLocaleResourceString("Account.PasswordRecovery.EnterNewPassword")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtNewPassword"
                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="NewPassword">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: left; vertical-align: middle;">
                    <%=GetLocaleResourceString("Account.PasswordRecovery.ReEnterNewPassword")%>:
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="txtConfirmNewPassword"
                        ErrorMessage="*" ToolTip='Confirm password is required.' ValidationGroup="NewPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CompareValidator ID="cvPasswordCompare" runat="server" ControlToCompare="txtNewPassword"
                        ControlToValidate="txtConfirmNewPassword" Display="Dynamic" ErrorMessage='Entered passwords do not match'
                        ValidationGroup="NewPassword"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: left; vertical-align: middle;">
                    <asp:Button runat="server" ID="btnNewPassword" Text="<% $NopResources:Account.PasswordRecovery.NewPasswordSubmit %>"
                        ValidationGroup="NewPassword" OnClick="btnNewPassword_Click" CssClass="newpasswordbutton">
                    </asp:Button>
                </td>
            </tr>
        </table>
    </div>
</div>
