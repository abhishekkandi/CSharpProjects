using System;

namespace CSharp7FeaturesDemo
{
    internal class RefLocalsAndReturns
    {
        private int[] _numberArray = { 1, 2, 3, 4, 5, 6, 7, 9, 10 };

        internal void Run()
        {
            //Ref Locals
            int arrayElementByValue = _numberArray[5];
            arrayElementByValue = 600;
            Console.WriteLine($"6th Element of NumberArray has value of {_numberArray[5]}");

            ref int arrayElementByRef = ref _numberArray[5];
            arrayElementByRef = 600;
            Console.WriteLine($"6th Element of NumberArray has value of {_numberArray[5]}");

            //Ref Returns
            int byValue = getRefOfIndex(4);
            ref int byRef = ref getRefOfIndex(4);

            byValue = 100;
            Console.WriteLine($"byValue: {_numberArray[4]}");

            byRef = 100;
            Console.WriteLine($"byRef: {_numberArray[4]}");
        }

        ref int getRefOfIndex(int index)
        {
            return ref _numberArray[index];
        }
    }
}