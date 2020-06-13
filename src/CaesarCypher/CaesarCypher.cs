using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCypher
{
    public class CaesarCypher
    {
        private static char[] BaseAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        public string DecryptWithOffset(string cypher, int offset)
        {
            if (cypher is null)
            {
                throw new ArgumentNullException(nameof(cypher));
            }

            var cypherMap = GetOffsetAlphabetMap(BaseAlphabet, offset);

            var decryptedPhrase = new StringBuilder();

            foreach (var character in cypher)
            {
                if (character == ' ')
                {
                    decryptedPhrase.Append(' ');
                }
                else
                {
                    // Assume correct alphabet with correct letter for this exercise
                    decryptedPhrase.Append(Char.ToUpperInvariant(cypherMap[Char.ToLowerInvariant(character)]));
                }
            }

            return decryptedPhrase.ToString();
        }

        private static IDictionary<char,char> GetOffsetAlphabetMap(char[] alphabet, int offset)
        {
            var offsetDictionaryMap = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; i++)
            {
                offsetDictionaryMap.Add(alphabet[i], GetShiftedCharacter(alphabet, offset, i));
            }

            return offsetDictionaryMap;
        }

        private static char GetShiftedCharacter(char[] alphabet, int offset, int currentPosition)
        {
            var adjustedOffset = GetAdjustedOffset(alphabet.Length, offset);

            if (adjustedOffset < 0)
            {                
                throw new NotImplementedException();
            }
            else if (adjustedOffset > 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                return alphabet[currentPosition];
            }           
        }

        /// <summary>
        /// Adjusts the initial offset value in case it is a multiple of alphabet length value.
        /// </summary>
        /// <remarks>
        /// Probably a better way to do it with DIV and MOD operations, but this handles 
        /// off-by-one errors more obviously and is debugger-friendly.
        /// </remarks>
        /// <param name="alphabetLength">The alphabet length.</param>
        /// <param name="offset">The offset value.</param>
        /// <returns>The adjusted offset value.</returns>
        private static int GetAdjustedOffset(int alphabetLength, int offset)
        {
            var adjustedOffset = offset;
            while (adjustedOffset < 0 && adjustedOffset < -alphabetLength)
            {
                adjustedOffset += alphabetLength;
            }

            while (adjustedOffset > 0 && adjustedOffset >= alphabetLength)
            {
                adjustedOffset -= alphabetLength;
            }

            return adjustedOffset;
        }
    }
}
