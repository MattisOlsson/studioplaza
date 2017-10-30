using N2.Integrity;
using N2.Web;
using N2.Definitions;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    [PageDefinition("News Container", 
		Description = "A list of news. News items can be added to this page.",
		SortOrder = 40,
		IconUrl = "~/Templates/UI/Img/newspaper_link.png")]
    [RestrictParents(typeof (IStructuralPage))]
	[ConventionTemplate("NewsList")]
	[SortChildren(SortBy.PublishedDescending)]
	[
		AvailableZone("Left", Zones.Left),
		AvailableZone("Right", Zones.Right)
	]
	public class NewsContainer : AbstractContentPage
    {
    }
}