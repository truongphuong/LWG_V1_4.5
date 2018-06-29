<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Modules.HeaderControl"
    CodeBehind="Header.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="CurrencySelector" Src="~/Modules/CurrencySelector.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="LanguageSelector" Src="~/Modules/LanguageSelector.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="TaxDisplayTypeSelector" Src="~/Modules/TaxDisplayTypeSelector.ascx" %>
<div class="Header">
    <div style="float: left; padding-top: 30px;">
        <a href="../Default.aspx">
            <img src="../App_Themes/darkOrange/images/ludwig_logo.png" style="border: 0px;" /></a>
    </div>
    <div style="color: #FFFFFF; float:right; width: 270px; text-align: right; margin-top: 10px;">
        <div style="margin-bottom: 10px; font-weight: bold">
            <asp:LoginView ID="topLoginView" runat="server">
                <AnonymousTemplate>
                    <a href="<%=Page.ResolveUrl("~/register.aspx")%>">
                        <%=GetLocaleResourceString("Account.Register")%></a> | <a href="<%=Page.ResolveUrl("~/login.aspx")%>">
                            <%=GetLocaleResourceString("Account.Login")%></a>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <%=Page.User.Identity.Name %>
                    | <a href="<%=Page.ResolveUrl("~/logout.aspx")%>">
                        <%=GetLocaleResourceString("Account.Logout")%></a>
                    <% if (ForumManager.AllowPrivateMessages)
                       { %>
                    <a href="<%=Page.ResolveUrl("~/privatemessages.aspx")%>">
                        <%=GetLocaleResourceString("PrivateMessages.Inbox")%></a>
                    <asp:Literal runat="server" ID="lUnreadPrivateMessages" />
                    <%} %>
                </LoggedInTemplate>
            </asp:LoginView>
        </div>
        <div style="text-align: right">
            <div style=" font-size:13px; text-transform:uppercase;">
                <img src="../App_Themes/darkOrange/images/cart_icon.jpg" align="absmiddle" />
                <span style="font-weight: bold; font-size: 13px;"><a href="<%=Page.ResolveUrl("~/shoppingcart.aspx")%>"
                    class="ico-cart">
                    <%=GetLocaleResourceString("Account.ShoppingCart")%>
                </a></span>
            </div>
            <div style="padding-top: 5px;">
                Your cart has <span style="color: White; font-weight: bold;"><%--<a href="<%=Page.ResolveUrl("~/shoppingcart.aspx")%>">
                    <%=ShoppingCartManager.GetCurrentShoppingCart(ShoppingCartTypeEnum.ShoppingCart).Count%></a>--%>
                      <%=ShoppingCartManager.GetCurrentShoppingCart(ShoppingCartTypeEnum.ShoppingCart).Count%> items</span>
            </div>
            <div style="color: #FFFFFF; font-weight: bold; font-size: 24px; padding-top: 5px;">
                800-434-6340

            </div>
        </div>
    </div>
</div>
<%---------------old code--%>
<%--<div class="header">
    <div class="header-logo">
        <a href="<%=CommonHelper.GetStoreLocation()%>" class="logo">&nbsp; </a>
    </div>
    <div class="header-links-wrapper">
        <div class="header-links">
            <ul>
                <asp:LoginView ID="topLoginView" runat="server">
                    <AnonymousTemplate>
                        <li><a href="<%=Page.ResolveUrl("~/register.aspx")%>" class="ico-register">
                            <%=GetLocaleResourceString("Account.Register")%></a></li>
                        <li><a href="<%=Page.ResolveUrl("~/login.aspx")%>" class="ico-login">
                            <%=GetLocaleResourceString("Account.Login")%></a></li>
                    </AnonymousTemplate>
                    <LoggedInTemplate>
                        <li>
                            <%=Page.User.Identity.Name %>
                        </li>
                        <li><a href="<%=Page.ResolveUrl("~/logout.aspx")%>" class="ico-logout">
                            <%=GetLocaleResourceString("Account.Logout")%></a> </li>
                        <% if (ForumManager.AllowPrivateMessages)
                           { %>
                        <li><a href="<%=Page.ResolveUrl("~/privatemessages.aspx")%>" class="ico-inbox">
                            <%=GetLocaleResourceString("PrivateMessages.Inbox")%></a>
                            <asp:Literal runat="server" ID="lUnreadPrivateMessages" />
                        </li>
                        <%} %>
                    </LoggedInTemplate>
                </asp:LoginView>
                <li><a href="<%=Page.ResolveUrl("~/shoppingcart.aspx")%>" class="ico-cart">
                    <%=GetLocaleResourceString("Account.ShoppingCart")%>
                </a><a href="<%=Page.ResolveUrl("~/shoppingcart.aspx")%>">(<%=ShoppingCartManager.GetCurrentShoppingCart(ShoppingCartTypeEnum.ShoppingCart).Count%>)</a>
                </li>
                <% if (SettingManager.GetSettingValueBoolean("Common.EnableWishlist"))
                   { %>
                <li><a href="<%=Page.ResolveUrl("~/wishlist.aspx")%>" class="ico-wishlist">
                    <%=GetLocaleResourceString("Wishlist.Wishlist")%></a> <a href="<%=Page.ResolveUrl("~/wishlist.aspx")%>">
                        (<%=ShoppingCartManager.GetCurrentShoppingCart(ShoppingCartTypeEnum.Wishlist).Count%>)</a></li>
                <%} %>
                <% if (NopContext.Current.User != null && NopContext.Current.User.IsAdmin)
                   { %>
                <li><a href="<%=Page.ResolveUrl("~/administration/")%>" class="ico-admin">
                    <%=GetLocaleResourceString("Account.Administration")%></a> </li>
                <%} %>
            </ul>
        </div>
    </div>
    <div class="header-selectors-wrapper">
        <div class="header-taxDisplayTypeSelector">
            <nopCommerce:TaxDisplayTypeSelector runat="server" ID="ctrlTaxDisplayTypeSelector">
            </nopCommerce:TaxDisplayTypeSelector>
        </div>
        <div class="header-currencyselector">
            <nopCommerce:CurrencySelector runat="server" ID="ctrlCurrencySelector"></nopCommerce:CurrencySelector>
        </div>
        <div class="header-languageSelector">
            <nopCommerce:LanguageSelector runat="server" ID="ctrlLanguageSelector"></nopCommerce:LanguageSelector>
        </div>
    </div>
</div>--%>
