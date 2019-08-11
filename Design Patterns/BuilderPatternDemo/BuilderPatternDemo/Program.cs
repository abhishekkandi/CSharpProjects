using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new PersonBuilder().Build();

            Person person2 = new PersonBuilder().WithFirstName("Walter").WithAge(35).Build();

            Person person3 = new PersonBuilder().WithAge(39).Build();

            Person[] persons = { person1, person2, person3 };

            foreach(var person in persons)
            {
                Console.WriteLine($"Firs tName: {person.FirstName}");
                Console.WriteLine($"Last Name: {person.LastName}");
                Console.WriteLine($"Age: {person.Age}");
                Console.WriteLine($"Eye Color: {person.EyeColor}");
                Console.WriteLine($"Hair Color: {person.HairColor}");
                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
}
