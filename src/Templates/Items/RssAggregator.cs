using N2;
using N2.Details;
using N2.Integrity;

namespace StudioPlaza.Web.Templates.Items
{
    [PartDefinition("Rss List", 
		Name = "RssAggregatorItem", 
		Description = "A list of news items retrieved from an rss source.",
		SortOrder = 680,
		IconUrl = "~/Templates/UI/Img/rss.png")]
    [WithEditableTitle("Title", 10, Required = true)]
    [AllowedZones(Zones.Right, Zones.Left, Zones.Content, Zones.ColumnLeft, Zones.ColumnRight)]
	public class RssAggregator : AbstractItem
    {
		[DisplayableHeading(1)]
		public override string Title
		{
			get
			{
				return base.Title;
			}
			set
			{
				base.Title = value;
			}
		}

        [EditableFreeTextArea("Text", 100)]
        public virtual string Text
        {
            get { return (string)(GetDetail("Text") ?? string.Empty); }
            set { SetDetail("Text", value, string.Empty); }
        }

        [EditableUrl("Rss Url", 120)]
        public virtual string RssUrl
        {
            get { return (string)(GetDetail("RssUrl") ?? string.Empty); }
            set { SetDetail("RssUrl", value, string.Empty); }
        }

		[EditableNumber("Max Count", 130)]
        public virtual int MaxCount
        {
            get { return (int)(GetDetail("MaxCount") ?? 5); }
            set { SetDetail("MaxCount", value, 5); }
        }

        protected override string TemplateName
        {
            get { return "RssAggregator"; }
        }
    }
}