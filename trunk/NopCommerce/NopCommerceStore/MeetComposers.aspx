<%@ Page Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    CodeBehind="MeetComposers.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.MeetComposersPage" %>

<%@ Register Src="Modules/Contact_Us.ascx" TagName="Contact_Us" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <!--Slide-->
    <div style="text-align: left;">
        <div style="float: left; width: 227px;">
            <uc1:Contact_Us ID="Contact_Us2" runat="server" />
        </div>
        <div style="width: 720px; float: left; margin-left: 10px; background-color: #FFFFFF;">
            <div style="height: 7px;">
                <div class="ftb_bot4">
                </div>
                <div class="ftb_bot5" style="width: 706px;">
                </div>
                <div class="ftb_bot6">
                </div>
            </div>
            <div style="min-height: 712px; background-color: #ffffff; padding-left: 15px; padding-right: 15px;
                color: #000000">
                <div class="html-header">
                    Home / <span style="color: #0068a2;">Composers, Arrangers, Editors and Clinicians</span>
                </div>
                <div class="clear-15">
                </div>
                <div style="font-size: 30px; color: #0068a2; font-weight: bold; float: left;">
                    Composers, Arrangers, Editors and Clinicians
                </div>
                <div class="clear-15">
                </div>
                <div id="alpha" style="font-size: 16px;">
                    <a id="0" class="a_active" href="MeetComposers.aspx?Filter=all" alt="">All</a> <a
                        id="1" href="MeetComposers.aspx?Filter=A" alt="">A</a> <a id="2" href="MeetComposers.aspx?Filter=B"
                            alt="">B</a> <a id="3" href="MeetComposers.aspx?Filter=C" alt="">C</a> <a id="4"
                                href="MeetComposers.aspx?Filter=D" alt="">D</a> <a id="5" href="MeetComposers.aspx?Filter=E"
                                    alt="">E</a> <a id="6" href="MeetComposers.aspx?Filter=F" alt="">F</a>
                    <a id="7" href="MeetComposers.aspx?Filter=G" alt="">G</a> <a id="8" href="MeetComposers.aspx?Filter=H"
                        alt="">H</a> <a id="9" href="MeetComposers.aspx?Filter=I" alt="">I</a> <a id="10"
                            href="MeetComposers.aspx?Filter=J" alt="">J</a> <a id="11" href="MeetComposers.aspx?Filter=K"
                                alt="">K</a> <a id="12" href="MeetComposers.aspx?Filter=L" alt="">L</a>
                    <a id="13" href="MeetComposers.aspx?Filter=M" alt="">M</a> <a id="14" href="MeetComposers.aspx?Filter=N"
                        alt="">N</a> <a id="15" href="MeetComposers.aspx?Filter=O" alt="">O</a> <a id="16"
                            href="MeetComposers.aspx?Filter=P" alt="">P</a> <a id="17" href="MeetComposers.aspx?Filter=Q"
                                alt="">Q</a> <a id="18" href="MeetComposers.aspx?Filter=R" alt="">R</a>
                    <a id="19" href="MeetComposers.aspx?Filter=S" alt="">S</a> <a id="20" href="MeetComposers.aspx?Filter=T"
                        alt="">T</a> <a id="21" href="MeetComposers.aspx?Filter=U" alt="">U</a> <a id="22"
                            href="MeetComposers.aspx?Filter=V" alt="">V</a> <a id="23" href="MeetComposers.aspx?Filter=W"
                                alt="">W</a> <a id="24" href="MeetComposers.aspx?Filter=X" alt="">X</a>
                    <a id="25" href="MeetComposers.aspx?Filter=Y" alt="">Y</a> <a id="26" href="MeetComposers.aspx?Filter=Z"
                        alt="">Z</a>
                </div>
                <div class="clear-15">
                </div>
                <div align="left" style="padding-left: 25px; padding-right: 25px;" id="divNonFilter"
                    runat="server">
                    <table width="100%" id="table_alpha">
                        <tr>
                            <td align="justify" valign="top" style="width: 25%; padding-right: 10px; border-right: solid 1px #d7d7d7;
                                border-right-style: dotted;">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </td>
                            <td align="justify" valign="top" style="width: 25%; padding-left: 10px; padding-right: 10px;
                                border-right: solid 1px #d7d7d7; border-right-style: dotted;">
                                <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                            </td>
                            <%-- <td align="justify" valign="top" style="width: 25%; padding-left: 10px; padding-right: 10px;
                    border-right: solid 1px #d7d7d7; border-right-style: dotted;">
                    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                </td>--%>
                            <td align="justify" valign="top" style="width: 25%; padding-left: 10px;">
                                <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </div>
                <div align="left" style="padding-left: 25px; padding-right: 25px;" id="divFilter"
                    runat="server" visible="false">
                    <asp:Literal ID="Literal4" runat="server"></asp:Literal>
                </div>
                <asp:HiddenField ID="hdfalpha" runat="server" />
            </div>
            <div style="height: 7px;">
                <div class="ftb_bot1">
                </div>
                <div class="ftb_bot2" style="width: 706px;">
                </div>
                <div class="ftb_bot3">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
    </div>

    <script type="text/javascript" language="javascript">
        var i;
        for (i = 1; i <= 5; i++) {
            var t = "C" + i;
            var temp = document.getElementById(t);
            temp.removeAttribute("class");
        }
        var temp1 = document.getElementById("C2");
        temp1.setAttribute("class", "active");        
    </script>

    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent4').className = "a_mainmenuActive";
       
    </script>

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

            var ispage = document.getElementById('ctl00_ctl00_cph1_cph1_hdfalpha').value;
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

</asp:Content>
