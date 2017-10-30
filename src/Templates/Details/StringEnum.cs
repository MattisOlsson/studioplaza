using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace StudioPlaza.Web.Templates.Details
{
	public static class StringEnum
	{
		public static string GetStringValue(Enum value)
		{
			string output = value.ToString();
			Type type = value.GetType();

			FieldInfo fi = type.GetField(value.ToString());
			StringValueAttribute[] attrs =
			   fi.GetCustomAttributes(typeof(StringValueAttribute),
									   false) as StringValueAttribute[];
			if (attrs.Length > 0)
			{
				output = attrs[0].Value;
			}

			return output;
		}
	}
}