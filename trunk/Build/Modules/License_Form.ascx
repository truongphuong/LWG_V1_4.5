<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="License_Form.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Modules.License_Form" %>

<asp:Panel runat="server" ID="pnForm">
<div>
    <div class="ftb_bot1_Contact">
    </div>
    <div class="ftb_bot2_Contact">
        Submit Request
    </div>
    <div class="ftb_bot3_Contact">
    </div>
</div>
<div class="clear">
</div>
<div>
    <div class="ftb_bot4_Contact">
        <center>
            <table>
                <tr>
                    <td align="left" style="width: 100px;">
                        Name<span style="color: #fa0000">*</span>:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="requireName" ControlToValidate="txtName"
                            Text="*" ErrorMessage="REQ"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Email<span style="color: #fa0000">*</span>:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="requireEmail" ControlToValidate="txtEmail"
                            Text="*" ErrorMessage="REQ"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Phone<span style="color: #fa0000">*</span>:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="requirePhone" ControlToValidate="txtPhone"
                            Text="*" ErrorMessage="REQ"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Address<span style="color: #fa0000">*</span>:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtAddress"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="requireAddress" ControlToValidate="txtAddress"
                            Text="*" ErrorMessage="REQ"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        City<span style="color: #fa0000">*</span>:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtCity"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="requireCity" ControlToValidate="txtCity"
                            Text="*" ErrorMessage="REQ"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        State<span style="color: #fa0000">*</span>:
                    </td>
                    <td align="left">
                        <select name="jumpMenu" id="jumpMenu" style="width: 230px;" runat="server">
                            <option value="AL">Alabama</option>
                            <option value="AK">Alaska</option>
                            <option value="AZ">Arizona</option>
                            <option value="AR">Arkansas</option>
                            <option value="CA">California</option>
                            <option value="CO">Colorado</option>
                            <option value="CT">Connecticut</option>
                            <option value="DC">D.C.</option>
                            <option value="DE">Delaware</option>
                            <option value="FL">Florida</option>
                            <option value="GA">Georgia</option>
                            <option value="HI">Hawaii</option>
                            <option value="ID">Idaho</option>
                            <option value="IL">Illinois</option>
                            <option value="IN">Indiana</option>
                            <option value="IA">Iowa</option>
                            <option value="KS">Kansas</option>
                            <option value="KY">Kentucky</option>
                            <option value="LA">Louisiana</option>
                            <option value="ME">Maine</option>
                            <option value="MD">Maryland</option>
                            <option value="MA">Massachusetts</option>
                            <option value="MI">Michigan</option>
                            <option value="MN">Minnesota</option>
                            <option value="MS">Mississippi</option>
                            <option value="MO">Missouri</option>
                            <option value="MT">Montana</option>
                            <option value="NE">Nebraska</option>
                            <option value="NV">Nevada</option>
                            <option value="NH">New Hampshire</option>
                            <option value="NJ">New Jersey</option>
                            <option value="NM">New Mexico</option>
                            <option value="NY">New York</option>
                            <option value="NC">North Carolina</option>
                            <option value="ND">North Dakota</option>
                            <option value="OH">Ohio</option>
                            <option value="OK">Oklahoma</option>
                            <option value="OR">Oregon</option>
                            <option value="PA">Pennsylvania</option>
                            <option value="RI">Rhode Island</option>
                            <option value="SC">South Carolina</option>
                            <option value="SD">South Dakota</option>
                            <option value="TN">Tennessee</option>
                            <option value="TX">Texas</option>
                            <option value="UT">Utah</option>
                            <option value="VT">Vermont</option>
                            <option value="VA">Virginia</option>
                            <option value="WA">Washington</option>
                            <option value="WV">West Virginia</option>
                            <option value="WI">Wisconsin</option>
                            <option value="WY">Wyoming</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Zip<span style="color: #fa0000">*</span>:
                    </td>
                    <td align="left">
                        <asp:TextBox runat="server" ID="txtZipcode"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="requireZipcode" ControlToValidate="txtZipcode"
                            Text="*" ErrorMessage="REQ"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        ( <span style="color: #fa0000;">*</span> )<span style="font-style: italic;">required
                        field
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left">
                        <asp:ImageButton ID="imbSubmit" runat="server" ImageUrl="~/App_Themes/darkOrange/images/btn_submit.png" OnClick="imbSubmit_Click" />
                    </td>
                </tr>
            </table>
        </center>
        <div class="clear-10">
        </div>
    </div>
</div>
<div>
    <div class="ftb_bot5_Contact">
    </div>
    <div class="ftb_bot6_Contact">
    </div>
    <div class="ftb_bot7_Contact">
    </div>
</div>
</asp:Panel>
<asp:Panel runat="server" ID="pnMessage" Visible="false">
    <asp:Literal runat="server" ID="ltrMessage"></asp:Literal>
    <br />
    <asp:HyperLink runat="server" ID="lnkBack">Click here to return to the form.</asp:HyperLink>
</asp:Panel>