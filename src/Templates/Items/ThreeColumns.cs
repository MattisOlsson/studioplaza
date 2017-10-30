using N2;
using N2.Details;
using N2.Integrity;
using StudioPlaza.Web.Templates.Details;
using StudioPlaza.Web.Templates.Items;

namespace StudioPlaza.Web.Templates.Items
{
	[PartDefinition(
		"Three column container",
		SortOrder = 660,
		IconUrl = "~/Templates/UI/Img/text_columns.png")
	]
    [
		AvailableZone("Left column", Zones.ColumnLeft),
		AvailableZone("Center column", Zones.ColumnCenter),
		AvailableZone("Right column", Zones.ColumnRight)
	]
    [AllowedZones(Zones.Content, Zones.Top)]
    public class ThreeColumns : AbstractItem
    {
		[EditableEnumFixed("First column css class", 100, typeof(GridSize), ContainerName = Tabs.Content)]
		public virtual GridSize FirstColumnGridSize
		{
			get
			{
				return (GridSize)(GetDetail("FirstColumnGridSize") ?? (int)GridSize.Grid4);
			}
			set
			{
				SetDetail("FirstColumnGridSize", (int)value, (int)GridSize.Grid4);
			}
		}

		[EditableEnumFixed("Second column css class", 110, typeof(GridSize), ContainerName = Tabs.Content)]
		public virtual GridSize SecondColumnGridSize
		{
			get
			{
				return (GridSize)(GetDetail("SecondColumnGridSize") ?? (int)GridSize.Grid4);
			}
			set
			{
				SetDetail("SecondColumnGridSize", (int)value, (int)GridSize.Grid4);
			}
		}

		[EditableEnumFixed("Third column css class", 120, typeof(GridSize), ContainerName = Tabs.Content)]
		public virtual GridSize ThirdColumnGridSize
		{
			get
			{
				return (GridSize)(GetDetail("ThirdColumnGridSize") ?? (int)GridSize.Grid4);
			}
			set
			{
				SetDetail("ThirdColumnGridSize", (int)value, (int)GridSize.Grid4);
			}
		}

		protected override string TemplateName
        {
            get { return "ThreeColumns"; }
        }
    }
}