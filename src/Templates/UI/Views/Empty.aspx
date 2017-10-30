<%@ Page Language="C#" MasterPageFile="../Layouts/StudioPlaza.master" AutoEventWireup="true" CodeBehind="Empty.aspx.cs" Inherits="StudioPlaza.Web.Templates.UI.Views.Empty" Title="Untitled Page" %>
<asp:Content ID="c1" ContentPlaceHolderID="Content" runat="server">
    <div class="page full-width-banner">
		<div id="main-banner" class="container_12">
			<article class="main-body grid_6">
				<n2:EditableDisplay PropertyName="Title" runat="server" />
				<p>Denna sidtyp har inget visaläge.</p>
			</article>
		</div>
    </div>
</asp:Content>