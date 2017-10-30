<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MapTeaser.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.MapTeaser" %>
<article class="teaser part">
	<n2:EditableDisplay ID="dt" runat="server" PropertyName="Title" />
	<div class="shadow-box map bm15">
		<figure id="map_canvas" data-longitude="<%= CurrentItem.Longitude %>" data-latitude="<%= CurrentItem.Latitude %>"></figure>
	</div>
	<n2:EditableDisplay ID="dtxt" runat="server" PropertyName="Text" />
	<asp:PlaceHolder Visible="<%$ HasValue: LinkUrl %>" runat="server">
		<a href="<%= CurrentItem.LinkUrl %>"><n2:EditableDisplay runat="server" PropertyName="LinkText" /></a>
	</asp:PlaceHolder>
</article>