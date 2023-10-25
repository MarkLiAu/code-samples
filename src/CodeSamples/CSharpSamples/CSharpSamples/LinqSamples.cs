using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    public class LinqSamples
    {
        public static void RunSample()
        {
            //GroupBySample1();
            //GroupBySample2();
            GroupByEx4();
        }

        record Student(string FirstName, string LastName, int Age, double[] ExamScores);

        static List<Student> Students = new List<Student>()
        {
            new Student("fname1", "lname1", 21, new double[] {86,77,91,90}),
            new Student("fname2", "lname2", 22, new double[] {86,77,92,90}),
            new Student("fname3", "lname3", 23, new double[] {96,77,93,90}),
            new Student("fname4", "lname4", 23, new double[] {66,77,94,90}),
            new Student("fname5", "lname5", 23, new double[] {86,77,95,90}),
            new Student("fname6", "lname6", 22, new double[] {79,77,96,90}),
        };

        static void GroupBySample1()
        {
            var g1 = Students.GroupBy(x=>x.Age).ToList();
            foreach(var g in g1)
            {
                Console.WriteLine(g.Key);
                foreach(var d in g)
                {
                    Console.WriteLine(d);
                }
            }
        }
        static void GroupBySample2()
        {
            var g1 = Students.GroupBy(x => x.Age, 
                                      (k,g) => new {Age=k, Count=g.Count()}                    
                ).ToList();
            foreach (var g in g1)
            {
                Console.WriteLine(g);
            }
        }

        class Pet
        {
            public string Name { get; set; }
            public double Age { get; set; }
        }

        public static void GroupByEx4()
        {
            // Create a list of pets.
            List<Pet> petsList =
                new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                       new Pet { Name="Boots", Age=4.9 },
                       new Pet { Name="Whiskers", Age=1.5 },
                       new Pet { Name="Daisy", Age=4.3 } };

            // Group Pet.Age values by the Math.Floor of the age.
            // Then project an anonymous type from each group
            // that consists of the key, the count of the group's
            // elements, and the minimum and maximum age in the group.
            var query = petsList.GroupBy(
                pet => Math.Floor(pet.Age),
                pet => pet.Age,
                (baseAge, ages) => new
                {
                    Key = baseAge,
                    Count = ages.Count(),
                    Min = ages.Min(),
                    Max = ages.Max()
                });

            // Iterate over each anonymous type.
            foreach (var result in query)
            {
                Console.WriteLine("\nAge group: " + result.Key);
                Console.WriteLine("Number of pets in this age group: " + result.Count);
                Console.WriteLine("Minimum age: " + result.Min);
                Console.WriteLine("Maximum age: " + result.Max);
            }

            /*  This code produces the following output:

                Age group: 8
                Number of pets in this age group: 1
                Minimum age: 8.3
                Maximum age: 8.3

                Age group: 4
                Number of pets in this age group: 2
                Minimum age: 4.3
                Maximum age: 4.9

                Age group: 1
                Number of pets in this age group: 1
                Minimum age: 1.5
                Maximum age: 1.5
            */
        }
    }
}
