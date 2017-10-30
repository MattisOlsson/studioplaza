<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsList.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.NewsList" %>
<nav class="list">
	<n2:EditableDisplay PropertyName="Title" runat="server" />
	<n2:ItemDataSource id="idsNews" runat="server" />
	<asp:Repeater runat="server" DataSourceID="idsNews">
		<HeaderTemplate>
			<ol>
		</HeaderTemplate>
		<ItemTemplate>
			<li>
				<a href='<%# Eval("Url") %>' title='<%# Eval("Published") + ", " + Eval("Introduction") %>'>
					<n2:Display PropertyName="Title" CurrentItem="<%# CurrentDataItem %>" runat="server" />
				</a>
				<asp:PlaceHolder Visible='<%# Eval("Introduction") != null %>' runat="server">
					<n2:Display PropertyName="Introduction" CurrentItem="<%# CurrentDataItem %>" runat="server">
						<HeaderTemplate><p></HeaderTemplate>
						<FooterTemplate></p></FooterTemplate>
					</n2:Display>
				</asp:PlaceHolder>
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ol>
		</FooterTemplate>
	</asp:Repeater>
</nav>