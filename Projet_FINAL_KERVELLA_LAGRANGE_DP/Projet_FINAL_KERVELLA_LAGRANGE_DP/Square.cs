using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_FINAL_KERVELLA_LAGRANGE_DP
{
    class Square
    {
        public int position;

        public int Position { get => position; set => position = value; }

        public Square(int Position)
        {
            this.position = Position;
        }

        public Square() { }
    }
}
