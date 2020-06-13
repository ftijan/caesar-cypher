using System;

namespace CaesarCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            const int offset = 3;
            var cypher = "ZKHHO ELFBFOH PDALPXP SURWHFW";

            var decryptor = new CaesarCypher();
            var decryptedPhrase = decryptor.DecryptWithOffset(cypher, offset);

            Console.WriteLine($"With offset {offset}\nThe phrase\n{cypher}\nGives decrypted phrase:\n{decryptedPhrase}\n");
        }
    }
}
