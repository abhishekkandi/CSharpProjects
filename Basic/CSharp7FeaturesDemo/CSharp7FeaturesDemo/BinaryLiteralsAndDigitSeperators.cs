using System;

namespace CSharp7FeaturesDemo
{
    internal class BinaryLiteralsAndDigitSeperators
    {
        internal void Run()
        {
            byte binaryNumber = 0b111; //0b{binary}
            Console.WriteLine($"Converted Integer: {Convert.ToInt16(binaryNumber)}");

            long veryLongNumber = 100_000_000_000;
            Console.WriteLine($"Digit Seperator output: {veryLongNumber}");
        }
    }
}