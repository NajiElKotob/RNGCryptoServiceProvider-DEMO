using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RNGCryptoServiceProvider_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor fgColor = Console.ForegroundColor;


        DoItAgain:

            Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Random Class");
            Console.ForegroundColor = fgColor;

            Random rnd = new Random();
            // Ten iterations.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rnd.Next());
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("RNGCryptoServiceProvider");
            Console.ForegroundColor = fgColor;
        
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            // Buffer storage.
            byte[] data = new byte[4];

            // Ten iterations.
            for (int i = 0; i < 10; i++)
            {
                // Fill buffer.
                rng.GetBytes(data);

                // Convert to int 32.
                int value = BitConverter.ToInt32(data, 0);
                string value2 = Convert.ToBase64String(data);
                Console.WriteLine(value + "\t" + value2);
            }

            if (Console.ReadLine() == "X")
            {
                return;
            }
            goto DoItAgain;

        }
    }
}
