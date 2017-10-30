using System;
using System.Collections.Generic;
using N2.Engine.Globalization;
using StudioPlaza.Web.Templates.Layouts;
using N2.Collections;
using N2;

namespace StudioPlaza.Web.Templates.UI.Layouts
{
    public partial class TopMenu : Web.UI.TemplateUserControl<ContentItem>
    {
        public int MaxLevels
        {
            get { return tm.MaxLevels; }
            set { tm.MaxLevels = value; }
        }
    }
}