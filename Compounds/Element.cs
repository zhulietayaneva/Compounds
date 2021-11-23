using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compounds
{
   public class Element: Compound
    {
        public string Notation { get; set; }
        public double Mass { get; set; }


        public Element(string notation)
        {
            Notation = notation;
        }



    }
}
