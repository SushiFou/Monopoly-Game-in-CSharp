using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_FINAL_KERVELLA_LAGRANGE_DP
{
    class Game
    {
        public List<Player> players = new List<Player>(); // who is playing
        public Board board_game = new Board();
        public int rounds; // number of rounds played
        public Player winner;

        public Game() { }

        public bool IsWinner()
        {
            int compt2 = 0;
            Player pl = new Player();
            for(int i =0; i<players.Count;i++)
            {
                if (players[i].money != 0) { pl = players[i]; compt2++; }
            }
            if (compt2 == 1) { winner = pl; return true; }
            int j = 0;
            foreach(Player p in players)
            {
                if (p.loser == false) { winner = p; j++; }
            }
            if (j == 1) {return true; }
            else { return false; }
        }

        public void Create()
        {
            Console.WriteLine("Welcome!");
            int nbpl = 0;
            while (nbpl < 2 || nbpl > 6)
            {
                Console.WriteLine("How many players (2-6)?");
                nbpl = int.Parse(Console.ReadLine());
            }
            for(int i = 0; i < nbpl; i++)
            {
                Console.WriteLine("Player " + (i + 1) + ":");
                Console.Write("Username: ");
                string name = Console.ReadLine();
                Player temppl = new Player(name);
                players.Add(temppl);
                Console.WriteLine("\nThe player was successfully added!\n");
            }
            Console.WriteLine("\nPlayers:");
            for(int i = 0; i < nbpl; i++)
            {
                Console.WriteLine("\n" + players[i].toString());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress any key to start the game !\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
        }

        public void Start()
        {
            int compt = 0;
            Console.Clear();
            Console.WriteLine("The game is starting!");
            while (!IsWinner())
            {
                Console.Clear();
                rounds++;
                while (players[compt].loser)
                {
                    if (compt == players.Count - 1)
                    {
                        compt = 0;
                    }
                    else
                    {
                        compt++;
                    }
                }
                Player current = players[compt];
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPlayer " + current.Name + ":");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to roll the dices !\n");
                Console.ReadKey(true);
                int[] dices= current.RollDices();
                int nbdouble = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                current.Move(dices[0] + dices[1]);
                Console.WriteLine("\nCurrent position :" + current.position + "\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey(true);
                DisplayMenu(current, compt, true);
                while (current.DoubleBool(dices))
                {
                    nbdouble++;
                    if (nbdouble == 3)
                    {
                        Console.WriteLine("You rolled a double for the third time in a row. You must go to jail.");
                        current.jail = true;
                        current.position = 10;
                        Console.WriteLine("You are now in jail.\n");
                        Console.ReadKey(true);
                        break;
                    }                    
                    Console.WriteLine("\nWow, you got a double, you can roll the dices again !");
                    Console.WriteLine("\nPress any key to roll the dices !\n");
                    Console.ReadKey(true);
                    dices = current.RollDices();
                    current.Move(dices[0] + dices[1]);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCurrent position :" + current.position + "\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey(true);
                    DisplayMenu(current, compt, true);                    
                }
                if(compt==players.Count-1)
                {
                    compt = 0;
                }
                else
                {
                    compt++;
                }
            }
            Console.WriteLine("Gagnant :" + winner.Name);
            Console.ReadKey(true);
        }

        public void DisplayMenu(Player player, int compt, bool pos)
        {
            Console.Clear();
            if (pos)
            {
                DisplayPosition(player, compt);
            }
            int resp = 0;
            Console.WriteLine("\nPlease Make a Selection :\n");
            Console.WriteLine("0 : Game Status");
            Console.WriteLine("1 : Finish Turn");
            Console.WriteLine("2 : Your DashBoard");
            Console.WriteLine("3 : Purchase the property");
            Console.WriteLine("4 : Buy House for property");
            Console.WriteLine("5 : Buy Hotel for property");
            Console.WriteLine("6 : Declare Bankrupt");
            Console.WriteLine("7 : Quit Game");
            Console.Write("(1-7)>");
            try
            {
                resp = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                this.DisplayMenu(player, compt, true);
            }

            switch(resp)
            {
                case 0:
                    Console.WriteLine("Game Status :");
                    for (int i = 0; i < players.Count; i++)
                    {
                        Console.WriteLine("\n" + players[i].toString());
                    }
                    Console.ReadKey();
                    Console.Clear();
                    DisplayMenu(player, compt, pos);
                    break;
                case 1:
                    break;
                case 2:
                    Dashboard(player, compt);
                    break;
                case 3:
                    PurchaseProperty(player, compt);
                    break;
                case 4:
                    BuyHouseProperty(player, compt);
                    break;
                case 5:
                    BuyHotelProperty(player, compt);
                    break;
                case 6:
                    player.loser = true;
                    break;
                case 7:
                    player.money = 0;
                    player.loser = true;
                    break;
            }
        }

        public void DisplayPosition(Player player, int compt)
        {
            Property p = new Property("", Type_Property.Street, 0, 0, Property_Situation.Free, null, 0);
            BoughtProperty bp = new BoughtProperty(p, null);
            HouseProperty hsp = new HouseProperty(bp, null);
            HotelProperty htp = new HotelProperty(hsp, null);
            Card c = new Card(Type_Card.Chance, 0);
            Square s = new Square();
            Console.WriteLine("The square you are currently on is the following:");
            if (board_game.board[player.position].GetType() == p.GetType())
            {
                p = (Property)board_game.board[player.position];
                Console.WriteLine(p.toString());
            }
            else if(board_game.board[player.position].GetType() == bp.GetType())
            {
                bp = (BoughtProperty)board_game.board[player.position];
                Console.WriteLine(bp.toStringOwner());
                if (bp.owner != player)
                {
                    Console.WriteLine("\nYou must pay $" + bp.taxes + " to the owner of this property (" + bp.owner.name + ")");
                    if (player.money < bp.taxes)
                    {
                        Console.WriteLine("You do not have enough money. You lost.");
                        player.loser = true;
                        player.money = 0;
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                    else
                    {
                        player.money -= bp.taxes;
                        bp.owner.money += bp.taxes;
                        Console.WriteLine("You now have $" + player.money);
                        Console.WriteLine("The owner (" + bp.owner.name + ") now has $" + bp.owner.money);
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                }
            }
            else if (board_game.board[player.position].GetType() == hsp.GetType())
            {
                hsp = (HouseProperty)board_game.board[player.position];
                Console.WriteLine(hsp.toStringOwner());
                if (hsp.owner != player)
                {
                    Console.WriteLine("\nYou must pay $" + hsp.taxes + " to the owner of this property (" + hsp.owner.name + ")");
                    if (player.money < hsp.taxes)
                    {
                        Console.WriteLine("You do not have enough money. You lost.");
                        player.loser = true;
                        player.money = 0;
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                    else
                    {
                        player.money -= hsp.taxes;
                        hsp.owner.money += hsp.taxes;
                        Console.WriteLine("You now have $" + player.money);
                        Console.WriteLine("The owner (" + hsp.owner.name + ") now has $" + hsp.owner.money);
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                }
            }
            else if (board_game.board[player.position].GetType() == htp.GetType())
            {
                htp = (HotelProperty)board_game.board[player.position];
                Console.WriteLine(htp.toStringOwner());
                if (htp.owner != player)
                {
                    Console.WriteLine("\nYou must pay $" + htp.taxes + " to the owner of this property (" + htp.owner.name + ")");
                    if (player.money < htp.taxes)
                    {
                        Console.WriteLine("You do not have enough money. You lost.");
                        player.loser = true;
                        player.money = 0;
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                    else
                    {
                        player.money -= htp.taxes;
                        htp.owner.money += htp.taxes;
                        Console.WriteLine("You now have $" + player.money);
                        Console.WriteLine("The owner (" + htp.owner.name + ") now has $" + htp.owner.money);
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                }
            }
            else if (board_game.board[player.position].GetType() == c.GetType())
            {
                c = (Card)board_game.board[player.position];
                Console.WriteLine(c.type.ToString() + " card!");
                CardSquare(c, player, compt);
            }
            else if (board_game.board[player.position].GetType() == s.GetType())
            {
                EmptySquare(player, compt);
            }
        }

        public void CardSquare(Card c, Player player, int compt)
        {
            Console.Write("The card says:");
            int rand_cash = c.RandomCash();
            int rand_int = c.RandomInt();
            Console.WriteLine("'" + c.CardInstruction(c.what, rand_cash, rand_int) + "'");
            if (c.what == 1)
            {
                if (player.jail)
                {
                    Console.WriteLine("This card allows you to get out of jail. You are now free.");
                    player.jail = false;
                }
                else
                {
                    Console.WriteLine("You are not currently in jail. You can keep this card for later.");
                    player.get_out_of_jail_card = true;
                }
            }
            else if (c.what == 2)
            {
                if (rounds < 2)
                {
                    Console.WriteLine("It is your lucky day: nobody played before you! You do not have to pay anything.");
                }
                else
                {
                    if (player.money < rand_cash)
                    {
                        Console.WriteLine("You do not have enough money to pay. You lost.");
                        player.loser = true;

                    }
                    else
                    {
                        players[compt - 1].money += rand_cash;
                        player.money -= rand_cash;
                        Console.WriteLine("You have given $" + rand_cash + " to " + players[compt].name);
                        Console.WriteLine("You now have $" + player.money);
                    }
                }
            }
            else if (c.what == 3)
            {
                if (player.money < rand_cash)
                {
                    Console.WriteLine("You do not have enough money to pay. You lost.");
                    player.loser = true;

                }
                else
                {
                    player.money -= rand_cash;
                    Console.WriteLine("You have paid $" + rand_cash + " for taxes.");
                    Console.WriteLine("You now have $" + player.money);
                }
            }
            else if (c.what == 4)
            {
                player.money += rand_cash;
                Console.WriteLine("You have received $" + rand_cash + " from the bank.");
                Console.WriteLine("You now have $" + player.money);
            }
            else if (c.what == 5)
            {
                player.Move(rand_int);
                Console.WriteLine("Your current position is now: " + player.position);
            }
            else if (c.what == 6)
            {
                player.MoveBackward(rand_int);
                Console.WriteLine("Your current position is now: " + player.position);
            }
            else if (c.what == 7)
            {
                player.position = 10;
                player.jail = true;
                Console.WriteLine("You are now in jail.");
            }
            Console.WriteLine("\nPress any key to go back to the menu.");
            Console.ReadKey(true);
        }

        public void EmptySquare(Player player, int compt)
        {
            if (player.position == 0)
            {
                Console.WriteLine("\nStart square!");
            }
            else if (player.position == 4)
            {
                Console.WriteLine("Income taxes!\nYou have to pay $200.");
                if (player.money < 200)
                {
                    Console.WriteLine("\nYou do not have enough money. You lost.");
                    player.loser = true;
                    Console.WriteLine("\nPress any key to go back to the menu.");
                    Console.ReadKey(true);
                    DisplayMenu(player, compt, false);
                }
                else
                {
                    player.money -= 200;
                    Console.WriteLine("You now have $" + player.money);
                    Console.WriteLine("\nPress any key to go back to the menu.");
                    Console.ReadKey(true);
                    DisplayMenu(player, compt, false);
                }
            }
            else if (player.position == 10)
            {
                Console.WriteLine("\nJail square! But don't worry you are only visiting.");
            }
            else if (player.position == 20)
            {
                Console.WriteLine("\nFree parking!");
            }
            else if (player.position == 30)
            {
                Console.WriteLine("\nGo to jail!");
                player.jail = true;
                player.position = 10;
                Console.WriteLine("You are now in jail.");
                Console.WriteLine("\nPress any key to go back to the menu.");
                Console.ReadKey(true);
                DisplayMenu(player, compt, false);
            }
            else if (player.position == 38)
            {
                Console.WriteLine("Luxury taxes!\nYou have to pay $100.");
                if (player.money < 100)
                {
                    Console.WriteLine("\nYou do not have enough money. You lost.");
                    player.loser = true;
                    Console.WriteLine("\nPress any key to go back to the menu.");
                    Console.ReadKey(true);
                    DisplayMenu(player, compt, false);
                }
                else
                {
                    player.money -= 100;
                    Console.WriteLine("You now have $" + player.money);
                    Console.WriteLine("\nPress any key to go back to the menu.");
                    Console.ReadKey(true);
                    DisplayMenu(player, compt, false);
                }
            }
        }

        public void PurchaseProperty(Player player, int compt)
        {
            Property p = new Property("", Type_Property.Street, 0, 0, Property_Situation.Free, null, 0);
            BoughtProperty bp = new BoughtProperty(p, null);
            HouseProperty hsp = new HouseProperty(bp, null);
            HotelProperty htp = new HotelProperty(hsp, null);
            if(board_game.board[player.position].GetType() == bp.GetType() || board_game.board[player.position].GetType() == hsp.GetType() || board_game.board[player.position].GetType() == htp.GetType())
            {
                Console.WriteLine("This property is not available.");
                Console.WriteLine("Press any key to go back to the menu.");
                Console.ReadKey(true);
                DisplayMenu(player, compt, false);
            }
            else if (board_game.board[player.position].GetType() == p.GetType())
            {
                Console.Clear();
                Console.WriteLine("The property you want to buy is the following:\n");
                p = (Property)board_game.board[player.position];
                Console.WriteLine(p.toString());
                if (p.buying_cost > player.money)
                {
                    Console.WriteLine("\nYou do not have enough money to go through with this purchase.");
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadKey(true);
                    DisplayMenu(player, compt, true);
                }
                else
                {
                    Console.WriteLine("\nYou currently have: $" + player.money);
                    int res = 0;
                    while (res != 1 && res != 2)
                    {
                        Console.WriteLine("Are you sure you want to go throught with this purchase?\n1 : YES\n2 : NO");
                        res = int.Parse(Console.ReadLine());
                    }
                    if (res == 1)
                    {
                        Console.Clear();
                        p = new BoughtProperty(p, player);
                        BoughtProperty b = (BoughtProperty)p;
                        board_game.board[player.position] = b;
                        player.properties.Add(b);
                        player.money -= p.buying_cost;
                        Console.WriteLine("Congratulations on your new property!\n");
                        Console.WriteLine(b.toStringOwner());
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, true);
                    }
                    else if (res == 2)
                    {
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, true);
                    }
                }
            }
            else
            {
                Console.WriteLine("This square is not a property, you cannot purchase it.");
                Console.WriteLine("\nPress any key to choose another action.\n");
                Console.ReadKey(true);
                DisplayMenu(player, compt, true);
            }
        }

        public void Dashboard(Player player, int compt)
        {
            Console.Clear();
            Console.WriteLine("Your position is: " + player.position);
            Console.WriteLine("You have: $" + player.money);
            Console.WriteLine("You own " + player.properties.Count() + " properties:\n");
            if (player.properties.Count() != 0)
            {
                foreach(Property p in player.properties)
                {
                    Console.WriteLine(p.toString());
                }
            }
            Console.WriteLine("\nPress any key to go back to the menu.");
            Console.ReadKey(true);
            DisplayMenu(player, compt, false);
        }

        public void BuyHouseProperty(Player player, int compt)
        {
            if (player.properties.Count() == 0)
            {
                Console.WriteLine("You do not have any properties.");
                Console.WriteLine("\nPress any key to go back to the menu.");
            }
            else
            {
                int i = 0;
                Console.WriteLine("For which property do you want to buy a house?\n");
                foreach(Property p in player.properties)
                {
                    Console.Write(i + 1);
                    Console.WriteLine(p.toString() + "\n");
                    i++;
                }
                i = int.Parse(Console.ReadLine()) - 1;
                BoughtProperty bp = new BoughtProperty(player.properties[i], player);
                while (player.properties[i].GetType() != bp.GetType())
                {
                    Console.WriteLine("You cannot buy a house for this property because it already has one.");
                    Console.WriteLine("1 : Chose another property\n2 : Go back to the menu");
                    int r = int.Parse(Console.ReadLine());
                    if (r == 2) { DisplayMenu(player, compt, false); }
                    else if (r == 1)
                    {
                        Console.WriteLine("For which property do you want to buy a house?\n");
                        foreach (Property p in player.properties)
                        {
                            Console.Write(i + 1);
                            Console.WriteLine(p.toString() + "\n");
                            i++;
                        }
                        i = int.Parse(Console.ReadLine());
                    }
                }
                bp = (BoughtProperty)player.properties[i];
                long house_price = bp.buying_cost * 2;
                Console.WriteLine("Buying a house for this property costs $" + house_price);
                if (player.money < house_price)
                {
                    Console.WriteLine("\nYou do not have enough money to go through with this purchase.");
                    Console.WriteLine("Press any key to go back to the menu.");
                    Console.ReadKey(true);
                    DisplayMenu(player, compt, false);
                }
                else
                {
                    Console.WriteLine("\nYou currently have: $" + player.money);
                    int res = 0;
                    while (res != 1 && res != 2)
                    {
                        Console.WriteLine("Are you sure you want to go throught with this purchase?\n1 : YES\n2 : NO");
                        res = int.Parse(Console.ReadLine());
                    }
                    if (res == 1)
                    {
                        Console.Clear();
                        bp = new HouseProperty(bp, player);
                        HouseProperty hsp = (HouseProperty)bp;
                        board_game.board[player.position] = hsp;
                        int j = 0;
                        foreach (Property prop in player.properties)
                        {
                            if (prop.name != hsp.name)
                            {
                                j++;
                            }
                        }
                        player.properties[j] = hsp;
                        Console.WriteLine("Congratulations on your new house!\n");
                        Console.WriteLine(hsp.toStringOwner());
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                    else if (res == 2)
                    {
                        Console.WriteLine("\nPress any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                }
            }
        }
        
        public void BuyHotelProperty(Player player, int compt)
        {
            if (player.properties.Count() == 0)
            {
                Console.WriteLine("You do not have any properties.");
                Console.WriteLine("\nPress any key to go back to the menu.");
            }
            else
            {
                int i = 0;
                Console.WriteLine("For which property do you want to buy a hotel?\n");
                foreach (Property p in player.properties)
                {
                    Console.Write(i + 1);
                    Console.WriteLine(p.toString() + "\n");
                    i++;
                }
                i = int.Parse(Console.ReadLine()) - 1;
                BoughtProperty bp = new BoughtProperty(player.properties[i], player);
                HouseProperty hsp = new HouseProperty(bp, player);
                while (player.properties[i].GetType() != hsp.GetType())
                {
                    Console.WriteLine("You cannot buy a hotel for this property because it already has one or it does not have a house yet.");
                    Console.WriteLine("1 : Chose another property\n2 : Go back to the menu");
                    int r = int.Parse(Console.ReadLine());
                    if (r == 2) { DisplayMenu(player, compt, false); }
                    else if (r == 1)
                    {
                        Console.WriteLine("For which property do you want to buy a hotel?\n");
                        foreach (Property p in player.properties)
                        {
                            Console.Write(i + 1);
                            Console.WriteLine(p.toString() + "\n");
                            i++;
                        }
                        i = int.Parse(Console.ReadLine());
                    }
                }
                hsp = (HouseProperty)player.properties[i];
                long hotel_price = hsp.buying_cost * 3;
                    Console.WriteLine("Buying a hotel for this property costs $" + hotel_price);
                    if (player.money < hotel_price)
                    {
                        Console.WriteLine("\nYou do not have enough money to go through with this purchase.");
                        Console.WriteLine("Press any key to go back to the menu.");
                        Console.ReadKey(true);
                        DisplayMenu(player, compt, false);
                    }
                    else
                    {
                        Console.WriteLine("\nYou currently have: $" + player.money);
                        int res = 0;
                        while (res != 1 && res != 2)
                        {
                            Console.WriteLine("Are you sure you want to go throught with this purchase?\n1 : YES\n2 : NO");
                            res = int.Parse(Console.ReadLine());
                        }
                        if (res == 1)
                        {
                            Console.Clear();
                            hsp = new HotelProperty(hsp, player);
                            HotelProperty htp = (HotelProperty)hsp;
                            board_game.board[player.position] = htp;
                            int j = 0;
                            foreach (Property prop in player.properties)
                            {
                                if (prop.name != htp.name)
                                {
                                    j++;
                                }
                            }
                            player.properties[j] = htp;
                            Console.WriteLine("Congratulations on your new hotel!\n");
                            Console.WriteLine(htp.toStringOwner());
                            Console.WriteLine("\nPress any key to go back to the menu.");
                            Console.ReadKey(true);
                            DisplayMenu(player, compt, false);
                        }
                        else if (res == 2)
                        {
                            Console.WriteLine("\nPress any key to go back to the menu.");
                            Console.ReadKey(true);
                            DisplayMenu(player, compt, false);
                        }
                    }
                }
            }
    }
}
