using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadAndWriteFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = {
                                "This is the first line",
                                "This is the second line",
                                "This is the third line",
                             };

            File.WriteAllLines("MyFirstFile.txt", lines);

            string[] fileContents = File.ReadAllLines("MyFirstFile.txt");

            foreach(string line in File.ReadLines("MyFirstFile.txt"))
            {
                Console.WriteLine(line);
            }
        }
    }
}
