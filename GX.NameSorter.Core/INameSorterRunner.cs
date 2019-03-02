using System.Threading.Tasks;

namespace GX.NameSorter.Core
{
	public interface INameSorterRunner
	{
		Task SortAndRecordNamesAsync(string[] args);
	}
}
