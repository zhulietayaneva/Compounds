using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compounds
{
    public class Compound
    {
        public string Name { get; private set; }
        public List<Contents> Contents { get; protected set; }
        public bool IsValid() => !(Char.IsUpper(Name[0]));
        public Compound(string formula_name)
        {
            var tokens = formula_name.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Name = tokens[1];
            Contents = new List<Contents>(FillContents(tokens[0]));
        }
        public int AtomCount()
        {
            return Contents.Sum(x => x.count);
        }
        public int ElementCount()
        {
            return Contents.Distinct().Count();
        }

        public double Mass()
        {
            return Math.Round(Contents.Sum(e => e.Element.Mass * e.count),3);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Element GetElement(int n)
        {
            return null;
        }

        private List<Contents> FillContents(string formula)
        {
            var list = new List<Contents>();
            var matches = Regex.Matches(formula, @"[A-Z][a-z]?\d*|\((?:[^()]*(?:\(.*\))?[^()]*)+\)\d+");
            foreach (var match in matches)
            {
                var matchString = match.ToString();
                var singleElementRegex = Regex.Matches(matchString, @"[A-Z][a-z]?\d*");
                var content = new Contents();



                if (matchString.Contains("("))
                {
                    int multiplier = int.Parse(matchString.Substring(matchString.LastIndexOf(")") + 1));

                    foreach (var singleMatch in singleElementRegex)
                    {
                        var elementAsString = singleMatch.ToString();
                        CreateContent(content, elementAsString);
                        content.count *= multiplier;

                    }

                }
                else
                {
                    CreateContent(content, matchString);
                }
                list.Add(content);
            }

            return list;
        }
        private static void CreateContent(Contents content, string elementAsString)
        {
            if (Char.IsLower(elementAsString[1]))
            {
                content.Element = new Element(elementAsString.Substring(0, 2));
                if (elementAsString.Length > 2)
                {
                    content.count = int.Parse(elementAsString.Substring(2));
                }
                else
                {
                    content.count = 1;
                }
            }
            else
            {
                content.Element = new Element(elementAsString.Substring(0, 1));
                if (elementAsString.Length > 1)
                {
                    content.count = int.Parse(elementAsString.Substring(1));
                }
                else
                {
                    content.count = 1;
                }
            }
        }
    }
}

