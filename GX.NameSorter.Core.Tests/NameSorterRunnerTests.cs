using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace GX.NameSorter.Core.Integration
{
    public class NameSorterRunnerTests
	{
		private readonly NameSorterRunner _runner;

		private readonly IList<INameWriter> _nameWriters;
		private readonly Mock<INameReader> _nameReader;
		private readonly Mock<INameSorter> _nameSorter;

		private readonly Mock<INameWriter> _nameWriter1;
		private readonly Mock<INameWriter> _nameWriter2;


		public NameSorterRunnerTests()
		{
			_nameWriter1 = new Mock<INameWriter>();
			_nameWriter2 = new Mock<INameWriter>();
			_nameWriters = new List<INameWriter> { _nameWriter1.Object, _nameWriter2.Object};
			_nameReader = new Mock<INameReader>();
			_nameSorter = new Mock<INameSorter>();

			_runner = new NameSorterRunner(_nameWriters, _nameReader.Object, _nameSorter.Object);
		}

		[Fact]
        public async Task WhenSortingAndRecordingNames_ThenWritersAreProvidedWithSortedNames()
		{
			var args = new string[] {"rawr", "baa"};
			var unsortedNames = new List<Name> {new Name()};
			var sortedNames = new List<Name> { new Name() }.OrderBy(x => x);

			_nameReader.Setup(x => x.RetrieveNames(args)).ReturnsAsync(unsortedNames);
			_nameSorter.Setup(x => x.SortNames(unsortedNames)).Returns(sortedNames);
			_nameWriter1
				.Setup(x => x.WriteNames(It.Is<IList<Name>>(y => y.SequenceEqual(sortedNames))))
				.Returns(Task.CompletedTask)
				.Verifiable();
			_nameWriter2
				.Setup(x => x.WriteNames(It.Is<IList<Name>>(y => y.SequenceEqual(sortedNames))))
				.Returns(Task.CompletedTask)
				.Verifiable();

			await _runner.SortAndRecordNamesAsync(args);
			
			_nameWriter1.Verify();
			_nameWriter2.Verify();
		}
    }
}
