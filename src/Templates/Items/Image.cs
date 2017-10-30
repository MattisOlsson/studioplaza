using System.Web.UI.WebControls;
using N2.Details;
using N2.Integrity;
using N2.Web.UI.WebControls;
using StudioPlaza.Web.Templates.Items;
using N2.Persistence.Serialization;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
	[PartDefinition("Image", SortOrder = 600, IconUrl = "~/Templates/UI/Img/photo.png")]
    [AllowedZones(AllowedZones.AllNamed)]
    public class Image : AbstractItem
    {
		[FileAttachment, EditableFileUploadAttribute("Image url", 90, ContainerName = Tabs.Content)]
		public virtual string ImageUrl
		{
			get
			{
				return (string)GetDetail("ImageUrl", string.Empty);
			}
			set
			{
				SetDetail("ImageUrl", value, string.Empty);
			}
		}

		[EditableUrl("Link", 100)]
		public virtual string LinkUrl
		{
			get
			{
				return (string)GetDetail("LinkUrl");
			}
			set
			{
				SetDetail("LinkUrl", value, string.Empty);
			}
		}

        protected override string TemplateName
        {
            get 
			{ 
				return "Image"; 
			}
        }
    }
}