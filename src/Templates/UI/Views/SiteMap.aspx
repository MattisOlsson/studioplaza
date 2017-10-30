<%@ Page Language="C#" MasterPageFile="../Layouts/StudioPlaza.master" AutoEventWireup="true" CodeBehind="SiteMap.aspx.cs" Inherits="StudioPlaza.Web.Templates.UI.Views.SiteMap" Title="Site map" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Content" runat="server">
	<div class="main-body grid_8">
		<n2:EditableDisplay ID="d1" PropertyName="Title" runat="server" />
		<n2:EditableDisplay ID="d2" PropertyName="Text" runat="server" />
		<n2:DroppableZone ZoneName="Left" runat="server" />
		<n2:Menu ID="m" runat="server" CssClass="sitemap" Path="~/" BranchMode="false" />
	</div>
	<n2:DroppableZone ZoneName="Right" runat="server">
		<HeaderTemplate><div class="grid_4"></HeaderTemplate>
		<FooterTemplate></div></FooterTemplate>
	</n2:DroppableZone>
</asp:Content>