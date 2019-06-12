using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DotNetDesignPatternDemos.SOLID.SRP
{
    /* SOLID Principles */
    /* S - Single Responsibility Principle - */

    /*Just stores a couple of journal entries 
     * and ways of working with them */
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        //Break Single Responsiblity Prinicple
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }
    }

    //Handles the responsiblity of Persisting objects
    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, journal.ToString());
        }
    }

    public class SRPDemo
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I wrote an API to fetch Documents.");
            j.AddEntry("I need to finish API integration by tomorrow.");
            WriteLine(j);

            var p = new Persistence();
            var filename = @"C:\Users\Abhishek kandi\Desktop\journal.txt";
            p.SaveToFile(j, filename);
            Process.Start(filename);

            ReadLine();
        }
    }
}
