using N2;
using N2.Definitions;
using N2.Details;
using N2.Integrity;
using N2.Web;
using N2.Web.UI;

namespace StudioPlaza.Web.Templates.Items
{
	[Disable]
    [PageDefinition("Form page", 
		Description = "A page with a form that can be sumitted and sent to an email address.",
		SortOrder = 240,
		IconUrl = "~/Templates/UI/Img/report.png")]
    [TabContainer(FormPage.FormTab, "Form", Tabs.ContentIndex + 2)]
	[ConventionTemplate("Form")]
	[
		AvailableZone("Left", Zones.Left),
		AvailableZone("Right", Zones.Right)
	]
	public class FormPage : AbstractContentPage
    {
    	public const string FormTab = "formPanel";

        [EditableItem("Form", 60, ContainerName = FormTab)]
        public virtual Form Form
        {
            get { return (Form) GetChild("Form"); }
            set
            {
                if (value != null)
                {
                    value.Name = "Form";
                    value.AddTo(this);
                }
            }
        }
    }
}