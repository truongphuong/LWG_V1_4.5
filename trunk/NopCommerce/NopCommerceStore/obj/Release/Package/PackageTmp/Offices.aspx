<%@ Page Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    CodeBehind="Offices.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Offices" %>

<%@ Register Src="Modules/Contact_Us.ascx" TagName="Contact_Us" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <!--Slide-->
    <div style="text-align: left;">
        <div style="float: left; width: 227px;">
            <uc1:Contact_Us ID="Contact_Us1" runat="server" />
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
            <div style="height: 712px; background-color: #ffffff; padding-left: 15px; padding-right: 15px;
                color: #000000">
                <asp:Panel ID="Panel0" runat="server" Visible="true">
                    <div class="html-header">
                        Home / Contact / <span style="color: #0068a2;">Offices</span>
                    </div>
                    <div class="html-title">
                        Offices
                    </div>
                    <div>
                        <!--Record-->
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/Ludwig_Masters_logo_3D.png" width="120"/>
                            </div>
                            <div style="width: 290px; float: left; line-height: 22px;">
                                <asp:LinkButton ID="lbMain" runat="server" Font-Size="18px" ForeColor="#0068A2" Font-Overline="False"
                                    Font-Underline="False" OnClick="lbMain_Click">
                                 LudwigMasters Headquarters</asp:LinkButton><br />
                                6403 West Rogers Circle<br />
                                Boca Raton, FL 33487
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 434-6340 or (561) 241-6169
                                <br />
                                <span style="color: #000000;">Fax:</span> (561) 241-6347
                            </div>
                        </div>
                        <!--End Record-->
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/Ludwig_Masters_logo_3D.png" width="120" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <asp:LinkButton ID="lbDevelopment" runat="server" Font-Size="18px" ForeColor="#0068A2"
                                    Font-Overline="False" Font-Underline="False" OnClick="lbDevelopment_Click">LudwigMasters Development Office</asp:LinkButton><br />
                                1080 Cleveland Street
                                <br />
                                Grafton, OH 44044
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 851-1150 or (440) 926-1100
                                <br />
                                <span style="color: #000000;">Fax:</span>(440) 926-2882
                            </div>
                        </div>
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/Klavier.png" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <asp:LinkButton ID="lbRecords" runat="server" Font-Size="18px" ForeColor="#0068A2"
                                    Font-Overline="False" Font-Underline="False" OnClick="lbRecords_Click">Klavier Records</asp:LinkButton><br />
                                6403 West Rogers Circle<br />
                                Boca Raton, FL 33487
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 434-6340 or (561) 241-6169
                                <br />
                                <span style="color: #000000;">Fax:</span>(561) 241-6347
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <div class="html-header">
                        Home / Contact / Offices / <span style="color: #0068a2;">Main Office</span>
                    </div>
                    <div class="html-title">
                        Main Office (Boca Raton, FL)
                    </div>
                    <div style="color: #58595B; font-size: 15px; font-weight: bold;">
                        6403 West Rogers Circle Boca Raton, FL 33487</div>
                    <div>
                        <!--Record-->
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices1.jpg" />
                            </div>
                            <div style="width: 290px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Sales & Ordering
                                    <br />
                                    Joe Galison and Staff</span><br />
                                <a href="maito:sales@ludwigmasters.com" style="text-decoration: none;"><span style="color: #0068a2;">
                                    sales@ludwigmasters.com</span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 434-6340 or (561) 241-6169
                                <br />
                                <span style="color: #000000;">Fax:</span> (561) 241-6347
                            </div>
                        </div>
                        <!--End Record-->
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices2.jpg" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Dealer Services
                                    <br />
                                    Joe Galison</span><br />
                                <a href="maito:joe@ludwigmasters.com" style="text-decoration: none;"><span style="color: #0068a2;">
                                    joe@ludwigmasters.com</span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 434-6340 or (561) 241-6169
                                <br />
                                <span style="color: #000000;">Fax:</span> (561) 241-6347
                            </div>
                        </div>
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices2.jpg" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Accounts Payable/Receivable
                                    <br />
                                    Leon Galison</span><br />
                                <a href="maito:accounting@ludwigmasters.com" style="text-decoration: none;"><span
                                    style="color: #0068a2;">accounting@ludwigmasters.com</span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 434-6340 or (561) 241-6169
                                <br />
                                <span style="color: #000000;">Fax:</span> (561) 241-6347
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Visible="false">
                    <div class="html-header">
                        Home / Contact / Offices / <span style="color: #0068a2;">Development Office</span>
                    </div>
                    <div class="html-title">
                        Development Office (Grafton, OH)
                    </div>
                    <div style="color: #58595B; font-size: 15px; font-weight: bold;">
                        1080 Cleveland Street Grafton, OH 44044</div>
                    <div>
                        <!--Record-->
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices1.jpg" />
                            </div>
                            <div style="width: 290px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Advertising & Marketing
                                    <br />
                                    Chris Donze</span><br />
                                <a href="maito:chris@ludwigmasters.com " style="text-decoration: none;"><span style="color: #0068a2;">
                                    chris@ludwigmasters.com </span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 851-1150 or (440) 926-1100
                                <br />
                                <span style="color: #000000;">Fax:</span> (440) 926-2882
                            </div>
                        </div>
                        <!--End Record-->
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices2.jpg" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Graphics
                                    <br />
                                    Bryan Bird </span>
                                <br />
                                <a href="maito:bryan@ludwigmasters.com " style="text-decoration: none;"><span style="color: #0068a2;">
                                    bryan@ludwigmasters.com </span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 851-1150 or (440) 926-1100
                                <br />
                                <span style="color: #000000;">Fax:</span>(440) 926-2882
                            </div>
                        </div>
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices2.jpg" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Webmaster
                                    <br />
                                    [John Smith - this will change once we hire someone] </span>
                                <br />
                                <a href="maito: [john]@ludwigmasters.com  " style="text-decoration: none;"><span
                                    style="color: #0068a2;">[john]@ludwigmasters.com</span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span> (800) 434-6340 or (561) 241-6169
                                <br />
                                <span style="color: #000000;">Fax:</span>(561) 241-6347
                            </div>
                        </div>
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices2.jpg" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Composition Submissions
                                    <br />
                                    Chris Donze </span>
                                <br />
                                <a href="maito:chris@ludwigmasters.com" style="text-decoration: none;"><span style="color: #0068a2;">
                                    chris@ludwigmasters.com</span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span>(800) 851-1150 or (440) 926-1100
                                <br />
                                <span style="color: #000000;">Fax:</span>(440) 926-2882
                            </div>
                        </div>
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices2.jpg" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Editorial Department
                                    <br />
                                    Clarence Barber </span>
                                <br />
                                <a href="maito:clarence@ludwigmasters.com" style="text-decoration: none;"><span style="color: #0068a2;">
                                    clarence@ludwigmasters.com</span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span>(800) 851-1150 or (440) 926-1100
                                <br />
                                <span style="color: #000000;">Fax:</span>(440) 926-2882
                            </div>
                        </div>
                        <div style="padding-bottom: 30px; padding-top: 20px; font-size: 12px; font-weight: bold;
                            color: #58595b; float: left; border-bottom: dotted 1px #58595b;">
                            <div style="width: 130px; float: left;">
                                <img src="App_Themes/darkOrange/images/offices2.jpg" />
                            </div>
                            <div style="width: 280px; float: left; line-height: 22px;">
                                <span style="color: #0068a2; font-size: 18px;">Licensing/Permissions<br />
                                    Chris Donze </span>
                                <br />
                                <a href="maito:chris@ludwigmasters.com " style="text-decoration: none;"><span style="color: #0068a2;">
                                    chris@ludwigmasters.com</span></a>
                            </div>
                            <div style="width: 270px; float: left; padding-top: 30px; line-height: 20px;">
                                <span style="color: #000000;">Phone:</span>(800) 851-1150 or (440) 926-1100
                                <br />
                                <span style="color: #000000;">Fax:</span>(440) 926-2882
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <div class="clear">
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
    </div>

    <script type="text/javascript" language="javascript">
        var i;
        for (i = 1; i <= 5; i++) {
            var t = "C" + i;
            var temp = document.getElementById(t);
            temp.removeAttribute("class");
        }
        var temp1 = document.getElementById("C3");
        temp1.setAttribute("class", "active");        
    </script>

    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent4').className = "a_mainmenuActive";
       
    </script>

</asp:Content>
