using System.Web.UI.WebControls;
using N2.Details;
using N2.Integrity;
using N2.Web.UI.WebControls;
using StudioPlaza.Web.Templates.Items;
using N2.Persistence.Serialization;
using StudioPlaza.Web.Templates.Details;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
	[PartDefinition("Shadow box text", SortOrder = 630, IconUrl = "~/Templates/UI/Img/text_align_left.png")]
    [AllowedZones(AllowedZones.AllNamed)]
    [WithEditableTitle("Title", 10)]
    public class ShadowBoxText : AbstractItem
    {
		[DisplayableHeading(2)]
		public override string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
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

		[EditableEnumFixed("Box class", 200, typeof(BoxClass), ContainerName = Tabs.Advanced)]
		public virtual BoxClass BoxCssClass
		{
			get
			{
				return (BoxClass)(GetDetail("BoxCssClass") ?? (int)BoxClass.None);
			}
			set
			{
				SetDetail("BoxCssClass", (int)value, (int)BoxClass.None);
			}
		}

        protected override string TemplateName
        {
            get 
			{ 
				return "ShadowBox"; 
			}
        }
    }
}