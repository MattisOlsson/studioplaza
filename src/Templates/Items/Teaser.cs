using System.Web.UI.WebControls;
using N2.Details;
using N2.Integrity;
using N2.Web.UI.WebControls;
using StudioPlaza.Web.Templates.Items;
using N2.Persistence.Serialization;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
	[PartDefinition("Teaser", SortOrder = 620, IconUrl = "~/Templates/UI/Img/heart.png")]
    [AllowedZones(AllowedZones.AllNamed)]
    [WithEditableTitle("Title", 10, Required = false)]
    public class Teaser : AbstractItem
    {
		[DisplayableHeading(1)]
		public override string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

		[FileAttachment, EditableFileUploadAttribute("Teaser image", 90, ContainerName = Tabs.Content)]
		public virtual string TeaserImageUrl
		{
			get
			{
				return (string)GetDetail("TeaserImageUrl", string.Empty);
			}
			set
			{
				SetDetail("TeaserImageUrl", value, string.Empty);
			}
		}

		[EditableFreeTextArea("Text", 100, ContainerName = Tabs.Content)]
		[DisplayableTokens]
		public virtual string Text
		{
			get
			{
				return (string)(GetDetail("Text") ?? string.Empty);
			}
			set
			{
				SetDetail("Text", value, string.Empty);
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

        [EditableText("Linked text", 110)]
        public virtual string LinkText
        {
            get 
			{ 
				return (string)GetDetail("LinkText"); 
			}
            set 
			{ 
				SetDetail("LinkText", value, string.Empty); 
			}
        }

        [EditableCheckBox("Disable shadow box", 120)]
        public virtual bool DisableShadowBox
        {
            get
            {
                var detail = GetDetail("DisableShadowBox");

                return (detail != null) && (bool) detail;
            }
            set
            {
                SetDetail("DisableShadowBox", value, false);
            }
        }

        protected override string TemplateName
        {
            get 
			{ 
				return "Teaser"; 
			}
        }
    }
}