using N2;
using N2.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudioPlaza.Web.Templates.Details
{
	public class EditableEnumFixedAttribute : EditableEnumAttribute
	{
		public override bool UpdateItem(ContentItem item, Control editor)
		{
			ListControl ddl = editor as ListControl;
			string value = this.GetValue(item);
			object value2 = this.GetValue(ddl);

			if (!value2.Equals(value))
			{
				item[Name] = value2;
				return true;
			}

			return false;
		}

		public EditableEnumFixedAttribute(Type enumType) : base(enumType)
		{
		}

		public EditableEnumFixedAttribute(string title, int sortOrder, Type enumType) : base(title, sortOrder, enumType)
		{
		}
	}
}