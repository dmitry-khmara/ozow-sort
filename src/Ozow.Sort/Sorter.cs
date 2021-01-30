using System.Collections.Generic;
using System.Text;

namespace Ozow.Sort
{
    public class Sorter
    {
        private static readonly char[] EnglishAlphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        public string Sort(string stringToSort)
        {
            if (stringToSort == null)
                return null;

            var charCounter = new Dictionary<char, int>();
            var totalEnglishCharacters = 0;

            foreach (var character in stringToSort)
            {
                if (!IsEnglishCharacter(character))
                    continue;

                var lowercaseCharacter = char.ToLowerInvariant(character);

                IncreaseCounterForCharacter(charCounter, lowercaseCharacter);

                totalEnglishCharacters++;
            }

            var sortedString = AssembleCounterToString(charCounter, totalEnglishCharacters);

            return sortedString;
        }

        private static void IncreaseCounterForCharacter(Dictionary<char, int> charCounter, char lowercaseCharacter)
        {
            charCounter.TryGetValue(lowercaseCharacter, out int currentCharCounter);

            charCounter[lowercaseCharacter] = currentCharCounter + 1;
        }

        private string AssembleCounterToString(Dictionary<char, int> charCounter, int length)
        {
            var stringBuilder = new StringBuilder(length);

            foreach (var letter in EnglishAlphabet)
            {
                if (!charCounter.TryGetValue(letter, out int counterForThisLetter))
                    continue;

                stringBuilder.Append(letter, counterForThisLetter);
            }

            return stringBuilder.ToString();
        }

        private static bool IsEnglishCharacter(char character)
        {
            return (character >= 'A' && character <= 'Z') || (character >= 'a' && character <= 'z');
        }
    }
}