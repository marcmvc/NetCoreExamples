using System;
using static System.Console;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            while (x < 10)
            {
                WriteLine(x);
                x++;
            }

            string password = string.Empty;
            do
            {
               Write("Enter your password:");
               password = ReadLine();

            } while (password != "Ps$$word");
            WriteLine("Correct!");

            for (int y = 0; y <= 10; y++)
            {
                WriteLine(y);
            }

            string[] names = {"Adam", "Barry", "Charlie"};
            //just for read-only collection, an exception will be thrown if you modify the collection
            // How foreach works internally
            //Type must have a method named GetEnumerator()
            //The returned object must have property named Current and a method named MoveNext
            //The MoveNext method must return true if the are more items to enumerate through or false if there are no more items
            foreach (string name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }
        }
    }
}
