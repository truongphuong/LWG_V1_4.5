<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowEmailDirectoryList.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Modules.ShowEmailDirectoryList" %>
<div class="html-header">
    Home / <span style="color: #0068a2;">Email Directory</span>
</div>
<div class="clear-15">
</div>
<div style="font-size: 30px; color: #0068a2; font-weight: bold; float: left;">
    Email Directory
</div>
<div class="clear-15">
</div>
<div id="alpha" style="font-size: 16px;">
    <a id="0" class="a_active" href="ShowEmailDirectoryList.aspx?view=all" alt="">All</a> <a
        id="1" href="ShowEmailDirectoryList.aspx?view=A" alt="">A</a> <a id="2" href="ShowEmailDirectoryList.aspx?view=B"
            alt="">B</a> <a id="3" href="ShowEmailDirectoryList.aspx?view=C" alt="">C</a> <a id="4"
                href="ShowEmailDirectoryList.aspx?view=D" alt="">D</a> <a id="5" href="ShowEmailDirectoryList.aspx?view=E"
                    alt="">E</a> <a id="6" href="ShowEmailDirectoryList.aspx?view=F" alt="">F</a>
    <a id="7" href="ShowEmailDirectoryList.aspx?view=G" alt="">G</a> <a id="8" href="ShowEmailDirectoryList.aspx?view=H"
        alt="">H</a> <a id="9" href="ShowEmailDirectoryList.aspx?view=I" alt="">I</a> <a id="10"
            href="ShowEmailDirectoryList.aspx?view=J" alt="">J</a> <a id="11" href="ShowEmailDirectoryList.aspx?view=K"
                alt="">K</a> <a id="12" href="ShowEmailDirectoryList.aspx?view=L" alt="">L</a>
    <a id="13" href="ShowEmailDirectoryList.aspx?view=M" alt="">M</a> <a id="14" href="ShowEmailDirectoryList.aspx?view=N"
        alt="">N</a> <a id="15" href="ShowEmailDirectoryList.aspx?view=O" alt="">O</a> <a id="16"
            href="ShowEmailDirectoryList.aspx?view=P" alt="">P</a> <a id="17" href="ShowEmailDirectoryList.aspx?view=Q"
                alt="">Q</a> <a id="18" href="ShowEmailDirectoryList.aspx?view=R" alt="">R</a>
    <a id="19" href="ShowEmailDirectoryList.aspx?view=S" alt="">S</a> <a id="20" href="ShowEmailDirectoryList.aspx?view=T"
        alt="">T</a> <a id="21" href="ShowEmailDirectoryList.aspx?view=U" alt="">U</a> <a id="22"
            href="ShowEmailDirectoryList.aspx?view=V" alt="">V</a> <a id="23" href="ShowEmailDirectoryList.aspx?view=W"
                alt="">W</a> <a id="24" href="ShowEmailDirectoryList.aspx?view=X" alt="">X</a>
    <a id="25" href="ShowEmailDirectoryList.aspx?view=Y" alt="">Y</a> <a id="26" href="ShowEmailDirectoryList.aspx?view=Z"
        alt="">Z</a>
</div>
<div class="clear-15">
</div>
<div align="left" style="padding-left: 25px; padding-right: 25px;">
    <table width="100%" id="table_alpha">
        <tr>
            <td align="justify" valign="top" style="width: 25%; padding-right: 10px;">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
            <td align="justify" valign="top" style="width: 25%; padding-left: 10px; padding-right: 10px;">
                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
            </td>
            <td align="justify" valign="top" style="width: 25%; padding-left: 10px; padding-right: 10px;">
                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
            </td>
            <td align="justify" valign="top" style="width: 25%; padding-left: 10px;">
                <asp:Literal ID="Literal4" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</div>

<asp:HiddenField ID="hdfalpha" runat="server" />

<script type="text/javascript">
   window.onload = function LoadFocus() {
        menu4();
    }
</script>

<script type="text/javascript">

    function menu4() {
        var i;
        for (i = 0; i <= 26; i++) {
            var t = i;
            var temp = document.getElementById(t);
            temp.removeAttribute("class");
        }

        var ispage = document.getElementById('ctl00_ctl00_cph1_cph1_ShowEmailDirectoryList1_hdfalpha').value;
//        alert(ispage);
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
                case '0': 
                    document.getElementById('0').className = 'a_active';
                    break;
            }
        }
        else {
            document.getElementById('0').className = 'a_active';
        }
    } 
</script>

