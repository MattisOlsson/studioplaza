using System;
using NewsContainer=StudioPlaza.Web.Templates.Items.NewsContainer;

namespace StudioPlaza.Web.Templates.UI.Views
{
    public partial class NewsContainer : Web.UI.TemplatePage<Templates.Items.NewsContainer>
    {
        protected N2.Web.UI.WebControls.ItemDataSource idsNews;

		protected Items.News CurrentNewsItem
		{
			get
			{
				return GetDataItem() as Items.News;
			}
		}

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            idsNews.Filtering += new EventHandler<N2.Collections.ItemListEventArgs>(idsNews_Filtering);
        }

        void idsNews_Filtering(object sender, N2.Collections.ItemListEventArgs e)
        {
            N2.Collections.TypeFilter.Filter(e.Items, typeof(StudioPlaza.Web.Templates.Items.News));
        }
    }
}