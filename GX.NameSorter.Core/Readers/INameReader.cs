using System.Collections.Generic;
using System.Threading.Tasks;

namespace GX.NameSorter.Core
{
	public interface INameReader
	{
		Task<IList<Name>> RetrieveNames(string[] args);
	}

}
