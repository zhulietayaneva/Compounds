using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compounds
{
    public class Element
    {
        public string Notation { get; private set; }
        public double Mass { get; protected set; }

        public bool IsValid() => Notation.Length <= 2 &&
                                 Notation.Length == 1 && Char.IsUpper(Notation[0]) ? true : Notation.Length == 2 && Char.IsLower(Notation[1]) ? true : false;


        public Element(string notation)
        {
            Notation = notation;
        }

        public override string ToString()
        {
            return base.ToString();
        }



    }
}
