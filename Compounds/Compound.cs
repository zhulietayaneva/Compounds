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
            Name = formula_name.Substring(formula_name.IndexOf(" ")+1);
            Contents = new List<Contents>(FillContents(formula_name.Substring(0,formula_name.IndexOf(" ")+1)));
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
            return Math.Round(Contents.Sum(e => e.Element.Mass * e.count), 3);
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
                var content = new Contents();

                if (matchString.Contains("("))
                {
                    int multiplier = int.Parse(matchString.Substring(matchString.LastIndexOf(")") + 1));
                    var singleElementRegex = Regex.Matches(matchString, @"[A-Z][a-z]?\d*");
                    foreach (var singleMatch in singleElementRegex)
                    {
                        var elementAsString = singleMatch.ToString();
                        CreateContent(content, elementAsString);
                        content.count *= multiplier;
                        list.Add(content);

                    }

                }
                else
                {
                    CreateContent(content, matchString);
                    list.Add(content);
                }
                
            }

            return list;
        }
        private static void CreateContent(Contents content, string elementAsString)
        {
            var indexOfCount = elementAsString.IndexOfAny("0123456789".ToCharArray());
            if (indexOfCount > 0)
            {
                content.Element = new Element(elementAsString.Substring(0, indexOfCount));
                content.count = int.Parse(elementAsString.Substring(indexOfCount));
            }
            else
            {
                content.Element = new Element(elementAsString);
                content.count = 1;
            }

        }
    }
}

