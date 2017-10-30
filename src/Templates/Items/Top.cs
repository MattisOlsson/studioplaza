using N2.Integrity;
using N2.Details;
using N2.Definitions;
using N2.Persistence.Serialization;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    [Disable]
	[PartDefinition("Top",
		IconUrl = "~/Templates/UI/Img/page_white_star.png")]
    [N2.Web.UI.FieldSetContainer("top", "Top", 100)]
    [RestrictParents(typeof(LanguageRoot))] // The top region is placed on the start page and displayed on all underlying pages
    [AllowedZones("SiteTop")]
    public class Top : AbstractItem
    {
		[FileAttachment, EditableFileUploadAttribute("Logo", 50, ContainerName = "top", Alt = "Logo")]
        public virtual string LogoUrl
        {
            get { return (string)(GetDetail("LogoUrl") ?? string.Empty); }
            set { SetDetail("LogoUrl", value); }
        }

        [EditableUrl("Logo url", 52, ContainerName = "top")]
        public virtual string LogoLinkUrl
        {
            get { return (string)(GetDetail("LogoLinkUrl") ?? "/"); }
            set { SetDetail("LogoLinkUrl", value, "/"); }
        }

		[EditableUrl("Facebook link", 54, ContainerName = "top")]
		public virtual string FacebookLinkUrl
		{
			get
			{
				return (string)(GetDetail("FacebookLinkUrl") ?? "http://www.facebook.com/pages/Studio-Plaza/199208973424774");
			}
			set
			{
				SetDetail("FacebookLinkUrl", value, "http://www.facebook.com/pages/Studio-Plaza/199208973424774");
			}
		}

		[EditableUrl("Facebook link text", 56, ContainerName = "top")]
		public virtual string FacebookLinkText
		{
			get
			{
				return (string)(GetDetail("FacebookLinkText") ?? "Följ oss på facebook");
			}
			set
			{
				SetDetail("FacebookLinkText", value, "Följ oss på facebook");
			}
		}

        protected override string TemplateName
        {
            get { return "Top"; }
        }
    }
}