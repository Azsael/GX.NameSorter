using System.Collections.Generic;

namespace GX.NameSorter.Core
{
	public struct Name
	{
		public IList<string> GivenNames { get; set; }

		public string LastName { get; set; }

		public override string ToString()
		{
			return $"{GivenNames.JoinString(" ")} {LastName}".Trim();
		}
	}
}
