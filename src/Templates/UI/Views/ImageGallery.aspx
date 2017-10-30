<%@ Page Language="C#" MasterPageFile="../Layouts/StudioPlaza.master" AutoEventWireup="true" CodeBehind="ImageGallery.aspx.cs" Inherits="StudioPlaza.Web.Templates.UI.Views.ImageGallery" %>
<asp:Content ID="c" ContentPlaceHolderID="Content" runat="server">
	<n2:DroppableZone ID="dzt" ZoneName="Top" runat="server">
		<HeaderTemplate><div class="grid_12 dzt"></HeaderTemplate>
		<FooterTemplate></div></FooterTemplate>
	</n2:DroppableZone>

	<article class="main-body grid_8">
		<n2:EditableDisplay PropertyName="Title" runat="server" />
		<n2:EditableDisplay PropertyName="Text" runat="server" />
		<n2:DroppableZone ID="dzl" ZoneName="Left" runat="server" />
	</article>
	<div class="grid_12 gallery clearfix alpha omega clearboth" data-thumb-width="<%= CurrentItem.MaxThumbnailWidth %>" data-thumb-height="<%= CurrentItem.MaxThumbnailHeight %>" data-start-index="<%= CurrentItem.StartIndex %>">
		<asp:Repeater ID="rptImages" runat="server">
			<ItemTemplate>
				<a href="<%# CurrentDataItem.GetImageUrl() %>" class="fancy" rel="gallery" style="height: <%# CurrentItem.MaxThumbnailHeight %>px">
					<img alt="<%# CurrentDataItem.Title %>" src="<%# CurrentDataItem.ThumbnailImageUrl %>" />
				</a>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</asp:Content>