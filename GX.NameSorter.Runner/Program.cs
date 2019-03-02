using GX.NameSorter.Core;
using GX.NameSorter.Core.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace GX.NameSorter.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
	        MainAsync(args).Wait();
	        Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
		{
			var serviceProvider = new ServiceCollection()
				.ConfigureBindings()
				.BuildServiceProvider();

			var nameSorter = serviceProvider.GetService<INameSorterRunner>();

			await nameSorter.SortAndRecordNamesAsync(args);
		}
    }
}
