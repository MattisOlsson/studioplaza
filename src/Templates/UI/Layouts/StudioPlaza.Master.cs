using System;
using N2.Engine.Globalization;
using StudioPlaza.Web.Templates.Items;
using N2;

namespace StudioPlaza.Web.Templates.UI.Layouts
{
    public partial class StudioPlaza : Web.UI.TemplateMasterPage<ContentItem>
    {
        protected string GetBodyClass()
        {
            if (CurrentPage != null)
            {
                string className = CurrentPage.GetContentType().Name;
				return "type" + className;
            }
            return null;
        }
    }
}