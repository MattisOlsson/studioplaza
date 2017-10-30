<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Teaser.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.Teaser" %>
<article class="teaser part">
	<n2:Display ID="dt" runat="server" PropertyName="Title" />
	<figure class="<%= !CurrentItem.DisableShadowBox ? "shadow-box bm15" : "bm15" %>">
		<n2:EditableDisplay ID="di" runat="server" Visible="<%$ HasValue: TeaserImageUrl %>" PropertyName="TeaserImageUrl" />
	</figure>
	<n2:EditableDisplay ID="dtxt" runat="server" PropertyName="Text" />
	<asp:PlaceHolder Visible="<%$ HasValue: LinkText %>" runat="server">
		<a href="<%= CurrentItem.LinkUrl %>">
			<n2:EditableDisplay runat="server" PropertyName="LinkText" />
		</a>
	</asp:PlaceHolder>
</article>