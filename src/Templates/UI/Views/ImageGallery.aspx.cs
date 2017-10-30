using System;
using N2.Collections;
using StudioPlaza.Web.Templates.Items;

namespace StudioPlaza.Web.Templates.UI.Views
{
    public partial class ImageGallery : Web.UI.TemplatePage<Templates.Items.ImageGallery>
    {
		protected GalleryItem CurrentDataItem
		{
			get
			{
				return Page.GetDataItem() as GalleryItem;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			rptImages.DataSource = CurrentPage.GetChildren(new AccessFilter(), new TypeFilter(typeof (GalleryItem)));
			rptImages.DataBind();
		}
    }
}