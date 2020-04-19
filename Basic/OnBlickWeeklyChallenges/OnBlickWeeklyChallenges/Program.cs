using OnBlickWeeklyChallenges;
using System;
using System.Text;

namespace OnBlickWeeklyChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select your option: ");
            
            var options = new StringBuilder();
            options.Append($"1. Multiple Instance Differentiator {Environment.NewLine}");

            Console.WriteLine(options.ToString());

            string selectedOption = Console.ReadLine();
            int choice = 0;

            if(int.TryParse(selectedOption,out choice)) 
            {
                switch (choice)
                {
                    case 1:
                        MultipleInstanceDifferentiator.Run();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
