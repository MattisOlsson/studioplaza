using N2.Integrity;
using N2.Details;
using N2.Web;
using N2.Web.UI;
using N2.Definitions;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
	[PageDefinition(
		"Image Gallery", 
		Description = "Displays an image with next/previous thumbnails", 
		SortOrder = 30,
		IconUrl = "~/Templates/UI/Img/photos.png")
	]
    [RestrictParents(typeof(IStructuralPage))]
	[RestrictChildren(typeof(GalleryItem), typeof(AbstractItem))]
    [FieldSetContainer(ImageGallery.GallerySettings, "Gallery Settings", 500, ContainerName = Tabs.Content)]
	[ConventionTemplate]
	[
		AvailableZone("Top", Zones.Top),
		AvailableZone("Left", Zones.Left),
		AvailableZone("Content", Zones.Content)
	]
	public class ImageGallery : AbstractContentPage
    {
        #region GallerySettings
        public const string GallerySettings = "gallerySettings";

		[EditableNumber("Max Image Width", 200, ContainerName = GallerySettings)]
        public virtual int MaxImageWidth
        {
            get { return (int)(GetDetail("MaxImageWidth") ?? 685); }
            set { SetDetail("MaxImageWidth", value); }
        }

		[EditableNumber("Max Image Height", 210, ContainerName = GallerySettings)]
        public virtual int MaxImageHeight
        {
            get { return (int)(GetDetail("MaxImageHeight") ?? 685); }
            set { SetDetail("MaxImageHeight", value); }
        }

		[EditableNumber("Max Thumbnail Width", 220, ContainerName = GallerySettings)]
        public virtual int MaxThumbnailWidth
        {
            get { return (int)(GetDetail("MaxThumbnailWidth") ?? 70); }
            set { SetDetail("MaxThumbnailWidth", value); }
        }

		[EditableNumber("Max Thumbnail Height", 230, ContainerName = GallerySettings)]
        public virtual int MaxThumbnailHeight
        {
            get { return (int)(GetDetail("MaxThumbnailHeight") ?? 60); }
            set { SetDetail("MaxThumbnailHeight", value); }
        }

        [EditableNumber("Start index", 240, ContainerName = GallerySettings)]
        public virtual int StartIndex
        {
            get { return (int)(GetDetail("StartIndex") ?? 1); }
            set { SetDetail("StartIndex", value); }
        }
        #endregion
    }
}