using N2;
using N2.Details;
using N2.Integrity;

namespace StudioPlaza.Web.Templates.Items
{
	[PartDefinition("Text", SortOrder = 610, Name = "Text",
		IconUrl = "~/Templates/UI/Img/text_align_left.png")]
	[WithEditableTitle("Title", 10, Required = false)]
	[AllowedZones(AllowedZones.AllNamed)]
    public class TextItem : AbstractItem
    {
		[EditableFreeTextArea("Text", 100)]
        public virtual string Text
        {
            get { return (string)(GetDetail("Text") ?? string.Empty); }
            set { SetDetail("Text", value, string.Empty); }
        }

        protected override string TemplateName
        {
            get { return "Text"; }
        }
    }
}