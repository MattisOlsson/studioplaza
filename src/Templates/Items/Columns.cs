using N2;
using N2.Details;
using N2.Integrity;
using StudioPlaza.Web.Templates.Details;
using StudioPlaza.Web.Templates.Items;

namespace StudioPlaza.Web.Templates.Items
{
	[PartDefinition(
		"Two column container",
		SortOrder = 650,
		IconUrl = "~/Templates/UI/Img/text_columns.png")
	]
    [
		AvailableZone("Left column", Zones.ColumnLeft), 
		AvailableZone("Right column", Zones.ColumnRight)
	]
    [AllowedZones(Zones.Content, Zones.Left, Zones.Right, Zones.Top)]
    public class Columns : AbstractItem
    {
		[EditableEnumFixed("Left column css class", 100, typeof(GridSize), ContainerName = Tabs.Content)]
		public virtual GridSize LeftColumnGridSize
		{
			get
			{
				return (GridSize)(GetDetail("LeftColumnGridSize") ?? (int)GridSize.Grid6);
			}
			set
			{
				SetDetail("LeftColumnGridSize", (int)value);
			}
		}

		[EditableEnumFixed("Right column css class", 110, typeof(GridSize), ContainerName = Tabs.Content)]
		public virtual GridSize RightColumnGridSize
		{
			get
			{
				return (GridSize)(GetDetail("RightColumnGridSize") ?? (int)GridSize.Grid6);
			}
			set
			{
				SetDetail("RightColumnGridSize", (int)value);
			}
		}

		[EditableCheckBox("Left column alpha?", 200, DefaultValue = false, ContainerName = Tabs.Advanced)]
		public virtual bool LeftColumnAlpha
		{
			get
			{
				return (bool)(GetDetail("LeftColumnAlpha") ?? false);
			}
			set
			{
				SetDetail("LeftColumnAlpha", value);
			}
		}

		[EditableCheckBox("Right column omega?", 210, DefaultValue = false, ContainerName = Tabs.Advanced)]
		public virtual bool RightColumnOmega
		{
			get
			{
				return (bool)(GetDetail("RightColumnOmega") ?? false);
			}
			set
			{
				SetDetail("RightColumnOmega", value);
			}
		}

		protected override string TemplateName
        {
            get { return "Columns"; }
        }
    }
}