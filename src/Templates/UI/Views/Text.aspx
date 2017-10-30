<%@ Page Language="C#" MasterPageFile="../Layouts/StudioPlaza.master" AutoEventWireup="true" CodeBehind="Text.aspx.cs" Inherits="StudioPlaza.Web.Templates.UI.Views.Text" Title="Untitled Page" %>
<%@ Import Namespace="StudioPlaza.Web.Templates.Details" %>
<asp:Content ID="c1" ContentPlaceHolderID="Content" runat="server">
	<n2:DroppableZone ID="dzt" ZoneName="Top" runat="server">
		<HeaderTemplate><div class="grid_12 dzt"></HeaderTemplate>
		<FooterTemplate></div></FooterTemplate>
	</n2:DroppableZone>
	<article class="main-body <%= StringEnum.GetStringValue(CurrentItem.LeftColumnGridSize) %> bm20">
		<n2:EditableDisplay PropertyName="Title" runat="server" />
		<n2:EditableDisplay PropertyName="Text" runat="server" />
		<n2:DroppableZone ID="dzl" ZoneName="Left" runat="server" />
	</article>
	<asp:PlaceHolder ID="PhRight" runat="server">
		<aside class="<%= StringEnum.GetStringValue(CurrentItem.RightColumnGridSize) %> bm20">
			<n2:EditableDisplay PropertyName="Image" Visible="<%$ HasValue: Image %>" runat="server">
				<HeaderTemplate>
					<figure class="shadow-box">
				</HeaderTemplate>
				<FooterTemplate>
					</figure>
				</FooterTemplate>
			</n2:EditableDisplay>
			<n2:DroppableZone ID="dzr" ZoneName="Right" runat="server" />
		</aside>
	</asp:PlaceHolder>
</asp:Content>