using N2;
using N2.Details;
using N2.Edit.FileSystem;
using N2.Integrity;
using N2.Persistence.Serialization;
using N2.Web;
using N2.Web.Drawing;

namespace StudioPlaza.Web.Templates.Items
{
	[PageDefinition(
		"Carousel item",
		IconUrl = "~/Templates/UI/Img/text_align_left.png")
	]
	[WithEditableTitle("Title", 10, Required = false)]
	[RestrictParents(typeof(CarouselItemFolderPage))]
	[ConventionTemplate("Empty")]
    public class CarouselItem : AbstractPage
    {
		[FileAttachment, EditableFileUploadAttribute("Image", 90, ContainerName = Tabs.Content, PreferredSize = "original")]
		public virtual string Image
		{
			get
			{
				return (string)(GetDetail("Image") ?? string.Empty);
			}
			set
			{
				SetDetail("Image", value, string.Empty);
			}
		}

		[EditableFreeTextArea("Text", 100, ContainerName = Tabs.Content, Required = false)]
        public virtual string Text
        {
            get { return (string)(GetDetail("Text") ?? string.Empty); }
            set { SetDetail("Text", value, string.Empty); }
        }

		[EditableUrl("LinkUrl", 110, ContainerName = Tabs.Content)]
		public virtual string LinkUrl
		{
			get
			{
				return (string)(GetDetail("LinkUrl") ?? string.Empty);
			}
			set
			{
				SetDetail("LinkUrl", value, string.Empty);
			}
		}

        public virtual string GetImageUrl()
        {
            var fs = Context.Current.Resolve<IFileSystem>();
            string resizedUrl = ImagesUtility.GetResizedPath(Image, "original");

            if (fs.FileExists(resizedUrl))
            {
                return resizedUrl;
            }

            return Image;
        }
    }
}