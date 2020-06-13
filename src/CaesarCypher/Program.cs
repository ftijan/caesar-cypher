using System;

namespace CaesarCypher
{
    /// <summary>
    /// Demonstrates how to use the Caesar cypher logic.
    /// </summary>
    class Program
    {
        /// <summary>The app entry point.</summary>
        /// <param name="args">Input params.</param>
        static void Main(string[] args)
        {
            var decryptor = new CaesarCypher();

            // Working example:
            var offset = 23;
            var cypher = "QEB NRFZH YOLTK CLU GRJMP LSBO QEB IXWV ALD";
            var plaintext = "THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG";

            var decryptedPhrase = decryptor.DecryptWithOffset(cypher, offset);

            if (decryptedPhrase != plaintext)
            {
                Console.WriteLine("Incorrect logic implemented");
            }            

            Console.WriteLine($"With offset: {offset}\nThe phrase:\n{cypher}\nGives decrypted phrase:\n{decryptedPhrase}\n");
        }
    }
}
