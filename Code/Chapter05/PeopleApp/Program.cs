using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bob =new Person();
            //WriteLine(bob.ToString());
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965,12,22);
            //dddd means the name of the day of the week
            //d means the ne number of the day of the month
            //MMMM means the name of the month
            //yyyy means the full number of the year
            WriteLine(format:"{0} was born on {1:dddd, d MMMM yyyy}", arg0: bob.Name, arg1: bob.DateOfBirth);

            // another way to initialize the object
            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };
            WriteLine(format: "{0} was born on {1:dd MMM yy}", arg0: alice.Name, arg1: alice.DateOfBirth);

            // Use an enum
            // enum internally is stored as int for effiency
            bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlimpia;
            WriteLine(format:"{0}'s favorite wonder is {1}. It's integer is {2}", arg0: bob.Name, arg1:bob.FavoriteAncientWonder, arg2: (int)bob.FavoriteAncientWonder );
            bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;
            //bob.BucketList = (WondersOfTheAncientWorld)18;
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            bob.Children.Add(new Person{Name = "Alfred"});
            bob.Children.Add(new Person {Name = "Zoe"});
            WriteLine($"{bob.Name} has {bob.Children.Count} children");
            for (int child = 0; child < bob.Children.Count; child++)
            {
                WriteLine($"    {bob.Children[child].Name}");
            }

            // Bank Account Example
            BankAccount.InterestRate = 0.012M; // store a shared value
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine(format: "{0} earned {1:C} interest.",arg0: jonesAccount.AccountName, arg1: jonesAccount.Balance * BankAccount.InterestRate);

            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;
            WriteLine(format: "{0} earned {1:C} interest.",arg0: gerrierAccount.AccountName, arg1: gerrierAccount.Balance * BankAccount.InterestRate);

            //Using const value
            WriteLine($"{bob.Name} is a {Person.Species}");
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

            // Constructor initialization
            var blankPerson = new Person();
            WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",arg0: blankPerson.Name, arg1: blankPerson.HomePlanet, arg2: blankPerson.Instantiated);
            // Second constructor to initialize values
            var gunny = new Person("Gunny", "Mars");
            WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",arg0: gunny.Name, arg1: gunny.HomePlanet, arg2: gunny.Instantiated);

            // calling methods
            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());

            // Get Tuple's fields
            (string, int)fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

            // Named Tuple
            var fruitNamed = bob.GetNamedFruit();
            WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

            // Examples of tuples
            var thing1 = ("Neville", 4);
            WriteLine($"{thing1.Item1} has {thing1.Item2}");
            var thing2 = (bob.Name, bob.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count}");

            // Deconstructing tuples
            (string fruitName, int fruitNumber) = bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

            // Method paramters
            WriteLine(bob.SayHello());
            WriteLine(bob.SayHello("Emily"));

            // Optional parameters
            WriteLine(bob.OptionalParameters());
            WriteLine(bob.OptionalParameters("Jump!",98.5));

            // Named paaramters
            WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));

            // You can even use named parameters to skip over optional parameters
            WriteLine(bob.OptionalParameters("Poke!", active: false));

            // in - ref - out parameters
            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            bob.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}");

            // More example about out parameters
            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet");
            // Simplified C# 7.0 syntax for the out parameter
            bob.PassingParameters(d, ref e, out int f);
            WriteLine($"After: d = {d}, e = {e}, f = {f}");

            // Working with Properties
            var sam = new Person
            {
                Name = "Sam",
                DateOfBirth = new DateTime(1972, 1, 27)
            };
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);

            sam.FavoriteIceCream = "Chocolate Fudge";
            WriteLine($"Sam's favorite icecream flavor is {sam.FavoriteIceCream}.");
            sam.FavoritePrimaryColor = "white";
            WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

        }
    }
}
