<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RssAggregator.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.RssAggregator" %>
<nav class="list">
	<n2:EditableDisplay PropertyName="Title" runat="server" />
    <n2:EditableDisplay PropertyName="Text" runat="server" />
    <asp:Repeater ID="rptRss" runat="server">
        <HeaderTemplate>
			<ol>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="item news i<%# Container.ItemIndex %> a<%# Container.ItemIndex % 2 %>">
                <a href='<%# Eval("Url") %>' title='<%# Eval("Published") %>' rel="external"><%# Eval("Title") %></a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
			</ol>
        </FooterTemplate>
    </asp:Repeater>
</nav>