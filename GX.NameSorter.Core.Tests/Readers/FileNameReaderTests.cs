using FluentAssertions;
using Xunit;

namespace GX.NameSorter.Core
{
	public class FileNameReaderTests
	{
		private readonly FileNameReader _reader;

		public FileNameReaderTests()
		{
			_reader = new FileNameReader();
		}

		[Theory]
		[InlineData("Janet", null, "Janet")]
		[InlineData("Janet Parsons", "Parsons", "Janet")]
		[InlineData("Adonis Julius Archer", "Archer", "Adonis", "Julius")]
		[InlineData("Hunter Uriah Mathew Clarke", "Clarke", "Hunter", "Uriah", "Mathew")]
		[InlineData("Alyvn Boddynock Dabbledob Stumbleduck Scamperdown Boondiggles Leffery", "Stumbleduck Scamperdown Boondiggles Leffery", "Alyvn", "Boddynock", "Dabbledob")]
		public void WhenParsingName_ThenNamesParsedCorrectly(string inputValue, string expectedLastName, params string[] expectedGivenNames)
		{
			var name = _reader.ParseName(inputValue);

			name.GivenNames.Should().BeEquivalentTo(expectedGivenNames);
			name.LastName.Should().Be(expectedLastName);
		}
	}
}
