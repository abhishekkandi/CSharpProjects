using System;

namespace SimpleCalculator
{
    internal class CalculatorEngine
    {
        internal double Calculate(string argOperation, double argFirstNumber, double argSecondNumber)
        {
            double result;

            switch (argOperation.ToLower())
            {
                case "add":
                case "+":
                    result = argFirstNumber + argSecondNumber;
                    break;
                case "subtract":
                case "-":
                    result = argFirstNumber - argSecondNumber;
                    break;
                case "divide":
                case "/":
                    result = argFirstNumber / argSecondNumber;
                    break;
                case "multiply":
                case "*":
                    result = argFirstNumber * argSecondNumber;
                    break;
                default:
                    throw new InvalidOperationException("Specified operation is not recognized.");
            }

            return result;
        }
    }
}