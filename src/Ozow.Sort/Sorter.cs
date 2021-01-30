using System;
using System.Linq;

namespace Ozow.Sort
{
    public class Sorter
    {
        public string Sort(string stringToSort)
        {
            if (stringToSort == null)
                return null;
            
            var characters = stringToSort.ToCharArray();

            var sortedCharacters = characters.Where(IsEnglishCharacter).Select(Char.ToLowerInvariant).OrderBy(o => o);

            return String.Join("", sortedCharacters);
        }

        private static bool IsEnglishCharacter(char character)
        {
            return (character >= 'A' && character <= 'Z') || (character >= 'a' && character <= 'z');
        }
    }
}