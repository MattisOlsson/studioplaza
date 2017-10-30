using N2.Edit.FileSystem;
using N2.Integrity;
using N2.Details;
using N2.Web;
using N2.Web.Drawing;
using N2.Web.UI;
using N2.Persistence.Serialization;
using N2;
using ImageResizeMode = Logica.Web.ImageTransforms.ImageResizeMode;

namespace StudioPlaza.Web.Templates.Items
{
	[PageDefinition(
		"Gallery Item",
		IconUrl = "~/Templates/UI/Img/photo.png")
	]
    [RestrictParents(typeof(ImageGallery))]
    [TabContainer("advanced", "Advanced", 100)]
	[ConventionTemplate]
	public class GalleryItem : AbstractContentPage
    {
        public GalleryItem()
        {
            Visible = false;
        }

		[FileAttachment, EditableFileUploadAttribute("Image", 30, ContainerName = Tabs.Content)]
        public virtual string ImageUrl
        {
            get { return (string)base.GetDetail("ImageUrl"); }
            set { base.SetDetail("ImageUrl", value); }
        }

        public virtual string ResizedImageUrl
        {
            get { return Web.Adapters.ImageAdapter.GetResizedImageUrl(ImageUrl, Gallery.MaxImageWidth, Gallery.MaxImageHeight, ImageResizeMode.Fit); }
        }


	    public virtual string ThumbnailImageUrl
        {
			get
			{
				return Web.Adapters.ImageAdapter.GetResizedImageUrl(ImageUrl, Gallery.MaxThumbnailWidth, Gallery.MaxThumbnailHeight, ImageResizeMode.Crop);
			}
        }

        public virtual ImageGallery Gallery
        {
            get { return Parent as ImageGallery; }
        }

        public override string Url
        {
			get { return N2.Web.Url.Parse(Parent.Url).AppendQuery(PathData.ItemQueryKey, ID).SetFragment("#t" + ID); }
        }

        public virtual string GetImageUrl()
        {
            var fs = Context.Current.Resolve<IFileSystem>();
            string resizedUrl = ImagesUtility.GetResizedPath(ImageUrl, "original");

            if (fs.FileExists(resizedUrl))
            {
                return resizedUrl;
            }

            return ImageUrl;
        }
    }
}