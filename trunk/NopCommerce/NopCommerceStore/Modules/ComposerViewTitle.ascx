<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComposerViewTitle.ascx.cs" Inherits="NopSolutions.NopCommerce.Web.Modules.ComposerViewTitle" %>

<%@ Register src="ProductViewTitle.ascx" tagname="ProductViewTitle" tagprefix="nopCommerce" %>
<style type="text/css">
        .viewtitlelist
        {
        	border-left:1px solid #c2c2c2;
        	border-right:1px solid #c2c2c2;
        	border-bottom:1px solid #c2c2c2;
        }
        .viewtitlelist tr
        {
    	    border-bottom:1px dotted green;
        }
</style>

<div>
<asp:DataList ID="dlViewTitle" RepeatColumns="1" runat="server" CssClass="viewtitlelist" >
<ItemTemplate>    
    <nopCommerce:ProductViewTitle ID="ProductViewTitle1" runat="server"  Product='<%# Container.DataItem %>' />    
</ItemTemplate>

</asp:DataList>
</div>


