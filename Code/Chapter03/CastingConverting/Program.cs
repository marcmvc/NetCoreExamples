using System;
using static System.Console;
using static System.Convert;

namespace CastingConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            double b = a; //an int can be safely cast into a double
            WriteLine(b);

            double c = 9.8;
            //int d = c; //compiler gives an error for this line
            int d = (int)c; 
            WriteLine(d);//d is 9 losing the .8 part

            long e = 10;
            int f = (int)e;
            WriteLine($"e is {e:N0} and f is {f:N0}");
            //e = long.MaxValue;
            e = 5_000_000_000;
            f=(int)e;
            WriteLine($"e is {e:N0} and f is {f:N0}");

            double g = 9.8;
            int h = ToInt32(g);
            WriteLine($"g is {g} and h is {h}");

            // For real numbers casting will remove the decimal part, but convert will round the number
            // special rule for rounding
            // Banker's Rounding (It will round up if the decimal part is midpoint .5 and the non-decimal is odd
            // but it will round down if the non-decimal part is even)
            double[] doubles=new[] {9.49, 9.5, 9.51, 10.49, 10.5, 10.51};
            foreach (double n in doubles)
            {
                WriteLine($"ToInt({n}) is {ToInt32(n)}");
            }

            // New round algorithm "away from zero" also know as rounding up
            foreach (double n in doubles)
            {
                WriteLine(format:"Math.Round({0}, 0, MidpointRouding.AwayFromZero) is {1}",arg0: n,arg1: Math.Round(value: n,digits: 0, MidpointRounding.AwayFromZero));
            }

            int number = 12;
            WriteLine(number.ToString());
            bool boolean=true;
            WriteLine(boolean.ToString());
            DateTime now = DateTime.Now;
            WriteLine(now.ToString());
            object me = new object();
            WriteLine(me.ToString());

            // When you have a binary object like an image or video that you want to either store or transmit
            // you sometimes do not want to send the raw bits, because you do not know how those bits could be misinterpreted
            // for example, by the network protocol transmiting them or another operating system that is reading the store binary object
            // The safest thing to do is to convert the binary object into a string of safe characters. 
            // Programers call this Base64 encoding
            // ToBase64 and FromBase64String

            //allocate array of 128 bytes
            byte[] binaryObject = new byte[128];
            //populate array with random bytes
            (new Random()).NextBytes(binaryObject);
            WriteLine("Binary Object as bytes:");
            for (int i = 0; i < binaryObject.Length; i++)
            {
                Write($"{binaryObject[i]:X}");
                
            }
            WriteLine();
            //convert to Base64 string and output as text
            // int value would output assuming decimal notation, that is, base10 :X hexadecimal notation
            string encoded = Convert.ToBase64String(binaryObject);
            WriteLine($"Binary Object as Base 64: {encoded}");

            // Convert from string to numbers or dates
            // By default a date and time value outputs with the short date and time format
            // D outputs only the date part using long date format
            int age = int.Parse("27");
            DateTime birthday = DateTime.Parse("4 July 1980");
            WriteLine($"I was born {age} years ago.");
            WriteLine($"My birthday is {birthday}.");
            WriteLine($"My birthday is {birthday:D}.");


            // int count = int.Parse("abc"); compile error
            Write("How many eggs are there?");
            int count;
            string input = Console.ReadLine();
            if (int.TryParse(input, out count))
            {
                WriteLine($"There are {count} eggs");
            }
            else
            {
                WriteLine("I could not parse the input.");
            }
        }
    }
}
