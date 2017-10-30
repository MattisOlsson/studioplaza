<%@ Page Title="" Language="C#" MasterPageFile="../Layouts/StudioPlaza.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="StudioPlaza.Web.Templates.UI.Views.Start" %>
<asp:Content ContentPlaceHolderID="FullRegion" runat="server">
	<n2:DroppableZone ZoneName="Top" runat="server" />
    <div id="start-page" class="page container_12">
		<n2:DroppableZone ID="dzc" ZoneName="Content" runat="server" />
		<div class="clearboth"></div>
    </div>
</asp:Content>