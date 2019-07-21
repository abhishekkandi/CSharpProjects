using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test.Unit
{
    /*
        Three Steps of Unit Testing 
        1) Setting up the data
        2) Processing the data through the method which you want to test
        3) Comparing the result from the process with expected result 
    */

    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorEngine = new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("add", number1, number2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate("+", number1, number2);
            Assert.AreEqual(3, result);
        }
    }
}
