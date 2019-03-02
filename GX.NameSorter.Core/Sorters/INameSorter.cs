using System.Collections.Generic;
using System.Linq;

namespace GX.NameSorter.Core
{
	public interface INameSorter
	{
		IOrderedEnumerable<Name> SortNames(IList<Name> names);
	}

}
