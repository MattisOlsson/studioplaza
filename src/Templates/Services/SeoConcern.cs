using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using StudioPlaza.Web.Templates.Web.UI;
using N2.Engine;
using N2.Web.UI;
using N2;

namespace StudioPlaza.Web.Templates.Services
{
    /// <summary>
    /// Adds SEO title, keywords and description to the page.
    /// </summary>
	[Service(typeof(ContentPageConcern))]
	public class SeoConcern : ContentPageConcern
    {
        public const string HeadTitle = "HeadTitle";
        public const string MetaKeywords = "MetaKeywords";
        public const string MetaDescription = "MetaDescription";

		public override void OnPreInit(Page page, ContentItem item)
		{
			if (item == null) return;

			page.PreRender += delegate
			{
				string title = item[HeadTitle] as string;
				page.Title = !string.IsNullOrEmpty(title) ? title : item.Title;
				AddMeta(page, "keywords", item[MetaKeywords] as string);
				AddMeta(page, "description", item[MetaDescription] as string);
			};
		}

        private void AddMeta(Page page, string name, string content)
        {
			if (!string.IsNullOrEmpty(content))
            {
				string id = "meta" + name;
				if (page.Header.FindControl(id) != null)
					return;

                HtmlGenericControl meta = new HtmlGenericControl("meta");
				meta.ID = id;
                meta.Attributes["name"] = name;
                meta.Attributes["content"] = content;
                page.Header.Controls.Add(meta);
            }
        }
	}
}