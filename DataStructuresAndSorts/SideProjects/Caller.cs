using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SideProjects
{
    class Caller
    {
        public static void Main()
        {
            Console.WriteLine("Please enter a string you wish to encrypt: \n");
            string input = Console.ReadLine();

            Console.WriteLine("Please enter a value to shift the letters: \n");
            int shift = int.Parse(Console.ReadLine());

            CaesarCipher cipher = new CaesarCipher(input, shift);

            Console.WriteLine(cipher.Encrypt());

            Console.WriteLine(cipher.Decrypt());
        }
    }
}
