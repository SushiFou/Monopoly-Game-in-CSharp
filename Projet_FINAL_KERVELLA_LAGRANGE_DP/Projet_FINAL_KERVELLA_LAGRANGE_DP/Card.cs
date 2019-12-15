using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_FINAL_KERVELLA_LAGRANGE_DP
{
    public enum Type_Card { Chance, Community_Chest }

    class Card: Square
    {
        public Type_Card type; // type of card
        public int what; // what the card says

        public Type_Card Type { get => type; set => type = value; }
        public int What { get => what; set => what = value; }

        public Card(Type_Card type, int position) : base(position)
        {
            this.type = type;
            this.what = RandomInt();
            this.position = position;
        }

        public int RandomInt()
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 8);
            return result;
        }

        public int RandomCash()
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 1000);
            return result;
        }

        public string CardInstruction(int what, int rand_cash, int rand_int)
        {
            if (what == 1) { return "Get out of jail"; }
            else if (what == 2) { return "Pay $" + rand_cash + " to the player who played before you"; }
            else if (what == 3) { return "Pay $" + rand_cash + " for taxes"; }
            else if (what == 4) { return "Receive $" + rand_cash + " from the bank"; }
            else if (what == 5) { return "Move " + rand_int + " squares forward"; }
            else if (what == 6) { return "Move " + rand_int + " squares backward"; }
            else if (what == 7) { return "Go to jail"; }
            else { return "There was an error please try again"; }
        }
    }
}
