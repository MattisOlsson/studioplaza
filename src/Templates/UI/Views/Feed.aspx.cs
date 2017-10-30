using System;
using StudioPlaza.Web.Templates.Items;
using StudioPlaza.Web.Templates.Services;
using N2.Web;
using N2.Web.UI;
using N2;

namespace StudioPlaza.Web.Templates.UI.Views
{
    public partial class Feed : ContentPage<RssFeed>
    {
		protected override void ApplyConcerns(ContentItem item)
		{
			// don't apply master page, etc.
		}

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			if (Request["hungry"] == "yes")
			{
				Response.ContentType = "text/xml";
				Engine.Resolve<RssWriter>().Write(Response.Output, CurrentItem);
			}
			else
				base.Render(writer);
		}
    }
}