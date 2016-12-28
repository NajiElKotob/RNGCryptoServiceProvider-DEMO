/*
╔╗╔┌─┐ ┬┬  ╔═╗┬    ╦╔═┌─┐┌┬┐┌─┐┌┐ 
║║║├─┤ ││  ║╣ │    ╠╩╗│ │ │ │ │├┴┐
╝╚╝┴ ┴└┘┴  ╚═╝┴─┘  ╩ ╩└─┘ ┴ └─┘└─┘
© 2015 Naji El Kotob

RNGCryptoServiceProvider-DEMO project is part of my .NET Secure Coding Training. 
This project is absolutely free open source; you can redistribute it and/or modify it without any restrictions.

*** The RNGCryptoServiceProvider-DEMO project is created with a hope that it will be useful,
but WITHOUT ANY WARRANTY *** 

Should you have any questions or suggestions, please drop me an email at naji [@] DotNETHeroes.com
*/


using System;
using System.Security.Cryptography;

namespace RNGCryptoServiceProvider_DEMO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initial settings

            //Save the original foreground color
            ConsoleColor originalColor = Console.ForegroundColor;

            // Buffer storage.
            var arraySize = 8;
            

            //Instantiate a new object of Random and RNGCryptoServiceProvider classes
            Random rnd = new Random(); //https://msdn.microsoft.com/en-us/library/system.random
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider(); //https://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider


            DoItAgain:

            Console.Clear();

            byte[] data = new byte[arraySize];

            //Print info and help
            PrintInfo();

            //Print table header
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintRecords("Random class", "RNGCryptoServiceProvider class");
            Console.ForegroundColor = originalColor;

            //Print Headers
            Console.ForegroundColor = ConsoleColor.Green;
            PrintRecords("Random#", "Integer", "Hex", "Base-64");
            Console.ForegroundColor = originalColor;

            // Print 10 records
            for (int i = 0; i < 10; i++)
            {
                // Fill buffer.
                rng.GetBytes(data);

                int intValue = BitConverter.ToInt32(data, 0); //Integer
                string hexValue = BitConverter.ToString(data).Replace("-", ""); //Hex
                string base64Value = Convert.ToBase64String(data); //Base64

                PrintRecords(rnd.Next().ToString(), intValue.ToString(), hexValue, base64Value);
            }

            //Print the array size
            PrintRecords(string.Empty);
            PrintRecords("Array Size: " + arraySize.ToString());

           
            var input = Console.ReadLine();
            int newArraySize;
            if (int.TryParse(input, out newArraySize))  //# to change the array size
            {
                newArraySize = newArraySize < 4 ? 4 : newArraySize;
                newArraySize = newArraySize > 9 ? 9 : newArraySize;
                arraySize = newArraySize;
            }
            else if (input.ToUpper() == "X")  //'X' to Exit
            {
                return; 
            }
            
            //If not 'X' than referesh
            goto DoItAgain;

        }

        private static void PrintInfo()
        {
            Console.WriteLine("RNGCryptoServiceProvider-DEMO by Naji El Kotob");
            Console.WriteLine("...[Press Enter to refresh the auto-generated values]");
            Console.WriteLine("...[Type a number (4-9) and press enter to change the array size]");
            Console.WriteLine("...[Type X and press enter to exit]");
            Console.WriteLine(string.Empty);
        }

        private static void PrintRecords(string rec1, string rec2 = "", string rec3 = "", string rec4 = "")
        {
            Console.WriteLine("{0,-15}{1,-15}{2,-20}{3,-15}", rec1, rec2, rec3, rec4); //The formatted data in the field is right-aligned if alignment is positive and left-aligned if alignment is negative https://msdn.microsoft.com/en-us/library/txafckwd(v=vs.110).aspx
        }

    }
}
