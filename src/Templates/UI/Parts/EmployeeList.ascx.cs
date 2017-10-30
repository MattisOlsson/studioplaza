using System;
using N2.Web.UI.WebControls;
using StudioPlaza.Web.Templates.Items;
using N2;

namespace StudioPlaza.Web.Templates.UI.Parts
{
    public partial class EmployeeList : Web.UI.TemplateUserControl<ContentItem, Items.EmployeeList>
    {
		protected EmployeePage CurrentDataItem
		{
			get
			{
				return Page.GetDataItem() as EmployeePage;
			}
		}

        protected override void OnInit(EventArgs e)
        {
            idsEmployees.CurrentItem = CurrentItem.Container;
            base.OnInit(e);
        }
    }
}