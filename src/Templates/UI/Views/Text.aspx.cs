using StudioPlaza.Web.Templates.Details;
using TextPage = StudioPlaza.Web.Templates.Items.TextPage;

namespace StudioPlaza.Web.Templates.UI.Views
{
    public partial class Text : Web.UI.TemplatePage<TextPage>
    {
		protected override void OnPreRender(System.EventArgs e)
		{
			PhRight.Visible = CurrentItem.RightColumnGridSize != GridSize.Empty;
			base.OnPreRender(e);
		}
    }
}