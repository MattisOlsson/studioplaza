using N2.Details;
using N2.Persistence.Serialization;
using N2.Web;
using N2.Definitions;
using N2.Persistence;
using N2.Integrity;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    /// <summary>
    /// A page containing textual information.
    /// </summary>
    [PageDefinition(
		"Carousel item folder",
		Description = "Carousel items can be added to this page.",
		SortOrder = 50)
	]
	[ConventionTemplate("Empty")]
	[RestrictChildren(typeof(CarouselItem))]
    public class CarouselItemFolderPage : AbstractPage, IStructuralPage
    {
		public CarouselItemFolderPage()
		{
			Visible = false;
		}
    }
}