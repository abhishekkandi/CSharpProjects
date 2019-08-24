using System;

namespace CSharp7FeaturesDemo
{
    internal class Tuples
    {
        internal void Run()
        {
            Tuple<string, string, int> oldTuple = getOldTuple();
            Console.WriteLine($"{oldTuple.Item1} {oldTuple.Item2} {oldTuple.Item3}");

            //Unnamed Tuple
            var newUnnamedTuple = getNewUnnamedTuple();
            Console.WriteLine($"{newUnnamedTuple.Item1} {newUnnamedTuple.Item2} {newUnnamedTuple.Item3}");

            var (FirstNameV1, LastNameV1, AgeV1) = getNewUnnamedTuple();
            Console.WriteLine($"{FirstNameV1} {LastNameV1} {AgeV1}");

            (var FirstNameV2, var LastNameV2, var AgeV2) = getNewUnnamedTuple();
            Console.WriteLine($"{FirstNameV2} {LastNameV2} {AgeV2}");

            (string FirstNameV3, string LastNameV3, int AgeV3) = getNewUnnamedTuple();
            Console.WriteLine($"{FirstNameV3} {LastNameV3} {AgeV3}");

            //Named Tuple 
            var (FirstNameV4, LastNameV4, AgeV4) = getNewNamedTuple();
            Console.WriteLine($"{FirstNameV4} {LastNameV4} {AgeV4}");

            (string FirstNameV5,string LastNameV5,int AgeV5) = getNewNamedTuple();
            Console.WriteLine($"{FirstNameV5} {LastNameV5} {AgeV5}");

            var newNamedTuple = getNewNamedTuple();
            Console.WriteLine($"{newNamedTuple.FirstName} {newNamedTuple.LastName} {newNamedTuple.Age}");

        }

        private (string FirstName, string LastName, int Age) getNewNamedTuple()
        {
            return ("Mark", "Wilson", 30);
        }

        private (string,string,int) getNewUnnamedTuple()
        {
            return ("Mark", "Wilson", 30);
        }

        private Tuple<string, string, int> getOldTuple()
        {
            return Tuple.Create("Mark", "Wilson", 30);
        }
    }
}