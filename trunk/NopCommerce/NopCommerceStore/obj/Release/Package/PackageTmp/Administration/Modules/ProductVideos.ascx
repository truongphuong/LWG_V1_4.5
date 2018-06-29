<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ProductVideos"
    CodeBehind="ProductVideos.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="NumericTextBox" Src="NumericTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="SimpleTextBox" Src="SimpleTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<script type="text/javascript">
    function showUploadVideoPanels() {
        if ($('#uplVideo20').is(':hidden')) {
            $('#uplVideo20').show();
            $('#uplVideo21').show();
            $('#uplVideo22').show();
        }
        else if ($('#uplVideo30').is(':hidden')) {
            $('#uplVideo30').show();
            $('#uplVideo31').show();
            $('#uplVideo32').show();
        }
        else {
            $('#<%=btnMoreUploads.ClientID %>').attr("disabled", "disabled");
        }
    }
</script>
<asp:Panel runat="server" ID="pnlData">
    <asp:GridView ID="gvVideos" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvVideos_RowDeleting" DataKeyNames="VideoId"
        OnRowDataBound="gvVideos_RowDataBound" OnRowCommand="gvVideos_RowCommand" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductVideos.Video %>" ItemStyle-Width="50%">
                <ItemTemplate>
                    <asp:Label ID="lblQTFile" runat="server" Text='<%#Eval("QTFile") %>'></asp:Label>
                    <asp:HiddenField ID="hdVideoId" runat="server" Value='<%# Eval("VideoId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductVideos.DisplayOrder %>"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtProductVideoDisplayOrder"
                        Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="<% $NopResources:Admin.ProductVideos.DisplayOrder.RequiredErrorMessage %>"
                        RangeErrorMessage="<% $NopResources:Admin.ProductVideos.DisplayOrder.RangeErrorMessage %>"
                        ValidationGroup="ProductVideos" MinimumValue="-99999" MaximumValue="99999"></nopCommerce:NumericTextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductVideos.Update %>" HeaderStyle-HorizontalAlign="Center"
                ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="<% $NopResources:Admin.ProductVideos.Update %>"
                        ValidationGroup="ProductVideos" CommandName="UpdateProductVideo" ToolTip="<% $NopResources:Admin.ProductVideos.Update.Tooltip %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductVideos.Delete %>" HeaderStyle-HorizontalAlign="Center"
                ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnDeleteVideo" runat="server" CssClass="adminButton" Text="<% $NopResources:Admin.ProductVideos.Delete %>"
                        CausesValidation="false" CommandName="Delete" ToolTip="<% $NopResources:Admin.ProductVideos.Delete.Tooltip %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>
        <strong>
            <%=GetLocaleResourceString("Admin.ProductVideos.AddNewVideo")%>
        </strong>
    </p>
    <table class="adminContent">
        <tr>
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblSelectVideo1" Text="<% $NopResources:Admin.ProductVideos.SelectVideo %>"
                    ToolTip="<% $NopResources:Admin.ProductVideos.SelectVideo.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:FileUpload class="text" ID="fuProductVideo1" CssClass="adminInput" runat="server"
                    ToolTip="<% $NopResources:Admin.ProductVideos.FileUpload %>" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblProductDisplayOrder1" Text="<% $NopResources:Admin.ProductVideos.New.DisplayOrder %>"
                    ToolTip="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductVideoDisplayOrder1"
                    Value="1" RequiredErrorMessage="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.RequiredErrorMessage %>"
                    RangeErrorMessage="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.RangeErrorMessage %>"
                    MinimumValue="-99999" MaximumValue="99999" ValidationGroup="UploadNewProductVideo"></nopCommerce:NumericTextBox>
            </td>
        </tr>
        <tr id="uplVideo20" style="display: none;">
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr id="uplVideo21" style="display: none;">
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblSelectVideo2" Text="<% $NopResources:Admin.ProductVideos.SelectVideo %>"
                    ToolTip="<% $NopResources:Admin.ProductVideos.SelectVideo.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:FileUpload class="text" ID="fuProductVideo2" CssClass="adminInput" runat="server"
                    ToolTip="<% $NopResources:Admin.ProductVideos.FileUpload %>" />
            </td>
        </tr>
        <tr id="uplVideo22" style="display: none;">
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblProductDisplayOrder2" Text="<% $NopResources:Admin.ProductVideos.New.DisplayOrder %>"
                    ToolTip="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductVideoDisplayOrder2"
                    Value="1" RequiredErrorMessage="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.RequiredErrorMessage %>"
                    RangeErrorMessage="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.RangeErrorMessage %>"
                    MinimumValue="-99999" MaximumValue="99999" ValidationGroup="UploadNewProductVideo"></nopCommerce:NumericTextBox>
            </td>
        </tr>
        <tr id="uplVideo30" style="display: none;">
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr id="uplVideo31" style="display: none;">
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblSelectVideo3" Text="<% $NopResources:Admin.ProductVideos.SelectVideo %>"
                    ToolTip="<% $NopResources:Admin.ProductVideos.SelectVideo.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:FileUpload class="text" ID="fuProductVideo3" CssClass="adminInput" runat="server"
                    ToolTip="<% $NopResources:Admin.ProductVideos.FileUpload %>" />
            </td>
        </tr>
        <tr id="uplVideo32" style="display: none;">
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblProductDisplayOrder3" Text="<% $NopResources:Admin.ProductVideos.New.DisplayOrder %>"
                    ToolTip="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductVideoDisplayOrder3"
                    Value="1" RequiredErrorMessage="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.RequiredErrorMessage %>"
                    RangeErrorMessage="<% $NopResources:Admin.ProductVideos.New.DisplayOrder.RangeErrorMessage %>"
                    MinimumValue="-99999" MaximumValue="99999" ValidationGroup="UploadNewProductAudio"></nopCommerce:NumericTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:Button runat="server" ID="btnMoreUploads" CssClass="adminButton" Text="+"  />
                <asp:Button runat="server" ID="btnUploadProductVideo" CssClass="adminButton" Text="<% $NopResources:Admin.ProductVideos.UploadButton.Text %>"
                    ValidationGroup="UploadNewProductVideo" OnClick="btnUploadProductVideo_Click"
                    ToolTip="<% $NopResources:Admin.ProductVideos.UploadButton.Tooltip %>" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel runat="server" ID="pnlMessage">
    <%=GetLocaleResourceString("Admin.ProductVideos.AvailableAfterSaving")%>
</asp:Panel>
