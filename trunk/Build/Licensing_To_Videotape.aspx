<%@ Page Language="C#" MasterPageFile="~/MasterPages/OneColumn.master" AutoEventWireup="true"
    CodeBehind="Licensing_To_Videotape.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Licensing_To_Videotape" %>

<%@ Register Src="Modules/Licensing.ascx" TagName="Licensing" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/License_Form.ascx" TagName="Form" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <div class="html-header">
        Home / Licensing / <span style="color: #0068a2;">To Videotape</span>
    </div>
    <div class="clear-15">
    </div>
    <div>
        <div style="float: left; width: 227px;">
            <uc1:Licensing ID="Licensing1" runat="server" />
        </div>
        <div style="width: 700px; float: left; margin-left: 10px; background-color: #FFFFFF;">
            <div style="width: 660px; float: left; padding-left: 40px;">
                <div class="html-title">
                    License to Videotape
                </div>
                <div style="padding-right: 50px; padding-top: 15px;">
                    <span style="color: #f37032; font-size: 14px; font-weight: bold;">Sample Text</span><br />
                    <br />
                    <span style="color: #58595b; line-height: 15px; text-align: justify;">With the January
                        2008 consolidation of Masters Music Publications and Ludwig Music Publishing, we
                        now offer music suitable for use at all stages of musical development. We are proud
                        to distribute products from the catalogues of Masters Music, Ludwig Music Publishing,
                        Great Works, Stone Publications, Brook Publications, E.C. Kerby, Barta Music, J.
                        Christopher. </span>
                </div>
                <div>
                    <div style="width: 497px; margin-left: 81px; margin-right: 82px; margin-top: 30px;">
                        <uc1:Form runat="server" ID="licenseForm" Type="VideoTape"></uc1:Form>
                    </div>
                </div>
                <div class="clear" style="height: 70px;">
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>

    <script type="text/javascript" language="javascript">
        var i;
        for (i = 1; i <= 6; i++) {
            var t = "L" + i;
            var temp = document.getElementById(t);
            temp.removeAttribute("class");
        }
        var temp1 = document.getElementById("L2");
        temp1.setAttribute("class", "active");        
    </script>
    
    <script type="text/javascript">

        document.getElementById('sample_attach_menu_parent2').className = "a_mainmenuActive";
       
    </script>

</asp:Content>
