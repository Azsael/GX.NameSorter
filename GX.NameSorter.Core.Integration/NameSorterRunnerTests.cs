using FluentAssertions;
using GX.NameSorter.Core.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GX.NameSorter.Core.Integration
{
    public class NameSorterRunnerTests
    {
	    private readonly INameSorterRunner _runner;

	    public NameSorterRunnerTests()
	    {
		    var serviceProvider = new ServiceCollection()
			    .ConfigureBindings()
			    .BuildServiceProvider();

			_runner = serviceProvider.GetService<INameSorterRunner>();
		}

		[Fact]
        public async Task VerifyNameSorter()
        {
	        try
	        {
		        await _runner.SortAndRecordNamesAsync(new[] {"./unsorted-names-list.txt"});
				
		        // todo: how the fucks?
				File.Exists("./sorted-names-list.txt").Should().BeTrue();

		        var assertLines = await File.ReadAllLinesAsync("./sorted-names-list-test.txt");
		        var generatedLines = await File.ReadAllLinesAsync("./sorted-names-list.txt");

		        generatedLines.Should().BeEquivalentTo(assertLines);
	        }
	        finally
	        {
				File.Delete("./sorted-names-list.txt");
	        }
        }
    }
}
