/*
╔╗╔┌─┐ ┬┬  ╔═╗┬    ╦╔═┌─┐┌┬┐┌─┐┌┐ 
║║║├─┤ ││  ║╣ │    ╠╩╗│ │ │ │ │├┴┐
╝╚╝┴ ┴└┘┴  ╚═╝┴─┘  ╩ ╩└─┘ ┴ └─┘└─┘
© 2015 Naji El Kotob

This project "RNGCryptoServiceProvider-DEMO" is part of my security training demo

The RNGCryptoServiceProvider-DEMO project is a free code: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or (at your option) any later version.

The RNGCryptoServiceProvider-DEMO project is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY.
See the GNU Lesser General Public License <http://www.gnu.org/licenses/> for more details.
*/


using System;
using System.Security.Cryptography;

namespace RNGCryptoServiceProvider_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor fgColor = Console.ForegroundColor; //Default initial color


            DoItAgain:

            Console.Clear();
            PrintInfo(); //Show info and instructions

           
           
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Random class\tRNGCryptoServiceProvider class");
            Console.ForegroundColor = fgColor;

            //Instantiate a new object of Random and RNGCryptoServiceProvider classes
            Random rnd = new Random(); //https://msdn.microsoft.com/en-us/library/system.random
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider(); //https://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider

            // Buffer storage.
            byte[] data = new byte[8];

            // Ten iterations.
            for (int i = 0; i < 10; i++)
            {
                // Fill buffer.
                rng.GetBytes(data);

                int intValue = BitConverter.ToInt32(data, 0); //Integer
                string hexValue = BitConverter.ToString(data).Replace("-",""); //Hex
                string base64Value = Convert.ToBase64String(data); //Base64

                Console.WriteLine(rnd.Next() + "\t" + intValue.ToString() + "\t" + hexValue + "\t" + base64Value);
               
            }

            if (Console.ReadLine().ToUpper() == "X") //Exit
            {
                return;
            }
            goto DoItAgain;

        }

        private static void PrintInfo()
        {
            Console.WriteLine("Random class vs. RNGCryptoServiceProvider class");
            Console.WriteLine("[Press Enter to refresh the auto-generated values; Type X and press enter to exit]");
            Console.WriteLine(string.Empty);

        }
    }
}
