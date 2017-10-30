<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Text.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.Text" %>
<article class="teaser part clearboth">
	<n2:EditableDisplay runat="server" PropertyName="Title" />
	<n2:EditableDisplay runat="server" id="t" PropertyName="Text" />
</article>