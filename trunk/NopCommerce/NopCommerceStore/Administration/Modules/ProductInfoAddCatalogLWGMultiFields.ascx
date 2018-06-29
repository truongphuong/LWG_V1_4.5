<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductInfoAddCatalogLWGMultiFields.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ProductInfoAddCatalogLWGMultiFieldsControl" %>
<asp:UpdatePanel ID="pnUpdatepn1" runat="server">
    <ContentTemplate>
        <%--<table>
            <tr>
                <td>
                    Title Type
                </td>
                <td>
                    <asp:DropDownList ID="drpTitleType" runat="server" DataTextField="Name" AutoPostBack="true"
                        DataValueField="Id" OnSelectedIndexChanged="drpTitleType_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Instrumental Title
                </td>
                <td>
                    <asp:DropDownList ID="drpInstrTitle" runat="server" DataValueField="Id" DataTextField="Name">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnAddInstrTitle" runat="server" Text="Add InstrTitle" OnClick="btnAddInstrTitle_Click" />
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="gvCatalogInstrTitle" runat="server" AutoGenerateColumns="False"
                Width="100%" OnRowDataBound="gvCatalogInstrTitle_RowDataBound" OnRowCommand="gvCatalogInstrTitle_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrProductName" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="InstrTitle" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrInstrTitleName" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TitleType" ItemStyle-Width="30%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrTitleTypeName" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<% $NopResources:Admin.CatalogComposer.Remove %>"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnRemove" runat="server" CommandName="REMOVE" Text="<% $NopResources:Admin.CatalogComposer.Remove %>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />--%>
        <table>
            <tr>
                <td>
                    Catalog Genre
                </td>
                <td>
                    <asp:DropDownList ID="drpCatalogGenre" runat="server" DataValueField="GerneId" DataTextField="Name">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnAddGenre" runat="server" Text="Add Genre" OnClick="btnAddGenre_Click" />
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="gvGenre" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowDataBound="gvGenre_RowDataBound" OnRowCommand="gvGenre_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrProductDisplay" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Genre" ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrGenreName" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<% $NopResources:Admin.CatalogComposer.Remove %>"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnRemove" runat="server" CommandName="REMOVE" Text="<% $NopResources:Admin.CatalogComposer.Remove %>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    Period
                </td>
                <td>
                    <asp:DropDownList ID="drpPeriod" runat="server" Width="600px" DataTextField="Name"
                        DataValueField="PeriodId">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnPeriodAdd" runat="server" Text="Add Period" OnClick="btnPeriodAdd_Click" />
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="grdPeriod" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowDataBound="grdPeriod_RowDataBound" OnRowCommand="grdPeriod_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrProductDisplay" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Period" ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrPeriodName" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<% $NopResources:Admin.CatalogComposer.Remove %>"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnRemove" runat="server" CommandName="REMOVE" Text="<% $NopResources:Admin.CatalogComposer.Remove %>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    ReprintSource
                </td>
                <td>
                    <asp:DropDownList ID="drpReprintSource" runat="server" Width="600" DataTextField="Name"
                        DataValueField="ReprintSourceId">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnReprintsource" runat="server" Text="Add ReprintSource" OnClick="btnReprintsource_Click" />
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="grdReprintsource" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowDataBound="grdReprintsource_RowDataBound" OnRowCommand="grdReprintsource_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrProductDisplay" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reprintsource" ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrReprintsource" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<% $NopResources:Admin.CatalogComposer.Remove %>"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnRemove" runat="server" CommandName="REMOVE" Text="<% $NopResources:Admin.CatalogComposer.Remove %>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <table>
            <tr>
                <td>
                    Series
                </td>
                <td>
                    <asp:DropDownList ID="drpSeries" runat="server" Width="600" DataTextField="Name"
                        DataValueField="SeriesId">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <asp:Button ID="btnSeries" runat="server" Text="Add Series" OnClick="btnSeries_Click" />
                </td>
            </tr>
        </table>
        <div>
            <asp:GridView ID="grdSeries" runat="server" AutoGenerateColumns="False" Width="100%"
                OnRowDataBound="grdSeries_RowDataBound" OnRowCommand="grdSeries_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Product Name" ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrProductDisplay" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Series" ItemStyle-Width="40%">
                        <ItemTemplate>
                            <asp:Literal ID="ltrSeriesName" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="<% $NopResources:Admin.CatalogComposer.Remove %>"
                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkbtnRemove" runat="server" CommandName="REMOVE" Text="<% $NopResources:Admin.CatalogComposer.Remove %>"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <br />
        <br />
    </ContentTemplate>
    <Triggers>
       <%-- <asp:PostBackTrigger ControlID="btnAddInstrTitle" />--%>
        <asp:PostBackTrigger ControlID="btnAddGenre"  />
        <asp:PostBackTrigger ControlID="btnPeriodAdd" />
        <asp:PostBackTrigger ControlID="btnReprintsource" />
        <asp:PostBackTrigger ControlID="btnSeries" />
    </Triggers>
</asp:UpdatePanel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <span>You need to save the product before you can add product extend for this product
        page. </span>
</asp:Panel>
