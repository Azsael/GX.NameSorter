using System;
using System.Collections.Generic;
using System.Linq;

namespace GX.NameSorter.Core
{
	internal class NameSorterer : INameSorter
	{
		public IOrderedEnumerable<Name> SortNames(IList<Name> names)
		{
			return names
				.OrderBy(x => x.LastName, StringComparer.OrdinalIgnoreCase)
				.ThenBy(x => x.GivenNames.JoinString(" "), StringComparer.OrdinalIgnoreCase);
		}
	}
}
