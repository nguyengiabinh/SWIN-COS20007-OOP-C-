using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Monopoly.Property;

namespace Monopoly
{
    public class GameLogic
    {
        public List<Player> player = new List<Player>();
        Board board = new Board();
        int turns;
        public Player winner;

        public void Initialize()
        {
            int playerinit = 0;
            while (playerinit < 2 || playerinit > 4)
            {
                Console.WriteLine("How many players (2-4)?");
                playerinit = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < playerinit; i++)
            {
                Console.WriteLine("Player " + (i + 1));
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                Player playername = new Player(name);
                player.Add(playername);
            }
            Console.WriteLine("\nPlayers:");
            for (int i = 0; i < playerinit; i++)
            {
                Console.WriteLine("\n" + player[i].playerInfo());
            }
            Console.WriteLine("Press any key on your keyboard to continue!!!");
            Console.ReadKey(true);
        }

        public bool Win()
        {
            int win_cond = 0;
            Player playerwin = new Player();
            for (int i = 0; i < player.Count; i++)
            {
                if (player[i].money != 0)
                {
                    playerwin = player[i];
                    win_cond = win_cond + 1;
                }
            }
            if (win_cond == 1)
            {
                winner = playerwin;
                return true;
            }

            int lose_cond = 0;
            foreach (Player p in player)
            {
                if (p.lose == false)
                {
                    winner = p;
                    lose_cond = lose_cond + 1;
                }
            }
            if (lose_cond == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Game_Main()
        {
            int playerID = 0;
            Console.Clear();
            while (!Win())
            {
                turns = turns + 1;
                while (player[playerID].lose)
                {
                    if (playerID == player.Count - 1)
                    {
                        playerID = 0;
                    }
                    else
                    {
                        playerID = playerID + 1;
                    }
                }

                Player now = player[playerID];
                Console.WriteLine("\nPlayer " + now.Name);
                Console.WriteLine("\nPress any key on your keyboard to roll the dice");
                Console.ReadKey(true);

                int dice = now.Dice();
                now.MoveForward(dice);
                Console.WriteLine("\nYou are now on " + now.position);

                Console.WriteLine("\nPress any key to continue !");
                Console.ReadKey(true);
                Game_choice(now, playerID, true);

                if (playerID == player.Count - 1)
                {
                    playerID = 0;
                }
                else
                {
                    playerID = playerID + 1;
                }
            }
            Console.WriteLine("The winner is: " + winner.Name);
            Console.ReadKey(true);
        }

        public void Game_choice(Player currentplayer, int playerID, bool position)
        {
            Console.Clear();

            int command = 0;
            Console.WriteLine("\nWhat are you going to do :");
            Console.WriteLine("0: \tView Game Status");
            Console.WriteLine("1: \tView my Profile");
            Console.WriteLine("2: \tPurchase the land");
            Console.WriteLine("3: \tBuild mansion on the land");
            Console.WriteLine("4: \tBuild Hotel/Resort on the land");
            Console.WriteLine("5: \tEnd my turn");
            Console.WriteLine("6: \tSurrender");
            Console.WriteLine("7: \tExit game");

            try
            {
                command = int.Parse(Console.ReadLine());
            }
            catch (FormatException error)
            {
                Console.WriteLine("Invalid command:" + error.Message);
                this.Game_choice(currentplayer, playerID, true);
            }

            switch (command)
            {
                case 0:
                    for (int i = 0; i < player.Count; i++)
                    {
                        Console.WriteLine("\n" + player[i].playerInfo());
                    }
                    Console.ReadKey();
                    Console.Clear();
                    Game_choice(currentplayer, playerID, position);
                    break;
                case 1:
                    PlayerProfile(currentplayer, playerID);
                    break;
                case 2:
                    BuySquare(currentplayer, playerID);
                    break;

                    //case 5:
                    //    break;
            }

        }

        public void PlayerProfile(Player currentplayer, int playerID)
        {
            Console.Clear();
            Console.WriteLine("Current position: " + currentplayer.position);
            Console.WriteLine("In bank account: $" + currentplayer.money);
            Console.WriteLine("You have " + currentplayer.properties.Count() + " propertie/s under your name:\n");
            if (currentplayer.properties.Count() != 0)
            {
                foreach (Property p in currentplayer.properties)
                {
                    Console.WriteLine(p.property_desc());
                }
            }
            Console.WriteLine("\nPress something to go back.");
            Console.ReadKey(true);
            Game_choice(currentplayer, playerID, false);
        }

        public void BuySquare(Player currentplayer, int playerID)
        {
            Property prop = new Property("", property_Type.Special, 0, 0, Property_Status.Sale, null, 0);
            BoughtStatus bought_status = new BoughtStatus(prop, null);
            LandStatus land_status = new LandStatus(bought_status, null);
            RentStatus rent_status = new RentStatus(land_status, null);
            if (board.square[currentplayer.position].GetType() == bought_status.GetType() || board.square[currentplayer.position].GetType() == land_status.GetType() || board.square[currentplayer.position].GetType() == rent_status.GetType())
            {
                Console.WriteLine("This property is already belong to someone else.");
                Console.ReadKey(true);
                Game_choice(currentplayer, playerID, false);
            }
            else if (board.square[currentplayer.position].GetType() == prop.GetType()) 
            {
                Console.Clear();
                Console.WriteLine("This is the information of the square u want to buy: ");
                prop = (Property)board.square[currentplayer.position];
                Console.WriteLine(prop.property_desc());

                if (prop.market_price > currentplayer.money)
                {
                    Console.WriteLine("you cant afford this property due to the fact that you are fcking broke BOI!!!");
                    Console.WriteLine("This is the how much you have left: " + currentplayer.money);
                    Console.ReadKey(true);
                    Game_choice(currentplayer, playerID, true);
                }
                else
                {
                    int confirmation;
                    Console.WriteLine("This is the how much you have left: " + currentplayer.money);
                    Console.WriteLine("Purchase confirmation" + "\nYES" + "\nNO");
                    confirmation = int.Parse(Console.ReadLine());

                    switch (confirmation)
                    {
                        case 1:
                            Console.Clear();
                            prop = new BoughtStatus(prop, currentplayer);

                    }

                }
            }
        }
        
    }
}
