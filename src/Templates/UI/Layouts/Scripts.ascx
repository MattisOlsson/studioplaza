<%@ control language="C#" autoeventwireup="true" codebehind="Scripts.ascx.cs" inherits="StudioPlaza.Web.Templates.UI.Layouts.Scripts" %>
<% if (Context.IsDebuggingEnabled) { %>
<script src="/Templates/UI/Scripts/extensions.js"></script>
<script src="/Templates/UI/Scripts/jquery-1.7.2.min.js"></script>
<script src="/Templates/UI/Scripts/jquery.mousewheel-3.0.6.pack.js"></script>
<script src="/Templates/UI/Scripts/jquery.easing.1.3.js"></script>
<script src="/Templates/UI/Scripts/jquery.touchSwipe.js"></script>
<script src="/Templates/UI/Scripts/jquery.plusslider.js"></script>
<script src="/Templates/UI/Scripts/jquery.gallery-1.0.0.js"></script>
<script src="/fancybox/jquery.fancybox.pack.js"></script>
<script src="/fancybox/helpers/jquery.fancybox-buttons.js"></script>
<script src="/Templates/UI/Scripts/gui.js"></script>
<script src="/Templates/UI/Scripts/maps.js"></script>
<script src="//maps.googleapis.com/maps/api/js?key=AIzaSyDvt1PWx8328N4RZOUUubKFKiOEu_6i_aA&callback=mapInitialize"></script>
<% } else { %>
<script>
    (function (d, w) {
        function loadJs() {
            scr("/Templates/UI/Scripts/bundle-1.0.0.min.js");
        }

        function scr(src) {
            var el = d.createElement("script");
            el.src = src;
            d.body.appendChild(el);
        }

        //if (w.addEventListener) w.addEventListener("load", loadJs, false);
        //else if (w.attachEvent) w.attachEvent("onload", loadJs);
        //else w.onload = loadJs;
        loadJs();
    })(document, window);
</script>
<% } %>