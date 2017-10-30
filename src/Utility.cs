using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace N2
{
	public class SiteUtility
	{
		public static Regex mIdRegex = new Regex("[^a-z-0-9_-]", RegexOptions.IgnoreCase);

		public static string GetSafeID(string id)
		{
			return mIdRegex.Replace(RemoveDiacritics(id), string.Empty).ToLower();
		}

		public static string RemoveDiacritics(string s)
		{
			string normalizedString = s.Normalize(NormalizationForm.FormD);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < normalizedString.Length; i++)
			{
				char c = normalizedString[i];
				if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
					stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}
	}
}