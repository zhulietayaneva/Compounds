using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compounds
{
    class Metal : Element
    {

        public Metal(string notation, double m) : base(notation)
        {
            base.Mass = m;
        }
    }
}
