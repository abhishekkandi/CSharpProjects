using System;

namespace CSharp7FeaturesDemo
{
    abstract class Person
    {
        public bool IsAngry { get; }

        public Person(bool isAngry) => IsAngry = isAngry;
    }

    class NormalPerson : Person
    {
        public NormalPerson(bool isAngry) : base(isAngry)
        {

        }
    }

    class SuperPerson : Person
    {
        public SuperPerson(bool isAngry) : base(isAngry)
        {

        }
    }

    internal class PatternMatching
    {
        internal void Run()
        {
            Person normalPerson = new NormalPerson(false);
            Person superPerson = new NormalPerson(true);

            BreakTheWall(normalPerson);
            BreakTheWall(superPerson);

            WhatCanYouBreak(normalPerson);
            WhatCanYouBreak(superPerson);
            WhatCanYouBreak(null);
        }

        private void BreakTheWall(Person person)
        {
            //Older way
            //if(person is SuperPerson)
            //{
            //    SuperPerson newPerson1 = person as SuperPerson;
            //}

            //New way
            if(person is SuperPerson superPerson || person is NormalPerson normalPerson && normalPerson.IsAngry)
            {
                Console.WriteLine("Wall broke");
            }
            else
            {
                Console.WriteLine("Wall didn't break!");
            }
        }

        private void WhatCanYouBreak(Person person)
        {
            switch (person)
            {
                default:
                    //In C# 7.0 -> Default can be anywhere(top, bottom, middle). But it will be executed only after all the cases.
                    Console.WriteLine("Nothing broke.");
                    break;
                case SuperPerson superPerson when superPerson.IsAngry:
                    Console.WriteLine("Can break stone wall, titanium wall.");
                    break;
                case SuperPerson superPerson:
                    Console.WriteLine("Can break the stone wall.");
                    break;
                case NormalPerson normalPerson when normalPerson.IsAngry:
                    Console.WriteLine("Can break the stone wall.");
                    break;
                case NormalPerson normalPerson:
                    Console.WriteLine("Cannot break stone wall.");
                    break;
                case null:
                    Console.WriteLine("The wall will stay as it is since nobody will be hitting it.");
                    break;
            }
        }

        
    }
}