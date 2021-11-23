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
                                 Notation.Length==1? (Char.IsUpper(Notation[0]) && Char.IsLower(Notation[2])): Char.IsUpper(Notation[0]) &&
                                 Mass.ToString().IndexOf('.')<=3;


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
