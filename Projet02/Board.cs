using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet02
{
    class Board
    {

        public static void Print(string message = "", int selection = 0, decimal price = 0, decimal received = 0, decimal returned = 0, string result = "")
        {
            string choiceString = selection.ToString().PadLeft(2, '0');
            string priceString = PadPrice(price);
            string receivedString = PadPrice(received);
            string returnedString = PadPrice(returned);
            string messageString = PadBoth(message == "" ? "VOTRE CHOIX ?" : message, 33);
            string resultString = PadBoth(result, 24);
            Console.Clear();
            Console.WriteLine($"-----------------------------------");
            Console.WriteLine($"|        Machine à bonbons        |");
            Console.WriteLine($"|----------------------------------");
            Console.WriteLine($"|{messageString}|");
            Console.WriteLine($"|----------------------------------");
            Console.WriteLine($"| 01 | 02 | 03 | 04 | 05 |-> { choiceString } <-|");
            Console.WriteLine($"|------------------------|--------|");
            Console.WriteLine($"| 06 | 07 | 08 | 09 | 10 |  PRIX  |");
            Console.WriteLine($"|------------------------|  { priceString } |");
            Console.WriteLine($"| 11 | 12 | 13 | 14 | 15 |--------|");
            Console.WriteLine($"|------------------------|  PERÇU |");
            Console.WriteLine($"| 16 | 17 | 18 | 19 | 20 |  { receivedString } |");
            Console.WriteLine($"|------------------------|--------|");
            Console.WriteLine($"| 21 | 22 | 23 | 24 | 25 |  REMIS |");
            Console.WriteLine($"|------------------------|  { returnedString } |");
            Console.WriteLine($"|{resultString}|--------|");
            Console.WriteLine($"-----------------------------------");
        }

        private static string PadPrice(decimal price)
        {
            return price == 0 ? "-----" : price.ToString("0.00$").PadLeft(5, '0');
        }

        public static string PadBoth(string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(length);
        }
    }
}
