using System.Web.UI;
using System.Web.UI.WebControls;
using N2.Details;
using StudioPlaza.Web.Templates.Web.UI.WebControls;
using N2.Web.Parts;
using N2;

namespace StudioPlaza.Web.Templates.Items
{
    [PartDefinition("Multiple Select (check boxes)")]
	public class MultipleSelect : OptionSelectQuestion, IAddablePart
    {
        [EditableCheckBox("Display vertically", 19)]
        public virtual bool Vertical
        {
            get { return (bool)(GetDetail("Vertical") ?? true); }
            set { SetDetail("Vertical", value); }
        }

        public virtual Control AddTo(Control container)
        {
            MultipleSelectControl ssc = new MultipleSelectControl(this, Vertical ? RepeatDirection.Vertical : RepeatDirection.Horizontal);
            container.Controls.Add(ssc);
            return ssc;
        }
    }
}