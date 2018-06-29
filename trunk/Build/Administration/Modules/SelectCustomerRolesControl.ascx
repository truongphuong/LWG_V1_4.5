<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.SelectCustomerRolesControl"
    CodeBehind="SelectCustomerRolesControl.ascx.cs" %>
<script type="text/javascript">
    function getID() {
        var divDealer = $("#<%=txtDealerID.ClientID%>")
        return divDealer.val();
    }
</script>
<div>
    <div class="customerRole" style="float: left">
        <asp:CheckBoxList runat="server" ID="cblCustomerRoles">
        </asp:CheckBoxList>
    </div>
    <div style="padding-top: 21px" id="divDealer" runat="server">
        <asp:Label Text="Dealer #:" runat="server" ID="lblDealerID"></asp:Label><asp:TextBox
            ID="txtDealerID" runat="server"></asp:TextBox>
        <a href="" target="_blank" onclick="return gotoDetails(this);">view details</a>
    </div>
</div>
<script type="text/javascript">

    function gotoDetails(el) {
        $(el).attr('href', 'dealerdetails.aspx?dealerid=' + getID());
        return true;
    }
    $(window).bind('load', function () {
        var cbDealer = $(".dealerClick input");
        var divDealer = $get("<%=divDealer.ClientID%>")
        cbDealer.bind("click", function () {
            if ((this).checked)
                $(divDealer).show();
            else
                $(divDealer).hide();
        });
        if ((cbDealer).is(":checked"))
            $(divDealer).show();
        else
            $(divDealer).hide();
    });
    
</script>
