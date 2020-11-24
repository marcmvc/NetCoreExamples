using System.Collections.Generic;

namespace Packt.Shared
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            // Compare the name lenghts...
            int result = x.Name.Length.CompareTo(y.Name.Length);
            /// ... if they are equal...
            if (result == 0)
            {
                // ..then compare by Names
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                // ..otherwise compare by the lenghts
                return result;
            }
        }
    }
}