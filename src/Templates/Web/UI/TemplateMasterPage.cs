using N2;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudioPlaza.Web.Templates.Web.UI
{
	public class TemplateMasterPage<TPage> : N2.Web.UI.MasterPage<TPage> 
		where TPage : ContentItem
	{
		private string id = "L";
		public override string ID
		{
			get { return id; }
			set { id = value; }
		}
	}
}
