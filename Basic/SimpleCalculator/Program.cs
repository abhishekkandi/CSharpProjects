using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InputConvertor inputConvertor = new InputConvertor();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                double firstNumber = inputConvertor.ConvertInputToNumeric(Console.ReadLine());
                double secondNumber = inputConvertor.ConvertInputToNumeric(Console.ReadLine());
                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(operation, firstNumber, secondNumber);

                Console.WriteLine(result);
            }
            catch(Exception ex)
            {
                //In real time application we log exception into log file
                Console.WriteLine(ex.Message);
            }

        }
    }
}
