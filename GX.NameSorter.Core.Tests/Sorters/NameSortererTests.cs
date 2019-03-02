using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace GX.NameSorter.Core
{
	public class NameSortererTests
	{
		private readonly NameSorterer _sorterer;

		public NameSortererTests()
		{
			_sorterer = new NameSorterer();
		}

		[Fact]
		public void WhenSortingNames_ThenNamesShouldBeSortedByLastNameThenFirstName()
		{
			var unsortedNames = new[]
			{
				new Name {GivenNames = new[] { "Mikayla"}, LastName = "Lindsey Roger"},
				new Name {GivenNames = new[] { "Leo", "Uriah"}, LastName = "Archer"},
				new Name {GivenNames = new[] { "Leo", "Julius"}, LastName = "Archer"},
				new Name {GivenNames = new[] { "Mikayla", "Anne" }, LastName = "Lindsey"},
				new Name {GivenNames = new[] {"Gomez"}, LastName = "Adams"},
			};
			var sortedNames = new[]
			{
				new Name {GivenNames = new[] {"Gomez"}, LastName = "Adams"},
				new Name {GivenNames = new[] { "Leo", "Julius"}, LastName = "Archer"},
				new Name {GivenNames = new[] { "Leo", "Uriah"}, LastName = "Archer"},
				new Name {GivenNames = new[] { "Mikayla", "Anne" }, LastName = "Lindsey"},
				new Name {GivenNames = new[] { "Mikayla"}, LastName = "Lindsey Roger"},
			};

			var result = _sorterer.SortNames(unsortedNames);

			result.Should().BeEquivalentTo(sortedNames, x => x.ComparingByMembers<Name>());
		}
	}
}
