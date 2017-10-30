using System.Web.UI.WebControls;
using N2.Details;
using N2.Integrity;
using N2.Web.UI.WebControls;
using StudioPlaza.Web.Templates.Items;
using N2.Persistence.Serialization;
using N2.Web;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
	[PageDefinition(
		"Employee", 
		IconUrl = "~/Templates/UI/Img/user_add.png")
	]
	[RestrictParents(typeof(EmployeeFolderPage))]
    [WithEditableTitle("Title", 10)]
	[ConventionTemplate("Empty")]
    public class EmployeePage : AbstractContentPage
    {
		[DisplayableHeading(1)]
		public override string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

		[FileAttachment, EditableFileUploadAttribute("Image", 90, ContainerName = Tabs.Content)]
		public virtual string Image
		{
			get
			{
				return (string)GetDetail("Image", string.Empty);
			}
			set
			{
				SetDetail("Image", value, string.Empty);
			}
		}

		[EditableNumber("Image left position", 100, ContainerName = Tabs.Content)]
		public virtual int ImageLeftPos
		{
			get
			{
				return (int)(GetDetail("ImageLeftPos") ?? 0);
			}
			set
			{
				SetDetail("ImageLeftPos", value);
			}
		}

	}
}