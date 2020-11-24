using System;
using static System.Console;
using Packt.Shared;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var harry = new Person {Name = "Harry"};
            var mary = new Person {Name = "Mary"};
            var jill = new Person {Name = "Jill"};
            //call instance method
            var baby1 = mary.ProcreateWith(harry);
            // call static method
            var baby2 = Person.Procreate(harry, jill);
            WriteLine($"{harry.Name} has {harry.Children.Count} children");
            WriteLine($"{mary.Name} has {mary.Children.Count} children");
            WriteLine($"{jill.Name} has {jill.Children.Count} children");
            WriteLine(format: "{0}'s first child is named \"{1}\".",arg0: harry.Name, arg1: harry.Children[0].Name);
            // call an operator
            var baby3 = harry * mary;
            // call method with internal local function
            WriteLine($"5! is {Person.Factorial(5)}");
            harry.Shout += Harry_Shout;
            harry.Poke();
            harry.Poke();
            harry.Poke();
            harry.Poke();
            
            harry.Start+=Receive_Call;
            harry.ReceiveCall();
            harry.ReceiveCall();
            harry.ReceiveCall();
            harry.ReceiveCall();
            // Interfaces IComparable (allows arrays and collection to be sorted)
            Person[] people=
            {
                new Person{Name = "Simon"},
                new Person{Name = "Jenny"},
                new Person{Name = "Adam"},
                new Person{Name = "Richard"}
            };
            WriteLine("Initial list of people:");
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }
            WriteLine("Use person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            // Compare Names using IComparer Interfaces
            WriteLine("Use PersonComparer's IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            // Generics
            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer: {t1.Process(42)}");
            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string: {t2.Process("apple")}");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer: {gt1.Process(42)}");
            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string: {gt2.Process("apple")}");

            // Working with generic methods
            string number1 = "4";
            WriteLine("{0} squared is {1}", arg0: number1, arg1: Squarer.Square<string>(number1));
            byte number2 = 3;
            WriteLine("{0} squared is {1}",arg0: number2, arg1: Squarer.Square(number2));

            // Memory Management
            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");


            // Inheriting from classes
             Employee john = new Employee{ Name = "John Jones", DateOfBirth = new DateTime(1990,7,28)};
             john.WriteToConsole();
             john.EmployeeCode = "JJ001";
             john.HireDate = new DateTime(2014, 11, 23);
             WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");
             WriteLine(john.ToString());

             // Overriding methods
             Employee aliceInEmployee = new Employee
             {
                 Name = "Alice",
                 EmployeeCode = "AA123"
             };
             Person aliceInPerson = aliceInEmployee;
             aliceInEmployee.WriteToConsole();
             aliceInPerson.WriteToConsole();
             WriteLine(aliceInEmployee.ToString());
             WriteLine(aliceInPerson.ToString());

             // Casting 
             // Not Safe an Invalid Cast exception could appear
             // Employee explicitAlice = (Employee)aliceInPerson;
             // is keyword   
             if (aliceInPerson is Employee)
             {
                 WriteLine($"{nameof(aliceInPerson)} IS an Employee");

                 Employee explicitAlice = (Employee)aliceInPerson;
                 // safetily do something with explicitAlice
             }

             // as keyword
             Employee aliceAsEmployee = aliceInPerson as Employee;
             if (aliceAsEmployee != null)
             {
                 WriteLine($"{nameof(aliceInPerson)} AS an employee");
                 // do something with aliceAsEmployee
             }

             // Custom Exception
             try
             {
                 john.TimeTravel(new DateTime(1999, 12, 31));
                 john.TimeTravel(new DateTime(1950, 12, 25));
             }
             catch (PersonException ex)
             {
                 
                WriteLine(ex.Message);
             }

             // Extension Methods
              
             string email1 = "pamela@test.com";
             email1.ExtensionParameter("Test");
             string email2 = "ian&test.com";
             WriteLine("{0} is a valid e-mail address: {1}",arg0: email1, arg1: StringExtensions.IsValidEmail(email1));
             WriteLine("{0} is a valid e-mail address: {1}",arg0: email2, arg1: StringExtensions.IsValidEmail(email2));
            
            // statements to use extension methods
            WriteLine("{0} is a valid e-mail address: {1}",arg0: email1, arg1: email1.IsValidEmail());
            WriteLine("{0} is a valid e-mail address: {1}",arg0: email1, arg1: email2.IsValidEmail());

           
        }

        // Add a method with a matching signature that gets a reference to the Person object
        // from the sender parameter
        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}");

        }

        private static void Receive_Call(object sender, EventArgs e)
        {
            Person person=(Person)sender;
            BossInfoEventArgs eventInfo= (BossInfoEventArgs)e;
            WriteLine($"{person.Name} recieved a call at {eventInfo.CallDateTime} with the following message {eventInfo.Message}");
        }

        // Interfaces IComparable
        
        
    }
}
