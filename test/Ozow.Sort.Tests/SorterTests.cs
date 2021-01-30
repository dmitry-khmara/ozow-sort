using FluentAssertions;
using Xunit;

namespace Ozow.Sort.Tests
{
    public class SorterTests
    {
        private readonly Sorter _sorter;

        public SorterTests()
        {
            _sorter = new Sorter();
        }
        
        [Fact]
        public void Sort_GivenUnsortedStringOfLowercaseEnglishCharacters_ShouldSortIt()
        {
            var actualSortedString = _sorter.Sort("cba");

            actualSortedString.Should().Be("abc");
        }

        [Fact]
        public void Sort_GivenUnsortedStringOfUppercaseEnglishCharacters_ShouldChangeCharactersToLowercaseAndSortThem()
        {
            var actualSortedString = _sorter.Sort("CBA");

            actualSortedString.Should().Be("abc");
        }

        [Fact]
        public void Sort_GivenUnsortedStringOfMulticaseCharacters_ShouldChangeCharactersToLowercaseThenFilterOutNonEnglishOnesAndSortThem()
        {
            var actualSortedString = _sorter.Sort("Contrary to popular belief, the pink unicorn flies east.");

            actualSortedString.Should().Be("aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy");
        }

        [Fact]
        public void Sort_GivenStringWithNoEnglishCharacters_ReturnEmptyString()
        {
            var actualSortedString = _sorter.Sort("Привет, как дела?");

            actualSortedString.Should().BeEmpty();
        }

        [Fact]
        public void Sort_GivenNull_ShouldReturnNull()
        {
            var actualSortedString = _sorter.Sort(null);

            actualSortedString.Should().BeNull();
        }
    }
}