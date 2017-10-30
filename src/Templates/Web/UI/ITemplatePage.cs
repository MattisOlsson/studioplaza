using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using N2.Web.UI;

namespace StudioPlaza.Web.Templates.Web.UI
{
	public interface ITemplatePage : IItemContainer
	{
		Page Page { get; }
	}
}
