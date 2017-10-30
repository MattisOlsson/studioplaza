using N2;
using N2.Definitions;
using System;
using System.Collections.Generic;
using N2.Persistence;
using N2.Persistence.Finder;
using N2.Collections;

namespace StudioPlaza.Web.Templates.Items
{
	[Disable]
    [PageDefinition(
		"Database Search", 
		Description = "Searches for items searching for texts in the database.",
		SortOrder = 200,
		IconUrl = "~/Templates/UI/Img/zoom.png")
	]
    public class DatabaseSearch : AbstractSearch
    {
		[Obsolete("Text search is now used")]
        public virtual IQueryEnding CreateQuery(string query)
        {
            List<ItemFilter> filters = GetFilters();
            string like = '%' + query + '%';
            return Find.Items
                .Where.Title.Like(like)
                .Or.Name.Like(like)
                .Or.Detail().Like(like)
                .Filters(filters);
        }

		[Obsolete("Text search is now used")]
		public override ICollection<ContentItem> Search(string query)
        {
            return CreateQuery(query).Select();
        }
    }
}