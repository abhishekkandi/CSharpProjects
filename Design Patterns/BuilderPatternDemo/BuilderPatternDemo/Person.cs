using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPatternDemo
{
    class Person
    {
        public Person(string FirstName, string LastName, int Age, int EyeColor, int HairColor)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.EyeColor = EyeColor;
            this.HairColor = HairColor;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int EyeColor { get; set; }
        public int HairColor { get; set; }
    }
}
