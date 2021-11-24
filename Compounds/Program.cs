using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compounds
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines(@"..\..\..\compound.txt");
            var compoundsList = new List<Compound>();
            foreach (var line in input)
            {
                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var compound = new Compound(line);

                compoundsList.Add(compound);

            }
            var flattened = compoundsList.Where(e=>e.IsValid()).Select(e => new
                                                {
                                                   Contents= e.Contents,
                                                   Elements = e.Contents.Select(e=>e.Element).Where(e=>e.IsValid()).ToList(),
                                                   CompoundName=e.Name,
                                                   Mass=e.Mass(),
                                                   AtomCount=e.AtomCount(),
                                                   Compound=e
                                                }).ToList();
            var elementsOnly = new List<Element>();
            elementsOnly.AddRange(flattened.SelectMany(e => e.Elements).OrderBy(e=>e.Notation).Distinct().ToList());
            for (int i = 0; i < elementsOnly.Count; i++)
            {
                var element = elementsOnly[i];

                Console.WriteLine($"Input data for {element.Notation}");
                Console.WriteLine($"Kind (1-metal,2-nonmetal,3-metalloid):  ");
                int type = int.Parse(Console.ReadLine());
                Console.WriteLine($"Atomic mass: ");
                double mass = double.Parse(Console.ReadLine());

                switch (type)
                {

                    case 1:
                        element = new Metal(element.Notation, mass);
                        break;
                    case 2:
                        element = new Nonmetal(element.Notation, mass);
                        break;
                    case 3:
                        element = new Metaloid(element.Notation, mass);
                        break;
                    default:
                        Console.WriteLine("Invalid kind.");
                        break;
                }

            }

            foreach (var compound in flattened)
            {
                compound.Elements.Select(e => e = elementsOnly.Find(e2=>e2.Notation==e.Notation));
                 

            }
            var res = flattened.Select(e => e.Compound).OrderBy(e => e.AtomCount()).ThenBy(e => e.Mass()).ToList();
            foreach (var item in res)
            {
                Console.WriteLine(item.Name);
            }
        }

    }
}
