using System.Collections.Generic;
using System.Threading.Tasks;

namespace GX.NameSorter.Core
{
	public interface INameWriter
	{
		Task WriteNames(IList<Name> names);
	}
}
