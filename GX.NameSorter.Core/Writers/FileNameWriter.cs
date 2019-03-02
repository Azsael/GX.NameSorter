using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GX.NameSorter.Core
{
	internal class FileNameWriter : INameWriter
	{
		private const string FileName = "sorted-names-list.txt";

		public Task WriteNames(IList<Name> names)
		{
			return File.WriteAllLinesAsync(FileName, names.Select(x => x.ToString()));
		}
	}
}
