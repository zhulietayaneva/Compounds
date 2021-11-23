using System;
using System.IO;

namespace Compounds
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\compound.txt");

            foreach (var line in input)
            {
                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var compound = new Compound(tokens[0]);



            }
        }
    }
}
