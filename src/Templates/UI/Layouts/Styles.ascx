<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Styles.ascx.cs" Inherits="StudioPlaza.Web.Templates.UI.Layouts.Styles" %>
<% if (Context.IsDebuggingEnabled) { %>
<link rel="stylesheet" type="text/css" href="/Templates/UI/Css/reset.css">
<link rel="stylesheet" type="text/css" href="/Templates/UI/Css/960_12_10_10.css">
<link rel="stylesheet" type="text/css" href="/Templates/UI/Css/studioplaza.css">
<link rel="stylesheet" type="text/css" href="/fancybox/jquery.fancybox.css">
<link rel="stylesheet" type="text/css" href="/fancybox/helpers/jquery.fancybox-buttons.css">
<% } else { %>
<link rel="stylesheet" type="text/css" href="/Templates/UI/Css/bundle-1.0.0.min.css">
<% } %>