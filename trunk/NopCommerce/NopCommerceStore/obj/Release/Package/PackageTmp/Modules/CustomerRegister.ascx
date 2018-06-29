<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CustomerRegisterControl"
    CodeBehind="CustomerRegister.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="Captcha" Src="~/Modules/Captcha.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="Topic" Src="~/Modules/Topic.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="DatePicker2" Src="~/Modules/DatePicker2.ascx" %>
<div style="color: #FFE66B; font-size: 25px; font-weight: bold;">
    <%=GetLocaleResourceString("Account.Registration")%>
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
        <div>
            <div class="clear">
            </div>
            <div class="body">
                <asp:CreateUserWizard ID="CreateUserForm" EmailRegularExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                    RequireEmail="False" runat="server" OnCreatedUser="CreatedUser" OnCreatingUser="CreatingUser"
                    OnCreateUserError="CreateUserError" FinishDestinationPageUrl="~/default.aspx"
                    ContinueDestinationPageUrl="~/default.aspx" Width="100%" LoginCreatedUser="true">
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="">
                            <ContentTemplate>
                                <div class="message-error">
                                    <div>
                                        <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div>
                                        <asp:ValidationSummary ID="valSum" runat="server" ShowSummary="true" DisplayMode="BulletList"
                                            ValidationGroup="CreateUserForm" />
                                    </div>
                                </div>
                                <div class="clear-10">
                                </div>
                                <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                                    margin-bottom: 5px; border-bottom: solid 1px #000000;">
                                    <%=GetLocaleResourceString("Account.YourPersonalDetails")%>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="section-body">
                                    <table cellpadding="4" cellspacing="0">
                                        <tbody>
                                            <asp:PlaceHolder runat="server" ID="phGender">
                                                <tr>
                                                    <td class="Searchtitle">
                                                        <%=GetLocaleResourceString("Account.Gender")%>:
                                                    </td>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton runat="server" ID="rbGenderM" GroupName="Gender" Text="" Checked="true" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" Text="<% $NopResources:Account.GenderMale %>"></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton runat="server" ID="rbGenderF" GroupName="Gender" Text="" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Text="<% $NopResources:Account.GenderFemale %>"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </asp:PlaceHolder>
                                            <tr class="row">
                                                <td class="Searchtitle">
                                                    <%=GetLocaleResourceString("Account.FirstName")%>:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="40" Width="200"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName"
                                                        ErrorMessage="<% $NopResources:Account.FirstNameIsRequired %>" ToolTip="<% $NopResources:Account.FirstNameIsRequired %>"
                                                        ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="row">
                                                <td class="Searchtitle">
                                                    <%=GetLocaleResourceString("Account.LastName")%>:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="40" Width="200"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName"
                                                        ErrorMessage="<% $NopResources:Account.LastNameIsRequired %>" ToolTip="<% $NopResources:Account.LastNameIsRequired %>"
                                                        ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <asp:PlaceHolder runat="server" ID="phDateOfBirth">
                                                <tr class="row">
                                                    <td class="Searchtitle">
                                                        <%=GetLocaleResourceString("Account.DateOfBirth")%>:
                                                    </td>
                                                    <td class="item-value">
                                                        <nopCommerce:DatePicker2 runat="server" ID="dtDateOfBirth" />
                                                    </td>
                                                </tr>
                                            </asp:PlaceHolder>
                                            <%--pnlEmail is visible only when customers are authenticated by usernames and is used to get an email--%>
                                            <tr class="row" runat="server" id="pnlEmail">
                                                <td class="Searchtitle">
                                                    <%=GetLocaleResourceString("Account.E-Mail")%>:
                                                </td>
                                                <td class="item-value">
                                                    <asp:TextBox ID="Email" runat="server" MaxLength="40" Width="200"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                        ErrorMessage="Email is required" ToolTip="Email is required" Display="Dynamic"
                                                        ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="revEmail" Display="Dynamic" ControlToValidate="Email"
                                                        ErrorMessage="Invalid email" ToolTip="Invalid email" ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+"
                                                        ValidationGroup="CreateUserForm">*</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <%--this table row is used to get an username when customers are authenticated by usernames--%>
                                            <%--this table row is used to get an email when customers are authenticated by emails--%>
                                            <tr class="row">
                                                <td class="Searchtitle">
                                                    <asp:Literal runat="server" ID="lUsernameOrEmail" Text="E-Mail" />:
                                                </td>
                                                <td class="item-value">
                                                    <asp:TextBox ID="UserName" runat="server" MaxLength="40" Width="200"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameOrEmailRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="Username is required" ToolTip="Username is required" Display="Dynamic"
                                                        ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator runat="server" ID="refUserNameOrEmail" Display="Dynamic"
                                                        ControlToValidate="UserName" ErrorMessage="Invalid email" ToolTip="Invalid email"
                                                        ValidationExpression="[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+" ValidationGroup="CreateUserForm">*</asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="clear-20">
                                </div>
                                <asp:PlaceHolder runat="server" ID="phCompanyDetails">
                                    <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                                        margin-bottom: 5px; border-bottom: solid 1px #000000;">
                                        <%=GetLocaleResourceString("Account.CompanyDetails")%>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="section-body">
                                        <table cellpadding="4" cellspacing="0" width="800">
                                            <tbody>
                                                <tr class="row">
                                                    <td class="Searchtitle">
                                                        <%=GetLocaleResourceString("Account.CompanyName")%>:
                                                    </td>
                                                    <td class="item-value">
                                                        <asp:TextBox ID="txtCompany" runat="server" Width="200"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ControlToValidate="txtCompany"
                                                            ErrorMessage="<% $NopResources:Account.CompanyIsRequired %>" ToolTip="<% $NopResources:Account.CompanyIsRequired %>"
                                                            ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </asp:PlaceHolder>
                                <div class="clear-20">
                                </div>
                                <asp:PlaceHolder runat="server" ID="phYourAddress">
                                    <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                                        margin-bottom: 5px; border-bottom: solid 1px #000000;">
                                        <%=GetLocaleResourceString("Account.YourAddress")%>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="section-body">
                                        <table cellpadding="4" cellspacing="0">
                                            <tbody>
                                                <asp:PlaceHolder runat="server" ID="phStreetAddress">
                                                    <tr class="row">
                                                        <td class="Searchtitle">
                                                            <%=GetLocaleResourceString("Account.StreetAddress")%>:
                                                        </td>
                                                        <td class="item-value">
                                                            <asp:TextBox ID="txtStreetAddress" runat="server" Width="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvStreetAddress" runat="server" ControlToValidate="txtStreetAddress"
                                                                ErrorMessage="<% $NopResources:Account.StreetAddressIsRequired %>" ToolTip="<% $NopResources:Account.StreetAddressIsRequired %>"
                                                                ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder runat="server" ID="phStreetAddress2">
                                                    <tr class="row">
                                                        <td class="Searchtitle">
                                                            <%=GetLocaleResourceString("Account.StreetAddress2")%>:
                                                        </td>
                                                        <td class="item-value">
                                                            <asp:TextBox ID="txtStreetAddress2" runat="server" Width="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvStreetAddress2" runat="server" ControlToValidate="txtStreetAddress2"
                                                                ErrorMessage="<% $NopResources:Account.StreetAddress2IsRequired %>" ToolTip="<% $NopResources:Account.StreetAddress2IsRequired %>"
                                                                ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder runat="server" ID="phPostCode">
                                                    <tr class="row">
                                                        <td class="Searchtitle">
                                                            <%=GetLocaleResourceString("Account.PostCode")%>:
                                                        </td>
                                                        <td class="item-value">
                                                            <asp:TextBox ID="txtZipPostalCode" runat="server" Width="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvZipPostalCode" runat="server" ControlToValidate="txtZipPostalCode"
                                                                ErrorMessage="<% $NopResources:Account.ZipPostalCodeIsRequired %>" ToolTip="<% $NopResources:Account.ZipPostalCodeIsRequired %>"
                                                                ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder runat="server" ID="phCity">
                                                    <tr class="row">
                                                        <td class="Searchtitle">
                                                            <%=GetLocaleResourceString("Account.City")%>:
                                                        </td>
                                                        <td class="item-value">
                                                            <asp:TextBox ID="txtCity" runat="server" MaxLength="40" Width="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                                                                ErrorMessage="<% $NopResources:Account.CityIsRequired %>" ToolTip="<% $NopResources:Account.CityIsRequired %>"
                                                                ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder runat="server" ID="phCountry">
                                                    <tr class="row">
                                                        <td class="Searchtitle">
                                                            <%=GetLocaleResourceString("Account.Country")%>:
                                                        </td>
                                                        <td class="item-value">
                                                            <asp:DropDownList ID="ddlCountry" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                                                Width="205px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder runat="server" ID="phStateProvince">
                                                    <tr class="row">
                                                        <td class="Searchtitle">
                                                            <%=GetLocaleResourceString("Account.StateProvince")%>:
                                                        </td>
                                                        <td class="item-value">
                                                            <asp:DropDownList ID="ddlStateProvince" AutoPostBack="False" runat="server" Width="205">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </asp:PlaceHolder>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </asp:PlaceHolder>
                                <div class="clear-20">
                                </div>
                                <asp:PlaceHolder runat="server" ID="phYourContactInformation">
                                    <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                                        margin-bottom: 5px; border-bottom: solid 1px #000000;">
                                        <%=GetLocaleResourceString("Account.YourContactInformation")%>
                                    </div>
                                    <div class="clear">
                                    </div>
                                    <div class="section-body">
                                        <table class="table-container">
                                            <tbody>
                                                <asp:PlaceHolder runat="server" ID="phTelephoneNumber">
                                                    <tr class="row">
                                                        <td class="Searchtitle">
                                                            <%=GetLocaleResourceString("Account.TelephoneNumber")%>:
                                                        </td>
                                                        <td class="item-value">
                                                            <asp:TextBox ID="txtPhoneNumber" runat="server" Width="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ControlToValidate="txtPhoneNumber"
                                                                ErrorMessage="<% $NopResources:Account.PhoneNumberIsRequired %>" ToolTip="<% $NopResources:Account.PhoneNumberIsRequired %>"
                                                                ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder runat="server" ID="phFaxNumber">
                                                    <tr class="row">
                                                        <td class="Searchtitle">
                                                            <%=GetLocaleResourceString("Account.FaxNumber")%>:
                                                        </td>
                                                        <td class="item-value">
                                                            <asp:TextBox ID="txtFaxNumber" runat="server" Width="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvFaxNumber" runat="server" ControlToValidate="txtFaxNumber"
                                                                ErrorMessage="<% $NopResources:Account.FaxIsRequired %>" ToolTip="<% $NopResources:Account.FaxIsRequired %>"
                                                                ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                </asp:PlaceHolder>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class="clear">
                                    </div>
                                </asp:PlaceHolder>
                                <div class="clear-20">
                                </div>
                                <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                                    margin-bottom: 5px; border-bottom: solid 1px #000000;">
                                    <%=GetLocaleResourceString("Account.Options")%>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="section-body">
                                    <table class="table-container">
                                        <tbody>
                                            <tr class="row">
                                                <td class="Searchtitle">
                                                    <%=GetLocaleResourceString("Account.Newsletter")%>:
                                                </td>
                                                <td class="item-value">
                                                    <asp:CheckBox ID="cbNewsletter" runat="server" Checked="true"></asp:CheckBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="clear-20">
                                </div>
                                <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                                    margin-bottom: 5px; border-bottom: solid 1px #000000;">
                                    <%=GetLocaleResourceString("Account.YourPassword")%>
                                </div>
                                <div class="clear">
                                </div>
                                <div class="section-body">
                                    <table class="table-container">
                                        <tbody>
                                            <tr class="row">
                                                <td class="Searchtitle">
                                                    <%=GetLocaleResourceString("Account.Password")%>:
                                                </td>
                                                <td class="item-value">
                                                    <asp:TextBox ID="Password" runat="server" MaxLength="50" TextMode="Password" Width="200"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="<% $NopResources:Account.PasswordIsRequired %>" ToolTip="<% $NopResources:Account.PasswordIsRequired %>"
                                                        ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="row">
                                                <td class="Searchtitle">
                                                    <%=GetLocaleResourceString("Account.PasswordConfirmation")%>:
                                                </td>
                                                <td class="item-value">
                                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" Width="200"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                                        ErrorMessage="<% $NopResources:Account.ConfirmPasswordIsRequired %>" ToolTip="<% $NopResources:Account.ConfirmPasswordIsRequired %>"
                                                        ValidationGroup="CreateUserForm">*</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="<% $NopResources:Account.EnteredPasswordsDoNotMatch %>"
                                                        ToolTip="<% $NopResources:Account.EnteredPasswordsDoNotMatch %>" ValidationGroup="CreateUserForm">*</asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr class="row">
                                                <td colspan="2">
                                                    <nopCommerce:Captcha ID="CaptchaCtrl" runat="server" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="clear">
                                </div>
                            </ContentTemplate>
                            <CustomNavigationTemplate>
                                <div style="margin-left: 205px">
                                    <div class="div_bntBuynow1">
                                    </div>
                                    <div class="div_bntBuynow2">
                                        <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="<% $NopResources:Account.RegisterNextStepButton %>"
                                            ValidationGroup="CreateUserForm" CssClass="btnSearchBox" />
                                    </div>
                                    <div class="div_bntBuynow3">
                                    </div>
                                </div>
                                <div class="clear-20">
                                </div>
                            </CustomNavigationTemplate>
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                            <ContentTemplate>
                                <div class="section-body" style=" height:300px; text-align:center;">
                                    <p style=" font-size:18px; padding-top:100px; color:#0068A2">
                                        <asp:Label runat="server" ID="lblCompleteStep"></asp:Label>
                                    </p>
                                    <div style=" margin-left:430px">
                                        <div class="div_bntBuynow1">
                                        </div>
                                        <div class="div_bntBuynow2">
                                            <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                                Text="<% $NopResources:Account.RegisterContinueButton %>" ValidationGroup="CreateUserForm"
                                                CssClass="btnSearchBox" />
                                        </div>
                                        <div class="div_bntBuynow3">
                                        </div>
                                    </div>
                                    <div class="clear-20">
                                    </div>
                                </div>
                                <div class="clear">
                                </div>
                            </ContentTemplate>
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>
                <nopCommerce:Topic ID="topicRegistrationNotAllowed" runat="server" TopicName="RegistrationNotAllowed"
                    OverrideSEO="false" Visible="false"></nopCommerce:Topic>
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
