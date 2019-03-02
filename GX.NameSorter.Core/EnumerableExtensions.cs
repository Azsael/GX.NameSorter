using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GX.NameSorter.Core
{
	public static class EnumerableExtensions
	{
		public static string JoinString(this IEnumerable<string> source, string separator)
		{
			return string.Join(separator, source);
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (var item in source)
			{
				action(item);
			}
		}

		public static async Task<IList<T>> WhenAll<T>(this IEnumerable<Task<T>> source)
		{
			return await Task.WhenAll(source.ToList());
		}

		public static Task WhenAll(this IEnumerable<Task> source)
		{
			return Task.WhenAll(source.ToList());
		}
	}
}
