using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GX.NameSorter.Core.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace GX.NameSorter.Core.Ioc
{
    public static class NameSorterBindings
    {
	    public static IServiceCollection ConfigureBindings(this IServiceCollection services)
	    {
		    return services
			    .AddSingleton<INameReader, FileNameReader>()
			    .AddSingleton<INameSorter, NameSorterer>()
			    .AddSingleton<INameWriter, FileNameWriter>()
			    .AddSingleton<INameWriter, ConsoleNameWriter>()
			    .AddSingleton<INameSorterRunner, NameSorterRunner>();
	    }
	}
}
