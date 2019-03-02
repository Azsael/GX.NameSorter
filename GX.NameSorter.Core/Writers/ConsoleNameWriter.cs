using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GX.NameSorter.Core
{
	internal class ConsoleNameWriter : INameWriter
	{
		public Task WriteNames(IList<Name> names)
		{
			names.ForEach(x => Console.WriteLine(x.ToString()));
			return Task.CompletedTask;
		}
	}
}
