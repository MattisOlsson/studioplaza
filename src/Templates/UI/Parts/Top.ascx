<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.Top" %>
<a id="logo" href="<%= CurrentItem.LogoLinkUrl %>"><n2:EditableDisplay PropertyName="LogoUrl" runat="server" /></a>
<a id="facebook" href="<%= CurrentItem.FacebookLinkUrl %>"><n2:EditableDisplay PropertyName="FacebookLinkText" runat="server" /></a>