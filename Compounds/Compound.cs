using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        }

        public int ElementCount()
        {
            return Name.Count(x => Char.IsUpper(x));
        }

        public double Mass()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Element GetElement(int n)
        {

        }


    }
}
