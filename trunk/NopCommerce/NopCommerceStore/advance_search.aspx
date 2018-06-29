<%@ Page Language="C#" MasterPageFile="~/MasterPages/OneColumn.master" AutoEventWireup="true"
    CodeBehind="advance_search.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.advance_search" %>

<%@ Register TagPrefix="nopCommerce" TagName="ProductBox2" Src="~/Modules/ProductBox2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">

<%--disable enter key--%>
<script type="text/javascript">
    function stopRKey(evt) {
        var evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if (evt.keyCode == 13) { return false; }
    }
    document.onkeypress = stopRKey; 
</script>
<%--disable enter key--%>

    <asp:Literal runat="server" ID="ltrQuery" Visible="false"></asp:Literal>
    
    <div class="clear">
    </div>
    <asp:Panel runat="server" ID="pnSearchForm">
        <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
            margin-bottom: 5px; border-bottom: solid 1px #000000;">
            Advanced Search</div>
        <div class="clear">
        </div>
        <div class=" SearchAdvance">
            <table cellpadding="4" cellspacing="0">
                <tr>
                    <td style="width: 250px;">
                        <b>Catalog Number:</b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSku" ValidationGroup="asearch"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator runat="server" ID="reqComposer"
            ControlToValidate="txtComposer" ValidationGroup="asearch"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px;">
                        <b>Composer:</b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtComposer" ValidationGroup="asearch"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator runat="server" ID="reqComposer"
            ControlToValidate="txtComposer" ValidationGroup="asearch"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Arranger or Editor:</b> (last name first)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtArranger" ValidationGroup="asearch"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator runat="server" ID="reqArranger"
            ControlToValidate="txtArranger" ValidationGroup="asearch"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Title:</b> (and/or subtitle)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTitle" ValidationGroup="asearch"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator runat="server" ID="reqTitle"
            ControlToValidate="txtTitle" ValidationGroup="asearch"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Duration:</b> (in minutes)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDuration" ValidationGroup="asearch" Width="225"></asp:TextBox>
                        <asp:DropDownList runat="server" ID="drpDuration" Width="225">
                            <asp:ListItem Text="equals" Value="0"></asp:ListItem>
                            <asp:ListItem Text="greater than" Value="2"></asp:ListItem>
                            <asp:ListItem Text="greater than or equals" Value="1"></asp:ListItem>
                            <asp:ListItem Text="less than" Value="-2"></asp:ListItem>
                            <asp:ListItem Text="less than or equals" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="not equals" Value="-3"></asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:RequiredFieldValidator runat="server" ID="reqDuration"
            ControlToValidate="txtDuration" ValidationGroup="asearch"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator runat="server" ID="regDuration" ControlToValidate="txtDuration"
                            ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="asearch"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Year:</b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtYear" ValidationGroup="asearch" Width="225"></asp:TextBox>
                        <%--<asp:DropDownList runat="server" ID="drpYear" Width="225">
                            <asp:ListItem Text="equals" Value="0"></asp:ListItem>
                            <asp:ListItem Text="greater than" Value="2"></asp:ListItem>
                            <asp:ListItem Text="greater than or equals" Value="1"></asp:ListItem>
                            <asp:ListItem Text="less than" Value="-2"></asp:ListItem>
                            <asp:ListItem Text="less than or equals" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="not equals" Value="-3"></asp:ListItem>
                        </asp:DropDownList>--%>
                        <%--<asp:RequiredFieldValidator runat="server" ID="reqYear"
            ControlToValidate="txtYear" ValidationGroup="asearch"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator runat="server" ID="regYear" ControlToValidate="txtYear"
                            ValidationExpression="^[1-9]+[0-9]*$" ValidationGroup="asearch"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Grade:</b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtGrade" ValidationGroup="asearch"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator runat="server" ID="reqGrade"
            ControlToValidate="txtGrade" ValidationGroup="asearch"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Keyword:</b>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtInstrumentation" ValidationGroup="asearch"></asp:TextBox>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        Keyboard Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpKeyboardTitles">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        String Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpStringTitles">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Woodwind Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpWoodwindTitles">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Brass Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpBrassTitles">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Percussion Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpPercussionTitles">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Chamber Ens. Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpChamberTitles">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Large Ens. Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpLargeTitles">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Band/Wind Ens. Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpBandWindTitles">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Vocal/Choral Titles:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpVocalChoralTitles">
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <b>Category:</b>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpCategory">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Period/Style:</b>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpPeriodStyle">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Genre:</b>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpGenre">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Series:</b>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpSeries">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Publisher:</b>
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="drpPublisher">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div style="float: left; width: 80px;">
                            <div class="div_bntBuynow1">
                            </div>
                            <div class="div_bntBuynow2">
                                <asp:Button runat="server" ID="btnSearch" Text="Search >>" OnClick="btnSearch_Click"
                                    ValidationGroup="asearch" CssClass="btnSearchBox" />
                            </div>
                            <div class="div_bntBuynow3">
                            </div>
                        </div>
                        <div style="float: left; width: 80px;">
                            <div class="div_bntBuynowBlack1">
                            </div>
                            <div class="div_bntBuynowBlack2">
                                <asp:Button runat="server" ID="btnClearForm" Text="Clear Form" OnClick="btnClearForm_Click"
                                    CssClass="btnSearchBox" />
                            </div>
                            <div class="div_bntBuynowBlack3">
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <div class="clear-20">
    </div>
    <div class="SearchResults" style="margin: 0px; text-align: left">
        <asp:Panel runat="server" ID="pnResult">
            <div>
                <asp:Literal runat="server" ID="ltrError" Visible="false" Text="<% $NopResources:Search.NoResultsText %>"></asp:Literal>
            </div>
            <div>
                <a href="advance_search.aspx">Perform New Search</a>
            </div>
            <div style="font-size: 25px; color: #0068a2; font-weight: bold; padding-bottom: 5px;
                margin-bottom: 5px; border-bottom: solid 1px #000000;">
                Search Results</div>
            <div class="clear">
            </div>
            <div style="width: 940px; margin: 0px auto">
                <asp:ListView runat="server" ID="lvResult" OnPagePropertiesChanging="lvProducts_OnPagePropertiesChanging">
                    <LayoutTemplate>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="item-box" style="margin: 0px">
                            <nopCommerce:ProductBox2 ID="ctrlProductBox" Lwg_Product='<%# Container.DataItem %>'
                                runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </asp:Panel>
    </div>
    <div class="pager">
        <asp:DataPager ID="pagerProducts" runat="server" PagedControlID="lvResult" PageSize="10">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"
                    FirstPageText="<% $NopResources:Search.First %>" LastPageText="<% $NopResources:Search.Last %>"
                    NextPageText="<% $NopResources:Search.Next %>" PreviousPageText="<% $NopResources:Search.Previous %>" />
            </Fields>
        </asp:DataPager>
    </div>
    <div class="clear-20">
    </div>
</asp:Content>
