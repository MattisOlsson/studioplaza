using N2.Details;
using N2.Persistence.Serialization;
using N2.Web;
using N2.Definitions;
using N2.Persistence;
using N2.Integrity;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    /// <summary>
    /// A page containing textual information.
    /// </summary>
    [PageDefinition(
		"Employee folder", 
		Description = "Employees can be added to this page.",
		SortOrder = 60)
	]
	[ConventionTemplate("Empty")]
	[RestrictChildren(typeof(EmployeePage))]
    public class EmployeeFolderPage : AbstractPage, IStructuralPage
    {
		public EmployeeFolderPage()
		{
			Visible = false;
		}
    }
}