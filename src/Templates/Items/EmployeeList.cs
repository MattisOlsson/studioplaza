using N2;
using N2.Collections;
using N2.Details;
using N2.Integrity;
using StudioPlaza.Web.Templates.Items;

namespace StudioPlaza.Web.Templates.Items
{
    [PartDefinition(
		"Employee List", 
		SortOrder = 690,
		IconUrl = "~/Templates/UI/Img/user_add.png")
	]
    [AllowedZones(Zones.Content)]
    public class EmployeeList : AbstractItem
    {
        [EditableLink("Employee container", 100)]
        public virtual EmployeeFolderPage Container
        {
            get { return (EmployeeFolderPage) GetDetail("Container"); }
            set { SetDetail("Container", value); }
        }

        protected override string TemplateName
        {
			get
			{
				return "EmployeeList";
			}
        }
    }
}