namespace Packt.Shared
{
    public partial class Person
    {
        // a property defined using C# 1 - 5 syntax
       public string Origin
       {
           get
           {
               return $"{Name} was born on {HomePlanet}";
           }
       }

       // two properties defined using C# 6+ lambda expressions syntax 
       public string Greeting => $"{Name} says 'Hello!'";
       public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

       public string FavoriteIceCream { get; set; }

       // when you need more control over a set, you have to create a field
       private string favoritePrimaryColor;
       public string FavoritePrimaryColor
       {
           get
           {
               return favoritePrimaryColor;
           }
           set
           {
               switch (value.ToLower())
               {
                   case "red":
                   case "gree":
                   case "blue":
                   favoritePrimaryColor = value;
                   break;

                   default:
                   throw new System.ArgumentException($"{value} is not a primary color. " + "Choose from: red, green, blue.");
               }

           }

       }

       //indexers
       public Person this[int index]
       {
           get 
           {
               return Children[index];
           }
           set
           {
               Children[index] = value;
           }
       }
        
    }
}