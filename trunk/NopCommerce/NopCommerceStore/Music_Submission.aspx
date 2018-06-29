<%@ Page Language="C#" MasterPageFile="~/MasterPages/TwoColumn.master" AutoEventWireup="true"
    CodeBehind="Music_Submission.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Music_Submission" %>

<%@ Register Src="Modules/Contact_Us.ascx" TagName="Contact_Us" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
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
                <div class="html-header">
                    Home / Contact / <span style="color: #0068a2;">Music Submission</span>
                </div>
                <div class="html-title">
                    Instructions for Submitting Music
                </div>
                <div>
                    <!--Record-->
                    <div style="padding-bottom: 10px; padding-top: 10px; font-size: 12px; font-weight: bold;
                        color: #58595b; float: left;">
                        <img src="App_Themes/darkOrange/images/music_submission.jpg" style="float: right;" /><span
                            style="color: #f37032">LudwigMasters</span> will only accept music submissions
                        by mail. Please send a packet to LudwigMasters within the listed guidelines.<br />
                        <br />
                        <span style="color: Red; font-size: 16px;">NOTE:</span> email submissions will not
                        be accepted.<br />
                        <br />
                        <br />
                        <span style="color: #0068a2">Submission Guidelines:</span><br />
                        * Cover Letter /Contact Information
                        <br />
                        * Resume
                        <br />
                        * Clean Score
                        <br />
                        * Audio Recording<br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <span style="color: #f37032">LudwigMasters - Development Office</span><br />
                        1080 Cleveland Street<br />
                        Grafton, OH 44044
                    </div>
                    <!--End Record-->
                    <div class="clear_50" style="height: 328px;">
                    </div>
                </div>
                <div class="clear">
                </div>
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
        var temp1 = document.getElementById("C5");
        temp1.setAttribute("class", "active");        
    </script>

    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent4').className = "a_mainmenuActive";
       
    </script>

</asp:Content>
