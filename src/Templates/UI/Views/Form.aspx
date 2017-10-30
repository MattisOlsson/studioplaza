<%@ Page MasterPageFile="../Layouts/StudioPlaza.Master" Language="C#" AutoEventWireup="true" CodeBehind="Form.aspx.cs" Inherits="StudioPlaza.Web.Templates.UI.Views.Form" %>
<asp:Content ID="cpc" ContentPlaceHolderID="PostContent" runat="server">
	<n2:Display ID="df" runat="server" PropertyName="Form" />
</asp:Content>