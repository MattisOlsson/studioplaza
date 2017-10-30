using N2;
using N2.Details;
using N2.Integrity;
using N2.Persistence.Serialization;

namespace StudioPlaza.Web.Templates.Items
{
	[PartDefinition(
		"Carousel", 
		Name = "Carousel",
		SortOrder = 670,
		IconUrl = "~/Templates/UI/Img/text_align_left.png")
	]
	[WithEditableTitle("Title", 10, Required = true)]
	[AllowedZones(Zones.Top)]
    public class Carousel : AbstractItem
    {
		[EditableLink("Container", 100, Required = true)]
		public virtual ContentItem Container
		{
			get
			{
				return (ContentItem)GetDetail("Container");
			}
			set
			{
				SetDetail("Container", value);
			}
		}

        protected override string TemplateName
        {
            get { return "Carousel"; }
        }
    }
}