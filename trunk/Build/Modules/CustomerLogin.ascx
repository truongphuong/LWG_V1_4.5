<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CustomerLoginControl"
    CodeBehind="CustomerLogin.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="Captcha" Src="~/Modules/Captcha.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="Topic" Src="~/Modules/Topic.ascx" %>
<div style="color: #FFE66B; font-size: 25px; font-weight: bold;">
    <%=GetLocaleResourceString("Login.Welcome")%>
</div>
<div class="clear-20">
</div>
<div style="width: 960px;">
    <div>
        <div class="Box4_top1" style="">
        </div>
        <div class="Box4_top2" style="width: 950px;">
        </div>
        <div class="Box4_top3" style="">
        </div>
    </div>
    <div style="background-color: #ffffff; padding-left: 9px; padding-right: 9px; color: #000000">
        <div style="margin: 0px;">
            <div class="wrapper">
                <%if (!CheckoutAsGuestQuestion)
                  { %>
                <div class="new-wrapper">
                    <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                        margin-bottom: 5px; border-bottom: solid 1px #000000;">
                        <%=GetLocaleResourceString("Login.NewCustomer")%>
                    </div>
                    <div class="clear">
                    </div>
                    <div runat="server" id="pnlRegisterBlock">
                        <div style="float: right; position: relative; margin-top: -30px">
                            <div>
                                <div class="div_bntBuynow1">
                                </div>
                                <div class="div_bntBuynow2">
                                    <asp:Button runat="server" ID="btnRegister" Text="<% $NopResources:Account.Register %>"
                                        OnClick="btnRegister_Click" CssClass="btnSearchBox" />
                                </div>
                                <div class="div_bntBuynow3">
                                </div>
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                        <%=GetLocaleResourceString("Login.NewCustomerText")%>
                    </div>
                </div>
                <%}
                  else
                  { %>
                <div class="new-wrapper" style="clear: both">
                    <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                        margin-bottom: 5px; border-bottom: solid 1px #000000;">
                        <%=GetLocaleResourceString("Checkout.CheckoutAsGuestOrRegister")%>
                    </div>
                    <div class="clear">
                    </div>
                    <div class="checkout-as-guest-or-register-block">
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <nopCommerce:Topic ID="topicCheckoutAsGuestOrRegister" runat="server" TopicName="CheckoutAsGuestOrRegister"
                                            OverrideSEO="false"></nopCommerce:Topic>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 20px; padding-top: 20px;">
                                        <asp:Button runat="server" ID="btnCheckoutAsGuest" Text="<% $NopResources:Checkout.CheckoutAsGuest %>"
                                            OnClick="btnCheckoutAsGuest_Click" CssClass="checkoutasguestbutton" />
                                        <asp:Button runat="server" ID="btnRegister2" Text="<% $NopResources:Account.Register %>"
                                            OnClick="btnRegister_Click" CssClass="registerbutton" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <%} %>
                <div class="clear-20">
                </div>
                <div class="returning-wrapper">
                    <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                        margin-bottom: 5px; border-bottom: solid 1px #000000;">
                        <%=GetLocaleResourceString("Login.ReturningCustomer")%>
                    </div>
                    <div class="clear">
                    </div>
                    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="LoginForm$LoginButton" CssClass="login-block">
                        <asp:Login ID="LoginForm" TitleText="" OnLoggedIn="OnLoggedIn" OnLoggingIn="OnLoggingIn"
                            runat="server" CreateUserUrl="~/register.aspx" DestinationPageUrl="~/Default.aspx"
                            OnLoginError="OnLoginError" RememberMeSet="True" FailureText="<% $NopResources:Login.FailureText %>">
                            <LayoutTemplate>
                                <table cellpadding="4" cellspacing="0" width="800">
                                    <tbody>
                                        <tr>
                                            <td class="Searchtitle">
                                                <asp:Literal runat="server" ID="lUsernameOrEmail" Text="E-Mail" />:
                                            </td>
                                            <td class="item-value">
                                                <asp:TextBox ID="UserName" runat="server" Width="300"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="UserNameOrEmailRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="Username is required." ToolTip="Username is required." ValidationGroup="LoginForm">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="Searchtitle">
                                                <asp:Literal runat="server" ID="lPassword" Text="<% $NopResources:Login.Password %>" />:
                                            </td>
                                            <td class="item-value">
                                                <asp:TextBox ID="Password" TextMode="Password" runat="server" MaxLength="50" Width="300"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="<% $NopResources:Login.PasswordRequired %>" ToolTip="<% $NopResources:Login.PasswordRequired %>"
                                                    ValidationGroup="LoginForm">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td class="Searchtitle">
                                                <asp:CheckBox ID="RememberMe" runat="server" Text="<% $NopResources:Login.RememberMe %>">
                                                </asp:CheckBox>
                                                |
                                                <asp:HyperLink ID="hlForgotPassword" runat="server" NavigateUrl="~/passwordrecovery.aspx"
                                                    Text="<% $NopResources:Login.ForgotPassword %>"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td class="Searchtitle">
                                                <div>
                                                    <div class="div_bntBuynow1">
                                                    </div>
                                                    <div class="div_bntBuynow2">
                                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="<% $NopResources:Login.LoginButton %>"
                                                            ValidationGroup="LoginForm" CssClass="btnSearchBox" />
                                                    </div>
                                                    <div class="div_bntBuynow3">
                                                    </div>
                                                </div>
                                               <div class="clear"></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td class="Searchtitle">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <nopCommerce:Captcha ID="CaptchaCtrl" runat="server" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                        </asp:Login>
                    </asp:Panel>
                </div>
            </div>
            <div class="clear">
            </div>
            <nopCommerce:Topic ID="topicLoginRegistrationInfoText" runat="server" TopicName="LoginRegistrationInfo"
                OverrideSEO="false"></nopCommerce:Topic>
                <div class="clear-20">
            </div>
        </div>
    </div>
    <div>
        <div class="Box4_bot1" style="">
        </div>
        <div class="Box4_bot2" style="width: 950px;">
        </div>
        <div class="Box4_bot3" style="">
        </div>
    </div>
    <div class="clear">
    </div>
</div>
