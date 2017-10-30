<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carousel.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.Carousel" %>
<n2:ItemDataSource id="idsItems" runat="server" />
<asp:Repeater runat="server" DataSourceID="idsItems">
	<HeaderTemplate>
		<div class="full-width-cycle">
        	<div id="plus-slider" class="cycle">
	</HeaderTemplate>
	<ItemTemplate>
		<a class="banner<%# string.IsNullOrEmpty(CurrentDataItem.Title + CurrentDataItem.Text) ? " no-text" : string.Empty %>" href="<%# CurrentDataItem.LinkUrl %>">
			<asp:PlaceHolder Visible='<%# !string.IsNullOrEmpty(CurrentDataItem.Title + CurrentDataItem.Text) %>' runat="server">
				<article>
					<n2:Display PropertyName="Title" CurrentItem="<%# CurrentDataItem %>" runat="server" />
					<n2:Display PropertyName="Text" CurrentItem="<%# CurrentDataItem %>" runat="server" />
				</article>
			</asp:PlaceHolder>
			<figure>
				<CGI:TransformedImage ImageHandlerUrl="~/Img.ashx" ImageUrl='<%# CurrentDataItem.GetImageUrl() %>' Height="335" Width='<%# !string.IsNullOrEmpty(CurrentDataItem.Title + CurrentDataItem.Text) ? 490 : 980 %>' ResizeMode="Crop" runat="server" />
			</figure>
		</a>
	</ItemTemplate>
	<FooterTemplate>
			</div>
		</div>
	</FooterTemplate>
</asp:Repeater>