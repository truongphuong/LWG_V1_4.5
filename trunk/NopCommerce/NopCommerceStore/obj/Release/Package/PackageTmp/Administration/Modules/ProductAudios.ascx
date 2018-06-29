<%@ Control Language="C#" AutoEventWireup="true" Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ProductAudios"
    CodeBehind="ProductAudios.ascx.cs" %>
<%@ Register TagPrefix="nopCommerce" TagName="NumericTextBox" Src="NumericTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="SimpleTextBox" Src="SimpleTextBox.ascx" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<script type="text/javascript">
    function showUploadAudioPanels() {
        if ($('#uplAudio20').is(':hidden')) {
            $('#uplAudio20').show();
            $('#uplAudio21').show();
            $('#uplAudio22').show();
        }
        else if ($('#uplAudio30').is(':hidden')) {
            $('#uplAudio30').show();
            $('#uplAudio31').show();
            $('#uplAudio32').show();
        }
        else {
            $('#<%=btnMoreUploads.ClientID %>').attr("disabled", "disabled");
        }
    }
</script>
<asp:Panel runat="server" ID="pnlData">
    <asp:GridView ID="gvAudios" runat="server" AutoGenerateColumns="false" OnRowDeleting="gvAudios_RowDeleting"
        DataKeyNames="AudioId" OnRowDataBound="gvAudios_RowDataBound" OnRowCommand="gvAudios_RowCommand"
        Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductAudios.Audio %>" ItemStyle-Width="50%">
                <ItemTemplate>
                    <asp:Label ID="lblSoundFile" runat="server" Text='<%#Eval("SoundFile") %>'></asp:Label>
                    <asp:HiddenField ID="hdAudioId" runat="server" Value='<%# Eval("AudioId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductAudios.DisplayOrder %>"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" Width="50px" ID="txtProductAudioDisplayOrder"
                        Value='<%# Eval("DisplayOrder") %>' RequiredErrorMessage="<% $NopResources:Admin.ProductAudios.DisplayOrder.RequiredErrorMessage %>"
                        RangeErrorMessage="<% $NopResources:Admin.ProductAudios.DisplayOrder.RangeErrorMessage %>"
                        ValidationGroup="ProductAudios" MinimumValue="-99999" MaximumValue="99999"></nopCommerce:NumericTextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductAudios.Update %>" HeaderStyle-HorizontalAlign="Center"
                ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnUpdate" runat="server" CssClass="adminButton" Text="<% $NopResources:Admin.ProductAudios.Update %>"
                        ValidationGroup="ProductAudios" CommandName="UpdateProductAudio" ToolTip="<% $NopResources:Admin.ProductAudios.Update.Tooltip %>" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="<% $NopResources:Admin.ProductAudios.Delete %>" HeaderStyle-HorizontalAlign="Center"
                ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnDeleteAudio" runat="server" CssClass="adminButton" Text="<% $NopResources:Admin.ProductAudios.Delete %>"
                        CausesValidation="false" CommandName="Delete" ToolTip="<% $NopResources:Admin.ProductAudios.Delete.Tooltip %>" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <p>
        <strong>
            <%=GetLocaleResourceString("Admin.ProductAudios.AddNewAudio")%>
        </strong>
    </p>
    <table class="adminContent">
        <tr>
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblSelectAudio1" Text="<% $NopResources:Admin.ProductAudios.SelectAudio %>"
                    ToolTip="<% $NopResources:Admin.ProductAudios.SelectAudio.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:FileUpload class="text" ID="fuProductAudio1" CssClass="adminInput" runat="server"
                    ToolTip="<% $NopResources:Admin.ProductAudios.FileUpload %>" />
            </td>
        </tr>
        <tr>
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblProductDisplayOrder1" Text="<% $NopResources:Admin.ProductAudios.New.DisplayOrder %>"
                    ToolTip="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductAudioDisplayOrder1"
                    Value="1" RequiredErrorMessage="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.RequiredErrorMessage %>"
                    RangeErrorMessage="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.RangeErrorMessage %>"
                    MinimumValue="-99999" MaximumValue="99999" ValidationGroup="UploadNewProductPicture">
                </nopCommerce:NumericTextBox>
            </td>
        </tr>
        <tr id="uplAudio20" style="display: none;">
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr id="uplAudio21" style="display: none;">
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblSelectAudio2" Text="<% $NopResources:Admin.ProductAudios.SelectAudio %>"
                    ToolTip="<% $NopResources:Admin.ProductAudios.SelectAudio.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:FileUpload class="text" ID="fuProductAudio2" CssClass="adminInput" runat="server"
                    ToolTip="<% $NopResources:Admin.ProductAudios.FileUpload %>" />
            </td>
        </tr>
        <tr id="uplAudio22" style="display: none;">
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblProductDisplayOrder2" Text="<% $NopResources:Admin.ProductAudios.New.DisplayOrder %>"
                    ToolTip="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductAudioDisplayOrder2"
                    Value="1" RequiredErrorMessage="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.RequiredErrorMessage %>"
                    RangeErrorMessage="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.RangeErrorMessage %>"
                    MinimumValue="-99999" MaximumValue="99999" ValidationGroup="UploadNewProductPicture">
                </nopCommerce:NumericTextBox>
            </td>
        </tr>
        <tr id="uplAudio30" style="display: none;">
            <td colspan="2">
                <br />
            </td>
        </tr>
        <tr id="uplAudio31" style="display: none;">
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblSelectAudio3" Text="<% $NopResources:Admin.ProductAudios.SelectAudio %>"
                    ToolTip="<% $NopResources:Admin.ProductAudios.SelectAudio.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <asp:FileUpload class="text" ID="fuProductAudio3" CssClass="adminInput" runat="server"
                    ToolTip="<% $NopResources:Admin.ProductAudios.FileUpload %>" />
            </td>
        </tr>
        <tr id="uplAudio32" style="display: none;">
            <td class="adminTitle">
                <nopCommerce:ToolTipLabel runat="server" ID="lblProductDisplayOrder3" Text="<% $NopResources:Admin.ProductAudios.New.DisplayOrder %>"
                    ToolTip="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.Tooltip %>" ToolTipImage="~/Administration/Common/ico-help.gif" />
            </td>
            <td class="adminData">
                <nopCommerce:NumericTextBox runat="server" CssClass="adminInput" ID="txtProductAudioDisplayOrder3"
                    Value="1" RequiredErrorMessage="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.RequiredErrorMessage %>"
                    RangeErrorMessage="<% $NopResources:Admin.ProductAudios.New.DisplayOrder.RangeErrorMessage %>"
                    MinimumValue="-99999" MaximumValue="99999" ValidationGroup="UploadNewProductAudio">
                </nopCommerce:NumericTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <asp:Button runat="server" ID="btnMoreUploads" CssClass="adminButton" Text="+" />
                <asp:Button runat="server" ID="btnUploadProductPicture" CssClass="adminButton" Text="<% $NopResources:Admin.ProductAudios.UploadButton.Text %>"
                    ValidationGroup="UploadNewProductAudio" OnClick="btnUploadProductAudio_Click"
                    ToolTip="<% $NopResources:Admin.ProductAudios.UploadButton.Tooltip %>" />
            </td>
        </tr>
    </table>
</asp:Panel>
<!-- <div>
    <table>
        <tr>
            <td style="vertical-align: bottom">
                SoundIcon:
            </td>
            <td style="vertical-align: bottom; padding-left: 20px">
                <asp:FileUpload ID="uploadSoundIcon" runat="server" />
            </td>
            <td>
                <asp:Image ID="imgSoundIcon" runat="server" Visible="false" />
            </td>
            <td style="vertical-align: bottom; padding-left: 20px">
                <asp:Button ID="updateSoundIcon" CssClass="adminButton" runat="server" Text="Update Sound Icon"
                    OnClick="updateSoundIcon_Click" />
            </td>
        </tr>
    </table>
</div> -->
<asp:Panel runat="server" ID="pnlMessage">
    <%=GetLocaleResourceString("Admin.ProductAudios.AvailableAfterSaving")%>
</asp:Panel>
