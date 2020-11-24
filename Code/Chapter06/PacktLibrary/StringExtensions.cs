using System.Text.RegularExpressions;
using static System.Console;

namespace Packt.Shared
{
    public static class StringExtensions
    {
        public static bool IsValidEmail(this string input)
        {
            // use simple regular expression to check
            // that the input string is a valid email
            return Regex.IsMatch(input,@"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+");
        }

        public static void ExtensionParameter(this string input, string value)
        {
            WriteLine($"Extension method Normalize input: {value}");
        }
    }
}