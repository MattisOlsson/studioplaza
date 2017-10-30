<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShadowBox.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.ShadowBox" %>
<%@ Import Namespace="StudioPlaza.Web.Templates.Details" %>
<article class="shadow-box part <%= StringEnum.GetStringValue(CurrentItem.BoxCssClass) %>">
	<n2:EditableDisplay ID="dt" runat="server" PropertyName="Title" />
	<n2:EditableDisplay ID="dtxt" runat="server" PropertyName="Text" />
</article>