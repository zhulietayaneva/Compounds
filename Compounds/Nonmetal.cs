using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compounds
{
    class Nonmetal : Element
    {

        public Nonmetal(string notation, double m) : base(notation)
        {
            base.Mass = m;
        }
    }
}
