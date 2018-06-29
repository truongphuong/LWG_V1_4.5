<%@ Page Language="C#" MasterPageFile="~/Administration/main.master" AutoEventWireup="true" CodeBehind="ProductRequireFiles.aspx.cs" Inherits="NopSolutions.NopCommerce.Web.Administration.ProductRequireFiles" Title="Product Require Files" %>

<%@ Register Src="~/Administration/Modules/ProductRequireInstrumentalLWG.ascx" TagName="ProductRequireInstrumentalLWG" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/ProductRequirePeriodLWG.ascx" TagName="ProductRequirePeriodLWG" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/ProductRequireReprintSourceLWG.ascx" TagName="ProductRequireReprintSourceLWG" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/ProductRequireSeriesLWG.ascx" TagName="ProductRequireSeriesLWG" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/ProductRequireGenreLWG.ascx" TagName="ProductRequireGenreLWG" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/ProductRequirePublisherLWG.ascx" TagName="ProductRequirePublisherLWG" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/ProductRequireTitleType.ascx" TagName="ProductRequireTitleType" TagPrefix="ctl" %>
<%@ Register Src="~/Administration/Modules/ProductRequireInstrTitle.ascx" TagName="ProductRequireInstrTitle" TagPrefix="ctl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="server">
    <span>
        Product Require files
    </span>                  <br />
<ajaxToolkit:TabContainer runat="server" ID="ProductRequireTabs" ActiveTabIndex="0">   
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductInstrumental" HeaderText="Instrumental">
        <ContentTemplate>            
            <ctl:ProductRequireInstrumentalLWG ID="ctlProductRequireInstrumentalLWG" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductPeriod" HeaderText="Period">
        <ContentTemplate>
            <ctl:ProductRequirePeriodLWG ID="ctlProductRequirePeriodLWG" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductReprintSource" HeaderText="ReprintSource">
        <ContentTemplate>
            <ctl:ProductRequireReprintSourceLWG ID="ctlProductRequireReprintSourceLWG" runat="server" />    
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductSeries" HeaderText="Series">
        <ContentTemplate>
            <ctl:ProductRequireSeriesLWG ID="ctlProductRequireSeriesLWG" runat="server" />
        </ContentTemplate>
    </ajaxToolkit:TabPanel> 
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductGenre" HeaderText="Genre">
        <ContentTemplate>
            <ctl:ProductRequireGenreLWG ID="ctlProductRequireGenreLWG" runat="server" />    
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductPublisher" HeaderText="Publisher">
        <ContentTemplate>
            <ctl:ProductRequirePublisherLWG ID="ctlProductRequirePublisherLWG" runat="server" />    
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
    <ajaxToolkit:TabPanel runat="server" ID="pnlProductTitleType" HeaderText="TitleType">
        <ContentTemplate>
            <ctl:ProductRequireTitleType ID="ctlProductRequireTitleType" runat="server" />       
        </ContentTemplate>
    </ajaxToolkit:TabPanel>  
    <ajaxToolkit:TabPanel runat="server" ID="pnProductInstrumentalTitle" HeaderText="InstrumentalTitle">
        <ContentTemplate>
            <ctl:ProductRequireInstrTitle ID="ctlProductRequireInstrTitle" runat="server" />    
        </ContentTemplate>
    </ajaxToolkit:TabPanel>
</ajaxToolkit:TabContainer>
</asp:Content>
