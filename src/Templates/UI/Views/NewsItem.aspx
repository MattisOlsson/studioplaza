<%@ Page Language="C#" MasterPageFile="../Layouts/StudioPlaza.master" AutoEventWireup="true" CodeBehind="NewsItem.aspx.cs" Inherits="StudioPlaza.Web.Templates.News.UI.NewsItem" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
	<article class="main-body grid_6">
		<n2:EditableDisplay ID="edt" PropertyName="Title" runat="server" />
		<p class="date"><%= CurrentItem.Published.Value.ToString("yyyy-MM-dd") %></p>
		<n2:EditableDisplay PropertyName="Text" runat="server" />
		<n2:DroppableZone ZoneName="Left" runat="server" />
	</article>
	<aside class="grid_6">
		<n2:EditableDisplay PropertyName="Image" Visible="<%$ HasValue: Image %>" runat="server">
			<HeaderTemplate>
				<figure class="grid_6 alpha omega shadow-box">
			</HeaderTemplate>
			<FooterTemplate>
				</figure>
			</FooterTemplate>
		</n2:EditableDisplay>
		<n2:DroppableZone ZoneName="Right" runat="server" />
	</aside>
</asp:Content>