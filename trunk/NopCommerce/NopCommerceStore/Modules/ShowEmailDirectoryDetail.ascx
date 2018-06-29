<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowEmailDirectoryDetail.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Modules.ShowEmailDirectoryDetail" %>
<div class="html-header">
    Home / <span style="color: #0068a2;">Email Directory</span> /
    <asp:Label ID="lblname1" runat="server"></asp:Label>
</div>
<div class="clear-15">
</div>
<div style="font-size: 30px; color: #0068a2; font-weight: bold; float: left;">
    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
</div>
<div class="clear-15">
</div>
<div>
    <div>
        <div style="width: 150px; float: left;">
            <asp:Image ID="iEmail" runat="server" Width="150px" />
        </div>
        <div style="width: 780px; padding-left: 10px; float: left; text-align: justify;">
            <div style="width: 100%; border-bottom: 1px dotted #000000;">
                <div class="clear-15">
                </div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="100px" style="color: rgb(243, 112, 50); font-size: 14px; font-weight: bold;">
                            Title
                        </td>
                        <td style="color: #000000; font-size: 14px; font-weight: bold;">
                            <asp:Label runat="server" ID="lblJobTitle"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="color: rgb(243, 112, 50); font-size: 14px; font-weight: bold;">
                            Email:
                        </td>
                        <td style="color: #0068A2; font-size: 14px; font-weight: bold;">
                            <asp:Label ID="lblEmailAddress" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="color: rgb(243, 112, 50); font-size: 14px; font-weight: bold;">
                            Phone
                        </td>
                        <td style="color: #000000; font-size: 14px; font-weight: bold;">
                            <asp:Label runat="server" ID="lblPhone"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div class="clear-15">
                </div>
            </div>
            <div class="clear-15">
            </div>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="color: rgb(243, 112, 50); font-size: 14px; font-weight: bold;">
                        About
                        <asp:Label ID="lblName2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="lblDescrption" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <a href="ShowEmailDirectoryList.aspx" style="text-decoration: none; font-size: 15px;
                            font-weight: bold; color: #034568;">Black To Main Listing</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
