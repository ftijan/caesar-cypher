using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCypher
{
    public class CaesarCypher
    {
        private static char[] BaseAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

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
            throw new NotImplementedException();
        }
    }
}
