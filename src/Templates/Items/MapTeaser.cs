using System.Web.UI.WebControls;
using N2.Details;
using N2.Integrity;
using N2.Web.UI.WebControls;
using StudioPlaza.Web.Templates.Items;
using N2.Persistence.Serialization;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
	[PartDefinition("Map teaser", SortOrder = 700, IconUrl = "~/Templates/UI/Img/heart.png")]
    [AllowedZones(AllowedZones.AllNamed)]
    [WithEditableTitle("Title", 10, Required = false)]
    public class MapTeaser : AbstractItem
    {
		[DisplayableHeading(1)]
		public override string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

		[EditableText("Longitude", 90, Required = true)]
		public virtual string Longitude
		{
			get
			{
				return (string)GetDetail("Longitude", string.Empty);
			}
			set
			{
				SetDetail("Longitude", value, string.Empty);
			}
		}

		[EditableText("Latitude", 100, Required = true)]
		public virtual string Latitude
		{
			get
			{
				return (string)GetDetail("Latitude", string.Empty);
			}
			set
			{
				SetDetail("Latitude", value, string.Empty);
			}
		}

		[EditableFreeTextArea("Text", 110, ContainerName = Tabs.Content)]
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

		[EditableUrl("Link", 120)]
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

        [EditableText("Linked text", 130)]
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

        protected override string TemplateName
        {
            get 
			{ 
				return "MapTeaser"; 
			}
        }
    }
}