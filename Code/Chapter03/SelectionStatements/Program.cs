using System;
using static System.Console;
using System.IO;

namespace SelectionStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length==0)
            {
                WriteLine("There are no arguments");
            }
            else
            {
                WriteLine("There is at least one argument");
            }

            //add and remove the "" to change the behaviour
            object o = 3;
            int j = 4;
            if (o is int i)
            {
                WriteLine($"{i} x {j} = {i * j}");
            }
            else
            {
                WriteLine("o is not an int so it cannot multiply!");
            }

            //Switch statements
            A_label: var number = (new Random()).Next(1,7);
            WriteLine($"My random number is {number}");
            switch (number)
            {
                case 1:
                    WriteLine("One");
                    break; // jumps to end of switch stament
                
                case 2:
                    WriteLine("2");
                    goto case 1;
                
                case 3:
                
                case 4:
                    WriteLine("Three of four");
                    goto case 1;
                
                case 5:
                //go to sleep for a half second
                    System.Threading.Thread.Sleep(5000);
                    goto A_label;
                
                default:
                    WriteLine("Default");
                    break;
                
            }// end of switch statement

            string path = @"D:\PERSONAL\RESEARCH\C#8\CODE EXAMPLES\Code\Chapter03";
            Stream s = File.Open(Path.Combine(path,"file.txt"), FileMode.OpenOrCreate);
            string message = string.Empty;
            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    message = "The stream is a file that I can write to.";
                    break;
                
                case FileStream readonlyFile:
                    message = "The stream is a read-only file" ;
                    break;
                
                case MemoryStream ms:
                    message = "The stream is a memory address.";
                    break;
                
                default: // always evaluated despite its current position
                    message = "The stream is some other type";
                    break;
                
                case null:
                    message = "The stream is null";
                    break;
            }
            WriteLine(message);


            message = s switch 
            {
                FileStream writeableFile when s.CanWrite => "The stream is a file that I can write to",
                FileStream readonlyFile => "The stream is a read-only file.",
                MemoryStream ms => "The stream is a memory address",
                null => "The stream is null",
                _ => "The stream is some other type"
            };
            WriteLine(message);
        }
    }
}
