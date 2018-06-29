<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductInfoAddCatalogLWG.ascx.cs"
    Inherits="NopSolutions.NopCommerce.Web.Administration.Modules.ProductInfoAddCatalogLWGControl" %>
<%@ Register TagPrefix="nopCommerce" TagName="ToolTipLabel" Src="ToolTipLabelControl.ascx" %>
<%@ Register Assembly="NopCommerceStore" Namespace="NopSolutions.NopCommerce.Web.Controls"
    TagPrefix="nopCommerce" %>
<asp:UpdatePanel ID="updatepnCatalog" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnEditCatalog" runat="server">
            <table>
                <tr>
                    <td style="vertical-align: top">
                        Blurb
                    </td>
                    <td>
                        <asp:Literal ID="ltBlurb" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        CatalogNumber*
                    </td>
                    <td>
                        <asp:TextBox ID="txtCatalogNumber" runat="server" Width="600px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="required1" runat="server" Display="Dynamic" ValidationGroup="AddEdit"
                            ControlToValidate="txtCatalogNumber" ErrorMessage="*"></asp:RequiredFieldValidator>                        
                    </td>
                </tr>
                <tr>
                    <td class="adminTitle">
                        <nopCommerce:ToolTipLabel runat="server" ID="lblTableofContents" Text="<% $NopResources:Admin.ProductInfo.TableofContents %>"
                            ToolTip="<% $NopResources: Admin.ProductInfo.TableofContents.Tooltip%>" ToolTipImage="~/Administration/Common/ico-help.gif" />
                    </td>
                    <td class="adminData">
                        <nopCommerce:NopHTMLEditor ID="txtTableofContents" runat="server" Height="350" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Duration
                    </td>
                    <td>
                        <asp:TextBox ID="txtDuration" runat="server" Width="600px" MaxLength="1900"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top">
                        Format
                    </td>
                    <td>
                        <asp:GridView ID="gvProductVariants" runat="server" AutoGenerateColumns="false" Width="605px">
                            <Columns>
                                <asp:TemplateField HeaderText="Product Variant Name">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="lblVariantName" Text='<%#Server.HtmlEncode(GetProductVariantName(Container.DataItem as ProductVariant))%>'
                                                runat="server"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <div>
                                            <asp:Label ID="lblVariantPrice" Text='<%#DataBinder.Eval(Container.DataItem, "Price", "{0:c}") %>'
                                                runat="server"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        FSCprodcode
                    </td>
                    <td>
                        <asp:Label ID="lblFScprodcode" runat="server" Text=""></asp:Label>                        
                    </td>
                </tr>
                <tr>
                    <td>
                        Grade
                    </td>
                    <td>
                        <asp:TextBox ID="txtGrade" runat="server" Width="600" MaxLength="49"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Instrumental
                    </td>
                    <td>
                        <asp:DropDownList ID="drpInstrumental" runat="server" Width="600px" DataTextField="ShortName"
                            DataValueField="InstrumentalId">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        InstrDetail
                    </td>
                    <td>
                        <asp:TextBox ID="txtInstrDetail" runat="server" Width="600px" MaxLength="1900"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Catalog Instrumental Search
                    </td>
                    <td>
                        <asp:TextBox ID="txtCatalogInstrSearch" runat="server" Width="600px" MaxLength="1900"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Kalmus #
                    </td>
                    <td>
                        <asp:TextBox ID="txtKaldbNumber" runat="server" Width="600px" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Catalog Name Search
                    </td>
                    <td>
                        <asp:TextBox ID="txtCatalogNameSearch" runat="server" Width="600px" MaxLength="1990"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        Catalog Publisher
                    </td>
                    <td>
                        <asp:DropDownList ID="drpCatalogPublisher" runat="server" Width="600px" DataValueField="PublisherId"
                            DataTextField="Name">
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td>
                        SubTitle
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubTitle" runat="server" Width="600"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        TextLang
                    </td>
                    <td>
                        <asp:TextBox ID="txtTextLang" runat="server" Width="600"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        VocAccomp
                    </td>
                    <td>
                        <asp:CheckBox ID="chkVocAccomp" runat="server" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Year
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtYear" runat="server" MaxLength="100" Width="200"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        Copyright Year
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtCopyrightYear" runat="server" MaxLength="100" Width="200"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        PDF
                    </td>
                    <td>
                        <div style="float: left">
                            <asp:FileUpload ID="uploadPDF" runat="server" />
                            <asp:Literal ID="ltrPDFFile" runat="server"></asp:Literal>
                        </div>
                        <div style="float: left; padding-left: 20px">
                            <asp:Button ID="btnDeletePDFFile" CssClass="adminButton" Visible="false" runat="server" Text="Delete PDF file"
                                OnClick="btnDeletePDFFile_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        Pages
                    </td>
                    <td>
                        <asp:TextBox ID="txtPages" runat="server" Width="600"></asp:TextBox>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" ValidationGroup="AddEdit" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <br />
                        <asp:Label ID="lblNote" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Panel runat="server" ID="pnlMessage" Visible="false">
    <span>You need to save the product before you can add product extend for this product
        page. </span>
</asp:Panel>
