using System.Collections.Generic;
using StudioPlaza.Web.Templates.Details;

namespace StudioPlaza.Web.Templates.Items
{
    public abstract class OptionSelectQuestion : Question
    {
        [EditableOptions(Title="Options", SortOrder=20)]
        public virtual IList<Option> Options
        {
            get
            {
                List<Option> options = new List<Option>();
                foreach (Option o in GetChildren())
                    options.Add(o);
                return options;
            }
        }
    }
}