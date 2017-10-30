using N2.Details;
using N2.Integrity;
using System;
using N2.Definitions;

namespace StudioPlaza.Web.Templates.Items
{
	/// <summary>
	/// A page item with a convenient set of properties defined by default.
	/// </summary>
	[WithEditableName(
		"Name", 
		20, 
		ContainerName = Tabs.Content)]
	[WithEditablePublishedRange(
		"Published Between", 
		30, 
		ContainerName = Tabs.Advanced, 
		BetweenText = " and ")
	]
	[
        AvailableZone("Content", Zones.Content)
	]
	[RestrictParents(typeof(IStructuralPage))]
	public abstract class AbstractContentPage : AbstractPage, IContentPage
	{
		[EditableFreeTextArea("Text", 100, ContainerName = Tabs.Content)]
		[DisplayableTokens]
		public virtual string Text
		{
			get { return (string) (GetDetail("Text") ?? string.Empty); }
			set { SetDetail("Text", value, string.Empty); }
		}

		[EditableCheckBox("Visible", 40, ContainerName = Tabs.Advanced)]
		public override bool Visible
		{
			get { return base.Visible; }
			set { base.Visible = value; }
		}
	}
}