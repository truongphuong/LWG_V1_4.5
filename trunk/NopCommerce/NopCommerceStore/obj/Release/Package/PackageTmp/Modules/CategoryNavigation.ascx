<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.CategoryNavigation"
    CodeBehind="CategoryNavigation.ascx.cs" %>
<div>
    <div class="div_box_music_homepage1">
    </div>
    <div class="div_box_music_homepage2" style="width: 208px; text-align: left;">
        <span class="div_box_music_header" style="display: block; padding-left: 10px;">Browse
            <%=GetLocaleResourceString("Category.Categories")%></span>
    </div>
    <div class="div_box_music_homepage3">
    </div>
    <div class="clear">
    </div>
</div>
<div style="background-color: #ededed;">
    <div style="background-color: #ededed;">
        <div style="float: right; height: 800px; width: 1px">
        </div>
        <ul class="arrowlistmenu" style="margin: 0px; padding: 0px; list-style-type: none;">
            <asp:PlaceHolder runat="server" ID="phCategories" />
        </ul>
        <div class="clear">
        </div>
    </div>
</div>
<div>
    <div class="div_box_music_homepage5">
    </div>
    <div class="div_box_music_homepage6" style="width: 208px;">
    </div>
    <div class="div_box_music_homepage7">
    </div>
</div>
