<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.EmployeeList" %>
<div class="employee-list container_12">
	<n2:ItemDataSource id="idsEmployees" runat="server" />
	<asp:Repeater runat="server" DataSourceID="idsEmployees">
		<ItemTemplate>
			<div class="grid_6 bm10<%# Container.ItemIndex % 2 == 0 ? " clearboth" : string.Empty %>">
				<figure class="grid_2 alpha">
					<n2:Display PropertyName="Image" CurrentItem="<%# CurrentDataItem %>" runat="server" />
				</figure>
				<article class="grid_4 omega">
					<n2:Display PropertyName="Title" CurrentItem="<%# CurrentDataItem %>" runat="server" />
					<n2:Display PropertyName="Text" CurrentItem="<%# CurrentDataItem %>" runat="server" />
				</article>
			</div>
		</ItemTemplate>
	</asp:Repeater>
	<div class="clearboth"></div>
</div>