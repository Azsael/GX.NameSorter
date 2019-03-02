using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GX.NameSorter.Core
{
	internal class FileNameReader : INameReader
	{
		public async Task<IList<Name>> RetrieveNames(string[] args)
		{
			var lines = await File.ReadAllLinesAsync(args.First());

			return lines.Select(ParseName).ToList();
		}

		internal Name ParseName(string line)
		{
			var splitNames = line.Split(" ", 4, StringSplitOptions.RemoveEmptyEntries);

			return new Name
			{
				GivenNames = splitNames.Length > 1 ? splitNames.Take(splitNames.Length - 1).ToList() : (IList<string>)splitNames,
				LastName = splitNames.Length > 1 ? splitNames.Last() : null
			};
		}
	}
}
