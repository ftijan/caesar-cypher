using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCypher
{
    /// <summary>
    /// The Caesar cypher implementation.
    /// </summary>
    public class CaesarCypher
    {
        /// <summary>
        /// The base alphabet.
        /// </summary>
        /// <remarks>Standard English alphabet.</remarks>
        private static char[] BaseAlphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        /// <summary>
        /// Attempts to decrypt the given cypher phrase by shifting the characters 
        /// by the given offset value.
        /// </summary>
        /// <param name="cypher">The cypher phrase.</param>
        /// <param name="offset">The character offset.</param>
        /// <returns>The decrypted phrase if the offset was correct, gibberish phrase otherwise.</returns>
        public string DecryptWithOffset(string cypher, int offset)
        {
            if (cypher is null)
            {
                throw new ArgumentNullException(nameof(cypher));
            }

            // Remove the offset multiples here and save some CPU cycles later on.
            var adjustedOffset = GetAdjustedOffset(BaseAlphabet.Length, offset);

            var cypherMap = GetOffsetAlphabetMap(BaseAlphabet, adjustedOffset);

            var decryptedPhrase = new StringBuilder();

            foreach (var character in cypher)
            {
                if (character == ' ')
                {
                    decryptedPhrase.Append(' ');
                }
                else
                {
                    // Assume correct alphabet with correct letters for this exercise
                    decryptedPhrase.Append(char.ToUpperInvariant(cypherMap[char.ToLowerInvariant(character)]));
                }
            }

            return decryptedPhrase.ToString();
        }

        /// <summary>
        /// Gets the encrypted letter to unencrypted letter mappings 
        /// of the given alphabet for the given offset.</summary>
        /// <remarks>
        /// Assumes the offset was already adjusted.
        /// </remarks>
        /// <param name="alphabet">The char alphabet.</param>
        /// <param name="offset">The offset value to shift the characters by.</param>
        /// <returns>The encrypted to unencrypted letter mappings for the given alphabet and offset/</returns>
        private static IDictionary<char,char> GetOffsetAlphabetMap(char[] alphabet, int offset)
        {
            var offsetDictionaryMap = new Dictionary<char, char>();

            for (int i = 0; i < alphabet.Length; i++)
            {                
                offsetDictionaryMap.Add(GetShiftedCharacter(alphabet, offset, i), alphabet[i]);
            }

            return offsetDictionaryMap;
        }

        /// <summary>
        /// Gets the alphabet character shifted by offset value places 
        /// from the current position in the given alphabet.
        /// </summary>
        /// <remarks>
        /// Assumes the offset was already adjusted.
        /// </remarks>
        /// <param name="alphabet">The char alphabet.</param>
        /// <param name="offset">The offset value to shift the characters by.</param>
        /// <param name="currentPosition">The current position of the char in alphabet.</param>
        /// <returns>The shifted character.</returns>
        private static char GetShiftedCharacter(char[] alphabet, int offset, int currentPosition)
        {
            if (offset < 0)
            {
                if (currentPosition + offset < 0)
                {
                    var rightShift = currentPosition + offset;
                    var index = alphabet.Length + rightShift;
                    return alphabet[index];
                }

                return alphabet[currentPosition + offset];
            }
            else if (offset > 0)
            {
                if (currentPosition + offset > alphabet.Length - 1)
                {
                    var leftShift = currentPosition + offset;
                    var index = leftShift - alphabet.Length;
                    return alphabet[index];
                }                

                return alphabet[currentPosition + offset];
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
