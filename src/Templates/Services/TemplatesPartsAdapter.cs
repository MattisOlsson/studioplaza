using N2.Collections;
using StudioPlaza.Web.Templates.Items;
using N2.Web;
using N2.Web.Parts;
using N2.Engine;
using N2;

namespace StudioPlaza.Web.Templates.Services
{
	/// <summary>
	/// Implements "Recusive" zones functionality.
	/// </summary>
	[Adapts(typeof(AbstractPage))]
	public class TemplatesPartsAdapter : PartsAdapter
	{
		public override ItemList GetItemsInZone(ContentItem parentItem, string zoneName)
		{
			ItemList items =  base.GetItemsInZone(parentItem, zoneName);
			ContentItem grandParentItem = parentItem;
			if (zoneName.StartsWith("Recursive") && grandParentItem is AbstractContentPage && !(grandParentItem is LanguageRoot))
			{
				if(parentItem.VersionOf == null)
					items.AddRange(GetItemsInZone(parentItem.Parent, zoneName));
				else
					items.AddRange(GetItemsInZone(parentItem.VersionOf.Parent, zoneName));
			}
			return items;
		}
	}
}
