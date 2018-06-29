<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DealerList.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Modules.DealerList" %>
<div style="width:100%; height:50px">
    <div class="html-title" style="float:left">
        Dealer List
    </div>
    <div style="text-align:right; padding-top:20px">
        Sort by
        <asp:DropDownList ID="ddlSortType" AutoPostBack="true" runat="server" 
            onselectedindexchanged="ddlSortType_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
</div>
<div id="divAlphabet" class="dealer_alpha" runat="server" style="font-size: 16px;">
    <a id="0" class="a_active" href="Dealer_List.aspx?Filter=all" alt="">All</a> <a id="1"
        href="Dealer_List.aspx?Filter=A" alt="">A</a> <a id="2" href="Dealer_List.aspx?Filter=B"
            alt="">B</a> <a id="3" href="Dealer_List.aspx?Filter=C" alt="">C</a> <a id="4" href="Dealer_List.aspx?Filter=D"
                alt="">D</a> <a id="5" href="Dealer_List.aspx?Filter=E" alt="">E</a>
    <a id="6" href="Dealer_List.aspx?Filter=F" alt="">F</a> <a id="7" href="Dealer_List.aspx?Filter=G"
        alt="">G</a> <a id="8" href="Dealer_List.aspx?Filter=H" alt="">H</a> <a id="9" href="Dealer_List.aspx?Filter=I"
            alt="">I</a> <a id="10" href="Dealer_List.aspx?Filter=J" alt="">J</a> <a id="11"
                href="Dealer_List.aspx?Filter=K" alt="">K</a> <a id="12" href="Dealer_List.aspx?Filter=L"
                    alt="">L</a> <a id="13" href="Dealer_List.aspx?Filter=M" alt="">M</a>
    <a id="14" href="Dealer_List.aspx?Filter=N" alt="">N</a> <a id="15" href="Dealer_List.aspx?Filter=O"
        alt="">O</a> <a id="16" href="Dealer_List.aspx?Filter=P" alt="">P</a> <a id="17"
            href="Dealer_List.aspx?Filter=Q" alt="">Q</a> <a id="18" href="Dealer_List.aspx?Filter=R"
                alt="">R</a> <a id="19" href="Dealer_List.aspx?Filter=S" alt="">S</a>
    <a id="20" href="Dealer_List.aspx?Filter=T" alt="">T</a> <a id="21" href="Dealer_List.aspx?Filter=U"
        alt="">U</a> <a id="22" href="Dealer_List.aspx?Filter=V" alt="">V</a> <a id="23"
            href="Dealer_List.aspx?Filter=W" alt="">W</a> <a id="24" href="Dealer_List.aspx?Filter=X"
                alt="">X</a> <a id="25" href="Dealer_List.aspx?Filter=Y" alt="">Y</a>
    <a id="26" href="Dealer_List.aspx?Filter=Z" alt="">Z</a>
</div>
<div id="divState" runat="server" class="dealer_alpha">
    <asp:Literal ID="ltrStateMenu" runat="server"></asp:Literal>
    <div class="clear-10"></div>
    <div class="dealerName"><%=GetLocaleResourceString("Dealer.OutsideUS")%></div>
    <asp:Literal ID="ltrOutofUsState" runat="server"></asp:Literal>
</div>
<div class="clear">
</div>
<%--<div>
    <div class="dealerName">
        <asp:Label ID="lblDealerName" runat="server" Text="Dealer Name"></asp:Label>
    </div>
    <div class="dealerAddress">
        <asp:Label ID="lblAddress1" runat="server" Text="Address Line 1"></asp:Label>
    </div>
    <div class="dealerAddress">
        <asp:Label ID="lblAddress2" runat="server" Text="Address Line 2"></asp:Label>
    </div>
    <div class="dealerAddress">
        <asp:Label ID="lblCityZipState" runat="server" Text="City,12345 AZ"></asp:Label>
    </div>
    <div class="dealerAddress">
        <asp:Label ID="lblPhone" runat="server" Text="Phone:12345678"></asp:Label>
    </div>
    <div class="dealerAddress">
        <asp:Label ID="lblFax" runat="server" Text="Fax:12345678"></asp:Label>
    </div>
    <div class="dealerWebLink">
        <asp:HyperLink ID="hpWebLink" runat="server" Text="www.webaddress.com"></asp:HyperLink>
    </div>
</div>--%>
<div>
    <table>
        <tr>
            <td style="vertical-align: top">
                <asp:Literal ID="ltrDealers1" runat="server"></asp:Literal>
            </td>
            <td style="width: 15px">
            </td>
            <td style="vertical-align: top">
                <asp:Literal ID="ltrDealers2" runat="server"></asp:Literal>
            </td>
            <td style="width: 15px">
            </td>
            <td style="vertical-align: top">
                <asp:Literal ID="ltrDealers3" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="5">
            <asp:Label style="color:#00B1CE; font-size:24px; font-weight:bold" id="lblOutOfUS" runat="server" Text="<% $NopResources:Dealer.OutsideUS %>" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <asp:Literal ID="ltrDealers4" runat="server"></asp:Literal>
            </td>
            <td style="width: 15px">
            </td>
            <td style="vertical-align: top">
                <asp:Literal ID="ltrDealers5" runat="server"></asp:Literal>
            </td>
            <td style="width: 15px">
            </td>
            <td style="vertical-align: top">
                <asp:Literal ID="ltrDealers6" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hdfalpha" runat="server" />
</div>
<div class="clear-15">
</div>

<script type="text/javascript">
    window.onload = function LoadFocus() {
        menu3();
    }
    </script>

    <script type="text/javascript">

        function menu3() {
            var i;
            for (i = 0; i <= 26; i++) {
                var t = i;
                var temp = document.getElementById(t);
                temp.removeAttribute("class");
            }

            var ispage = document.getElementById('<%=hdfalpha.ClientID %>').value;
            //            alert(ispage);
            if (ispage != null && ispage != '') {
                switch (ispage) {
                    case 'all':
                        document.getElementById('0').className = 'a_active';
                        break;
                    case 'A':
                        document.getElementById('1').className = 'a_active';
                        break;
                    case 'B':
                        document.getElementById('2').className = 'a_active';
                        break;
                    case 'C':
                        document.getElementById('3').className = 'a_active';
                        break;
                    case 'D':
                        document.getElementById('4').className = 'a_active';
                        break;
                    case 'E':
                        document.getElementById('5').className = 'a_active';
                        break;
                    case 'F':
                        document.getElementById('6').className = 'a_active';
                        break;
                    case 'G':
                        document.getElementById('7').className = 'a_active';
                        break;
                    case 'H':
                        document.getElementById('8').className = 'a_active';
                        break;
                    case 'I':
                        document.getElementById('9').className = 'a_active';
                        break;
                    case 'J':
                        document.getElementById('10').className = 'a_active';
                        break;
                    case 'K':
                        document.getElementById('11').className = 'a_active';
                        break;
                    case 'L':
                        document.getElementById('12').className = 'a_active';
                        break;
                    case 'M':
                        document.getElementById('13').className = 'a_active';
                        break;
                    case 'N':
                        document.getElementById('14').className = 'a_active';
                        break;
                    case 'O':
                        document.getElementById('15').className = 'a_active';
                        break;
                    case 'P':
                        document.getElementById('16').className = 'a_active';
                        break;
                    case 'Q':
                        document.getElementById('17').className = 'a_active';
                        break;
                    case 'R':
                        document.getElementById('18').className = 'a_active';
                        break;
                    case 'S':
                        document.getElementById('19').className = 'a_active';
                        break;
                    case 'T':
                        document.getElementById('20').className = 'a_active';
                        break;
                    case 'U':
                        document.getElementById('21').className = 'a_active';
                        break;
                    case 'V':
                        document.getElementById('22').className = 'a_active';
                        break;
                    case 'W':
                        document.getElementById('23').className = 'a_active';
                        break;
                    case 'X':
                        document.getElementById('24').className = 'a_active';
                        break;
                    case 'Y':
                        document.getElementById('25').className = 'a_active';
                        break;
                    case 'Z':
                        document.getElementById('26').className = 'a_active';
                        break;
                    case '0': //null
                        document.getElementById('0').className = 'a_active';
                        break;
                }
            }
            else {
                document.getElementById('0').className = 'a_active';
            }
        } 
    </script>
