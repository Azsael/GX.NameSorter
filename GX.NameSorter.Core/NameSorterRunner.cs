using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace GX.NameSorter.Core
{
	internal class NameSorterRunner : INameSorterRunner
	{
		private readonly IList<INameWriter> _nameWriters;
		private readonly INameReader _nameReader;
		private readonly INameSorter _nameSorter;

		public NameSorterRunner(IEnumerable<INameWriter> nameWriters, INameReader nameReader, INameSorter nameSorter)
		{
			_nameWriters = nameWriters.ToList();
			_nameReader = nameReader;
			_nameSorter = nameSorter;
		}

		public async Task SortAndRecordNamesAsync(string[] args)
		{
			var names = await _nameReader.RetrieveNames(args).ConfigureAwait(false);

			var sortedNames = _nameSorter.SortNames(names).ToImmutableList();

			await _nameWriters.Select(x => x.WriteNames(sortedNames)).WhenAll().ConfigureAwait(false);
		}
	}
}
