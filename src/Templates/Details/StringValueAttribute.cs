using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioPlaza.Web.Templates.Details
{
	public class StringValueAttribute : Attribute
	{
		public string Value
		{
			get;
			protected set;
		}

		public StringValueAttribute(string value)
		{
			Value = value;
		}
	}
}