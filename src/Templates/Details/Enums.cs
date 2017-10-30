using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudioPlaza.Web.Templates.Details
{
	public enum GridSize
	{
		[StringValue("")]
		Empty,
		[StringValue("grid_1")]
		Grid1,
		[StringValue("grid_2")]
		Grid2,
		[StringValue("grid_3")]
		Grid3,
		[StringValue("grid_4")]
		Grid4,
		[StringValue("grid_5")]
		Grid5,
		[StringValue("grid_6")]
		Grid6,
		[StringValue("grid_7")]
		Grid7,
		[StringValue("grid_8")]
		Grid8,
		[StringValue("grid_9")]
		Grid9,
		[StringValue("grid_10")]
		Grid10,
		[StringValue("grid_11")]
		Grid11,
		[StringValue("grid_12")]
		Grid12
	}

	public enum BoxClass
	{
		[StringValue("")]
		None,
		[StringValue("bm20")]
		BottomMargin20,
		[StringValue("h248")]
		Height248
	}
}