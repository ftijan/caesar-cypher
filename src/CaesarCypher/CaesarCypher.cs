using System;

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

            throw new NotImplementedException();
        }
    }
}
