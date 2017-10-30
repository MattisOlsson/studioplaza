<%@ Page Language="C#" MasterPageFile="../Layouts/StudioPlaza.master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="StudioPlaza.Web.Templates.UI.Views.NewsContainer" Title="" %>
<asp:Content ContentPlaceHolderID="Content" runat="server">
	<div class="main-body grid_8 clearboth">
		<n2:EditableDisplay PropertyName="Title" runat="server" />
		<n2:EditableDisplay PropertyName="Text" runat="server" />
		<n2:ItemDataSource id="idsNews" runat="server" />
		<asp:Repeater runat="server" DataSourceID="idsNews">
			<HeaderTemplate>
				<nav class="list">
					<ol>
			</HeaderTemplate>
			<ItemTemplate>
				<li class="item i<%# Container.ItemIndex %> a<%# Container.ItemIndex % 2 %>">
					<span class="date"><%# Eval("Published") %></span>
					<a href='<%# Eval("Url") %>' rel="external"><%# Eval("Title") %></a>
					<p><%# Eval("Introduction") %></p>
				</li>
			</ItemTemplate>
			<FooterTemplate>
					</ol>
				</nav>
			</FooterTemplate>
		</asp:Repeater>
	</div>
	<aside class="grid_4">
		<n2:DroppableZone ID="dzr" ZoneName="Right" runat="server" />
	</aside>
</asp:Content>
