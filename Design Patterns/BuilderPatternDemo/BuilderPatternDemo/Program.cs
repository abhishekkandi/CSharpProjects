using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BuilderPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new PersonBuilder().Build();

            Person person2 = new PersonBuilder().WithFirstName("Walter").WithAge(35).Build();

            Person person3 = new PersonBuilder().WithFirstName("Aaron").WithAge(39).Build();

            Person[] persons = { person1, person2, person3 };

            foreach(var person in persons)
            {
                WriteLine($"Firs tName: {person.FirstName}");
                WriteLine($"Last Name: {person.LastName}");
                WriteLine($"Age: {person.Age}");
                WriteLine($"Eye Color: {person.EyeColor}");
                WriteLine($"Hair Color: {person.HairColor}");
                WriteLine("");
            }

            ReadKey();
        }
    }
}
