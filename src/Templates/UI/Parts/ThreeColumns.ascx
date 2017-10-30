<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThreeColumns.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Parts.ThreeColumns" %>
<%@ Import Namespace="StudioPlaza.Web.Templates.Details" %>
<div class="<%= StringEnum.GetStringValue(CurrentItem.FirstColumnGridSize) %> clearboth mh50"><n2:DroppableZone ID="dzf" ZoneName="ColumnLeft" runat="server" AllowExternalManipulation="true" /></div>
<div class="<%= StringEnum.GetStringValue(CurrentItem.SecondColumnGridSize) %> mh50"><n2:DroppableZone ID="dzs" ZoneName="ColumnCenter" runat="server" AllowExternalManipulation="true" /></div>
<div class="<%= StringEnum.GetStringValue(CurrentItem.ThirdColumnGridSize) %> mh50"><n2:DroppableZone ID="DroppableZone1" ZoneName="ColumnRight" runat="server" AllowExternalManipulation="true" /></div>