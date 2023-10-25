using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    public class RecordsSamples
    {
        public static void RunSamples()
        {
            DisplayPerson();
            DisplayWith();
        }

        public record Person(string FirstName, string LastName);

        public static void DisplayPerson()
        {
            Person person = new("Nancy", "Davolio");
            Console.WriteLine(person);
            // output: Person { FirstName = Nancy, LastName = Davolio }
        }

        #region With expressions
        public record Point(int X, int Y)
        {
            public int Zbase { get; set; }
        };
        public record NamedPoint(string Name, int X, int Y) : Point(X, Y)
        {
            public int Zderived { get; set; }
        };

        public static void DisplayWith()
        {
            Point p1 = new NamedPoint("A", 1, 2) { Zbase = 3, Zderived = 4 };
            Console.WriteLine(p1);
            Console.WriteLine(p1 is Point); 
            Console.WriteLine(p1 is NamedPoint); 

            Point p2 = p1 with { X = 5, Y = 6, Zbase = 7 }; // Can't set Name or Zderived
            Console.WriteLine(p2 is NamedPoint);  // output: True
            Console.WriteLine(p2);
            // output: NamedPoint { X = 5, Y = 6, Zbase = 7, Name = A, Zderived = 4 }

            Point p3 = (NamedPoint)p1 with { Name = "B", X = 5, Y = 6, Zbase = 7, Zderived = 8 };
            Console.WriteLine(p3);
            // output: NamedPoint { X = 5, Y = 6, Zbase = 7, Name = B, Zderived = 8 }
        }
        #endregion
    }
}
