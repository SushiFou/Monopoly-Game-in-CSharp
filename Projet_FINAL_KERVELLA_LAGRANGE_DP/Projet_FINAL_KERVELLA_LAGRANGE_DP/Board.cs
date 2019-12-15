using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_FINAL_KERVELLA_LAGRANGE_DP
{
    class Board
    {
        private static Board instance = null;
        public Square[] board= new Square[40];
        private static readonly object padlock = new object();

        public Board()
        {
            CreateBoard();  
        }

        public static Board Instance
        {
            get 
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Board();
                    }
                    return instance;
                }
            }
        }


        public void CreateBoard()
        {
            CardFactory cardf1 = new CardFactory(Type_Card.Community_Chest);
            CardFactory cardf2 = new CardFactory(Type_Card.Chance);

            board[0] = new Square(); // start: collect $200 as you pass
            board[1] = new Property("Mediterranean Avenue", Type_Property.Street, 60, 0, Property_Situation.Free, null, 1);
            board[2] = cardf1.GetSquare(2);
            board[3] = new Property("Baltic Avenue", Type_Property.Street, 60, 0, Property_Situation.Free, null, 3);
            board[4] = new Square(); // income tax (pay $200)
            board[5] = new Property("Reading Railroad", Type_Property.Train_Station, 200, 0, Property_Situation.Free, null, 5);
            board[6] = new Property("Oriental Avenue", Type_Property.Street, 100, 0, Property_Situation.Free, null, 6);
            board[7] = cardf2.GetSquare(7);
            board[8] = new Property("Vermont Avenue", Type_Property.Street, 100, 0, Property_Situation.Free, null, 8);
            board[9] = new Property("Connecticut Avenue", Type_Property.Street, 120, 0, Property_Situation.Free, null, 9);
            board[10] = new Square(); //jail
            board[11] = new Property("St. Charles Place", Type_Property.Street, 140, 0, Property_Situation.Free, null, 11);
            board[12] = new Property("Electric Company", Type_Property.Service, 150, 0, Property_Situation.Free, null, 12);
            board[13] = new Property("States Avenue", Type_Property.Street, 140, 0, Property_Situation.Free, null, 13);
            board[14] = new Property("Virginia Avenue", Type_Property.Street, 160, 0, Property_Situation.Free, null, 14);
            board[15] = new Property("Pennsylvania Railroad", Type_Property.Train_Station, 200, 0, Property_Situation.Free, null, 15);
            board[16] = new Property("St. James Place", Type_Property.Street, 180, 0, Property_Situation.Free, null, 16);
            board[17] = cardf2.GetSquare(17);
            board[18] = new Property("Tennessee Avenue", Type_Property.Street, 180, 0, Property_Situation.Free, null, 18);
            board[19] = new Property("New York Avenue", Type_Property.Street, 200, 0, Property_Situation.Free, null, 19);
            board[20] = new Square(); // free parking
            board[21] = new Property("Kentucky Avenue", Type_Property.Street, 220, 0, Property_Situation.Free, null, 21);
            board[22] = cardf1.GetSquare(22);
            board[23] = new Property("Indiana Avenue", Type_Property.Street, 220, 0, Property_Situation.Free, null, 23);
            board[24] = new Property("Illinois Avenue", Type_Property.Street, 240, 0, Property_Situation.Free, null, 24);
            board[25] = new Property("B. & O. Railroad", Type_Property.Train_Station, 200, 0, Property_Situation.Free, null, 25);
            board[26] = new Property("Atlantic Avenue", Type_Property.Street, 260, 0, Property_Situation.Free, null, 26);
            board[27] = new Property("Ventnor Avenue", Type_Property.Street, 260, 0, Property_Situation.Free, null, 27);
            board[28] = new Property("Water Works", Type_Property.Service, 150, 0, Property_Situation.Free, null, 28);
            board[29] = new Property("Marvin Gardens", Type_Property.Street, 280, 0, Property_Situation.Free, null, 29);
            board[30] = new Square(); // go to jail
            board[31] = new Property("Pacific Avenue", Type_Property.Street, 300, 0, Property_Situation.Free, null, 31);
            board[32] = new Property("North Carolina Avenue", Type_Property.Street, 300, 0, Property_Situation.Free, null, 32);
            board[33] = cardf1.GetSquare(33);
            board[34] = new Property("Pennsylvania Avenue", Type_Property.Street, 320, 0, Property_Situation.Free, null, 34);
            board[35] = new Property("Short Line", Type_Property.Train_Station, 200, 0, Property_Situation.Free, null, 35);
            board[36] = cardf2.GetSquare(36);
            board[37] = new Property("Park Place", Type_Property.Street, 350, 0, Property_Situation.Free, null, 37);
            board[38] = new Square(); // luxury tax (pay $100)
            board[39] = new Property("Boardwalk", Type_Property.Street, 400, 0, Property_Situation.Free, null, 38);
        }

    }
}
