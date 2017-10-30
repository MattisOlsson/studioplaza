using N2;
using N2.Collections;
using N2.Details;
using N2.Integrity;
using StudioPlaza.Web.Templates.Items;

namespace StudioPlaza.Web.Templates.Items
{
    [PartDefinition("News List", 
		Description = "A news list box that can be displayed in a column.", 
		SortOrder = 640,
		IconUrl = "~/Templates/UI/Img/newspaper_go.png")]
    [WithEditableTitle("Title", 10, Required = false)]
    [AllowedZones(AllowedZones.AllNamed)]
    public class NewsList : AbstractItem
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

        [EditableLink("News container", 100)]
        public virtual NewsContainer Container
        {
            get { return (NewsContainer) GetDetail("Container"); }
            set { SetDetail("Container", value); }
        }

		[EditableNumber("Max news", 120)]
        public virtual int MaxNews
        {
            get { return (int) (GetDetail("MaxNews") ?? 3); }
            set { SetDetail("MaxNews", value, 3); }
        }

        public virtual void Filter(ItemList items)
        {
            TypeFilter.Filter(items, typeof (News));
            CountFilter.Filter(items, 0, MaxNews);
        }

        protected override string TemplateName
        {
			get
			{
				return "NewsList";
			}
        }
    }
}