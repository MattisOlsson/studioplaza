using System;
using N2.Web.UI.WebControls;
using StudioPlaza.Web.Templates.Items;
using N2;

namespace StudioPlaza.Web.Templates.UI.Parts
{
    public partial class Carousel : Web.UI.TemplateUserControl<ContentItem, Items.Carousel>
    {
		protected CarouselItem CurrentDataItem
		{
			get
			{
				return Page.GetDataItem() as CarouselItem;
			}
		}

        protected override void OnInit(EventArgs e)
        {
            idsItems.CurrentItem = CurrentItem.Container;
            base.OnInit(e);
        }
    }
}