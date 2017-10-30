using System.Web.UI.WebControls;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Web;
using N2.Persistence;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    [PageDefinition("News", Description = "A news page.", SortOrder = 155,
		IconUrl = "~/Templates/UI/Img/newspaper.png")]
    [RestrictParents(typeof (NewsContainer))]
	[ConventionTemplate("NewsItem")]
    public class News : TextPage, ISyndicatable
    {
        public News()
        {
            Visible = false;
        }

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

        public override void AddTo(ContentItem newParent)
        {
            Utility.Insert(this, newParent, "Published DESC");
        }

        [EditableText("Introduction", 90, ContainerName = Tabs.Content, TextMode = TextBoxMode.MultiLine, Rows = 4,
            Columns = 80)]
        public virtual string Introduction
        {
            get { return (string) (GetDetail("Introduction") ?? string.Empty); }
            set { SetDetail("Introduction", value, string.Empty); }
        }

        string ISyndicatable.Summary
        {
            get { return Introduction; }
        }

		[Persistable(PersistAs = PropertyPersistenceLocation.Detail)]
		public virtual bool Syndicate { get; set; }
    }
}