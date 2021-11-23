using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compounds
{
    public class Compound
    {
        public string Name { get; private set; }
        public List<Contents> Contents { get; private set; }

        public Compound(string formula_name)
        {
            Name = formula_name;
        }
        public int AtomCount()
        {
            return Contents.Count();
        }

        public int ElementCount()
        {
            return Name.Distinct().Count(x => Char.IsUpper(x));
        }

        public double Mass()
        {
            return 0;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Element GetElement(int n)
        {
            return null;
        }

        protected List<Contents> FillContents()
        {
            for (int i = Name.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(Name[i]))
                {
                    //(?<gr1>[A-Z][a-z]?[\d]?)|(\((?(<gr1>))+\)[d]+)
                    /*Fe(SO4)3
                    H20
                    BrI
                    BrClH2Si
                    CCl4
                    CH3I
                    C2H5Br
                    H2O4S
                    Mg(OH)2
                    Al2(SO4)3
                    (NH4)2SO4*/
                }

                var test = Regex.Match()

}
        }


    }
}
