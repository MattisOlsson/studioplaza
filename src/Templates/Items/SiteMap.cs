using N2.Integrity;
using N2.Web;
using N2.Definitions;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    [PageDefinition("Site Map", 
		Description = "Displays all pages",
		SortOrder = 420,
		IconUrl = "~/Templates/UI/Img/sitemap.png")]
    [RestrictParents(typeof(IStructuralPage))]
	[ConventionTemplate]
    public class SiteMap : AbstractContentPage, IStructuralPage
    {
    }
}