using N2.Details;
using N2.Persistence.Serialization;
using N2.Web;
using N2.Definitions;
using N2.Persistence;
using StudioPlaza.Web.Templates.Details;
using N2.Integrity;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    /// <summary>
    /// A page containing textual information.
    /// </summary>
    [PageDefinition("Text Page", 
		Description = "A simple text page with an optional image.", 
		SortOrder = 20)]
	[ConventionTemplate("Text")]
	[
		AvailableZone("Top", Zones.Top),
		AvailableZone("Left", Zones.Left), 
		AvailableZone("Right", Zones.Right)
	]
	public class TextPage : AbstractContentPage, IStructuralPage, ISyndicatable
    {
		[FileAttachment, EditableFileUploadAttribute("Image", 90, ContainerName = Tabs.Content, CssClass = "main")]
        public virtual string Image
        {
            get { return (string)(GetDetail("Image") ?? string.Empty); }
            set { SetDetail("Image", value, string.Empty); }
        }

		[EditableEnumFixed("Left column css class", 200, typeof(GridSize), ContainerName = Tabs.Advanced)]
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

		[EditableEnumFixed("Right column css class", 210, typeof(GridSize), ContainerName = Tabs.Advanced)]
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

        public string Summary
        {
			get { return Utility.ExtractFirstSentences(Text, 250); }
        }

		[Persistable(PersistAs = PropertyPersistenceLocation.Detail)]
		public virtual bool Syndicate { get; set; }
    }
}