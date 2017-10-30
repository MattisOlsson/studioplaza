using N2.Details;
using N2.Integrity;
using N2.Installation;
using N2.Web;
using N2.Web.UI;
using N2.Definitions;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    [PageDefinition("Root Page", 
		Description = "A root page used to organize start pages.", 
		SortOrder = 0,
		InstallerVisibility = InstallerHint.PreferredRootPage,
		IconUrl = "{ManagementUrl}/Resources/icons/page_gear.png",
		TemplateUrl = "{ManagementUrl}/Myself/Root.aspx")]
    [RestrictParents(AllowedTypes.None)]
    [N2.Web.UI.TabContainer("smtp", "Smtp settings", 30)]
	public class RootPage : ContentItem, IRootPage
    {
        public override string Url
        {
			get { return FindPath(PathData.DefaultAction).RewrittenUrl; }
        }
    }
}