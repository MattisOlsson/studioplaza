using System;

namespace StudioPlaza.Web.Templates.UI.Views
{
    public partial class Redirect : Web.UI.TemplatePage<Templates.Items.Redirect>
    {
        protected override void OnInit(EventArgs e)
        {
            if (CurrentPage.Redirect301)
            {
                Response.Status = "301 Moved Permanently";
                Response.AddHeader("Location", CurrentPage.Url);
            }
            else
            {
                Response.Redirect(CurrentPage.Url);
            }
        }
    }
}