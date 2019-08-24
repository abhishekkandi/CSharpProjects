using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp7FeaturesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryLiteralsAndDigitSeperators binaryLiteralsAndDigitSeperators = new BinaryLiteralsAndDigitSeperators();
            binaryLiteralsAndDigitSeperators.Run();

            RefLocalsAndReturns refLocalsAndReturns = new RefLocalsAndReturns();
            refLocalsAndReturns.Run();

            Deconstruction deconstruction = new Deconstruction();
            deconstruction.Run();

            PatternMatching patternMatching = new PatternMatching();
            patternMatching.Run();

            Tuples tuples = new Tuples();
            tuples.Run();
        }
    }
}
