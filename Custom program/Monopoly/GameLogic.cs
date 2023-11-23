using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Monopoly.Card;
using static Monopoly.Property;

namespace Monopoly
{
    public class GameLogic
    {
        public List<Player> player = new List<Player>();
        public Board board = new Board();
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
                Console.WriteLine(player[i].playerInfo());
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
                Console.WriteLine("\nPress any key to roll the dice");
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
            if (position)
            {
                CurrentPosition(currentplayer, playerID);
            }
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
                case 3:
                    UpgradeInLandDirection(currentplayer, playerID);
                    break;
                case 4:
                    UpgradeInRentDirection(currentplayer, playerID);
                    break;
                case 5:
                    Console.Clear();
                    break;
                case 6:
                    currentplayer.lose = true;
                    break;
                case 7:
                    currentplayer.money = 0;
                    currentplayer.lose = true;
                    break;
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

        public void CurrentPosition(Player currentplayer, int playerID)
        {
            Property prop = new Property("", property_Type.Special, 0, 0, Property_Status.Sale, null, 0);
            BoughtStatus bought_status = new BoughtStatus(prop, null);
            LandStatus land_status = new LandStatus(bought_status, null);
            RentStatus rent_status = new RentStatus(land_status, null);
            Card card = new Card(card_Type.Chance, 0);
            Square square = new Square();
            Console.WriteLine("This is your location: ");
            if (board.square[currentplayer.position].GetType() == prop.GetType())
            {
                prop = (Property)board.square[currentplayer.position];
                Console.WriteLine(prop.property_desc());
            }
            else if (board.square[currentplayer.position].GetType() == bought_status.GetType())
            {
                bought_status = (BoughtStatus)board.square[currentplayer.position];
                Console.WriteLine(bought_status.Owner());
                if (bought_status.owner != currentplayer)
                {
                    Console.WriteLine("Since you are not the owner of this land you must pay the price of " + bought_status.fee);
                    Console.WriteLine("This land is of " + bought_status.owner.name + "ownership");
                    if (currentplayer.money < bought_status.fee)
                    {
                        Console.WriteLine("You lost due to being broke af");
                        currentplayer.money = 0;
                        currentplayer.lose = true;
                        Console.ReadKey(true);
                        Game_choice(currentplayer, playerID, false);
                    }
                    else
                    {
                        currentplayer.money = currentplayer.money - bought_status.fee;
                        bought_status.owner.money = bought_status.owner.money + bought_status.fee;
                        Console.WriteLine("Bank Account: -" + bought_status.fee);
                        Console.ReadKey(true);
                        Game_choice(currentplayer, playerID, false);
                    }
                }
            }
            else if (board.square[currentplayer.position].GetType() == land_status.GetType())
            {
                land_status = (LandStatus)board.square[currentplayer.position];
                Console.WriteLine(land_status.Owner());
                if (land_status.owner != currentplayer)
                {
                    Console.WriteLine("Since you are not the owner of this land and this land had been upgrade you must pay the price of " + land_status.fee);
                    Console.WriteLine("This land is of " + land_status.owner.name + "ownership");
                    if (currentplayer.money < land_status.fee)
                    {
                        Console.WriteLine("You lost due to being broke af");
                        currentplayer.money = 0;
                        currentplayer.lose = true;
                        Console.ReadKey(true);
                        Game_choice(currentplayer, playerID, false);
                    }
                    else
                    {
                        currentplayer.money = currentplayer.money - land_status.fee;
                        land_status.owner.money = land_status.owner.money + land_status.fee;
                        Console.WriteLine("Bank Account: -" + land_status.fee);
                        Console.ReadKey(true);
                        Game_choice(currentplayer, playerID, false);
                    }
                }
            }
            else if (board.square[currentplayer.position].GetType() == rent_status.GetType())
            {
                rent_status = (RentStatus)board.square[currentplayer.position];
                Console.WriteLine(rent_status.Owner());
                if (rent_status.owner != currentplayer)
                {
                    Console.WriteLine("Since you are not the owner of this land and this land had been upgrade you must pay the price of " + rent_status.fee);
                    Console.WriteLine("This land is of " + rent_status.owner.name + "ownership");
                    if (currentplayer.money < rent_status.fee)
                    {
                        Console.WriteLine("You lost due to being broke af");
                        currentplayer.money = 0;
                        currentplayer.lose = true;
                        Console.ReadKey(true);
                        Game_choice(currentplayer, playerID, false);
                    }
                    else
                    {
                        currentplayer.money = currentplayer.money - rent_status.fee;
                        rent_status.owner.money = rent_status.owner.money + rent_status.fee;
                        Console.WriteLine("Bank Account: -" + land_status.fee);
                        Console.ReadKey(true);
                        Game_choice(currentplayer, playerID, false);
                    }
                }
            }
            else if (board.square[currentplayer.position].GetType() == card.GetType())
            {
                card = (Card)board.square[currentplayer.position];
                Console.WriteLine("you are on " + card.type.ToString() + " card square");
                CardPosition(card, currentplayer, playerID);
            }
            else if (board.square[currentplayer.position].GetType() == square.GetType())
            {
                EmptyPosition(currentplayer, playerID);
            }
        }

        public void EmptyPosition(Player currentplayer, int playerID)
        {
            if (currentplayer.position == 0)
            {
                Console.WriteLine("\nStarting line!");
            }
            else if (currentplayer.position == 1)
            {
                Console.WriteLine("\nYou got yourself in the prison somehow but only for this turn and your mom is bailing you out");
            }
            else if (currentplayer.position == 15)
            {
                Console.WriteLine("\nYou are going to prison because you commit an offense to the Sacred Timeline");
                Console.WriteLine("Consider yourself lucky cuz you didn't get prune");
                currentplayer.prison = true;
                currentplayer.position = 1;
                Console.WriteLine("\nPress anything");
                Console.ReadKey(true);
                Game_choice(currentplayer, playerID, false);
            }
        }

        public void BuySquare(Player currentplayer, int playerID)
        {
            Property prop = new Property("", property_Type.Special, 0, 0, Property_Status.Sale, null, 0);
            BoughtStatus bought_status = new BoughtStatus(prop, null);
            LandStatus land_status = new LandStatus(bought_status, null);
            RentStatus rent_status = new RentStatus(land_status, null);
            //prop = (Property)board.square[currentplayer.position];
            if (board.square[currentplayer.position].GetType() == bought_status.GetType() || board.square[currentplayer.position].GetType() == land_status.GetType() || board.square[currentplayer.position].GetType() == rent_status.GetType())
            {
                Console.WriteLine("This property is already belong to someone");
                Console.ReadKey(true);
                Game_choice(currentplayer, playerID, true);
            }
            else if (board.square[currentplayer.position].GetType() == prop.GetType())
            {
                Console.Clear();
                //if (currentplayer.properties.Contains(prop))
                //{
                //    Console.WriteLine("\nYou already bought this square");
                //    Console.ReadKey(true);
                //    Game_choice(currentplayer, playerID, false);
                //}
                
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
                        //if (board.square[currentplayer.position].GetType() == bought_status.GetType())
                        int confirmation;
                        Console.WriteLine("This is the how much you have left: " + currentplayer.money);
                        Console.WriteLine("Purchase confirmation: " + "\n1 : YES" + "\n2 : NO");
                        confirmation = int.Parse(Console.ReadLine());

                        switch (confirmation)
                        {
                            case 1:
                                Console.Clear();
                                prop = new BoughtStatus(prop, currentplayer);
                                BoughtStatus bought = (BoughtStatus)prop;
                                board.square[currentplayer.position] = bought;
                                currentplayer.properties.Add(bought);
                                currentplayer.money = currentplayer.money - prop.market_price;
                                Console.WriteLine("You are now the proud owner of " + prop.Name + "\n");
                                Console.WriteLine(bought.Owner());
                                Console.ReadKey(true);
                                Game_choice(currentplayer, playerID, true);
                                break;
                            case 2:
                                Game_choice(currentplayer, playerID, true);
                                break;
                            default:
                                Console.WriteLine("\nInvalid Command -> returning to command list");
                                Game_choice(currentplayer, playerID, true);
                                break;
                        }

                    }
                
            }
            else
            {
                Console.WriteLine("This is goverment property, you are not allow to meddle with this square!");
                Console.ReadKey(true);
                Game_choice(currentplayer, playerID, true);
            }
        }

        public void UpgradeInLandDirection(Player currentplayer, int playerID)
        {
            if (currentplayer.properties.Count() == 0)
            {
                Console.WriteLine("You possess 0 property");
                Console.ReadKey(true);
                Game_choice(currentplayer, playerID, false);
            }
            else
            {
                int numbering = 0;
                Console.WriteLine("Which square to you want to upgrade in the Land direction");
                foreach (Property prop in currentplayer.properties)
                {
                    Console.WriteLine(numbering + 1 + ": " + "\n" + prop.property_desc());
                    numbering = numbering + 1;
                }
                numbering = int.Parse(Console.ReadLine()) - 1;
                BoughtStatus bought_status = new BoughtStatus(currentplayer.properties[numbering], currentplayer);
                while (currentplayer.properties[numbering].GetType() != bought_status.GetType())
                {
                    Console.WriteLine("The land in this square is already upgraded");
                    Console.WriteLine("1: Choose a different square" + "\n2: Go back to command list");
                    int command = int.Parse(Console.ReadLine());
                    if (command == 1)
                    {
                        Console.WriteLine("Which square to you want to upgrade in the Land direction");
                        foreach (Property prop in currentplayer.properties)
                        {
                            Console.WriteLine(numbering + 1 + ": " + "\n" + prop.property_desc());
                            numbering = numbering + 1;
                        }
                        numbering = int.Parse(Console.ReadLine()) - 1;
                    }
                    else if (command == 2)
                    {
                        Game_choice(currentplayer, playerID, false);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input: allow input are 1 and 2");
                        Console.ReadKey(true);
                        Console.Clear();
                        UpgradeInLandDirection(currentplayer, playerID);
                    }
                }
                bought_status = (BoughtStatus)currentplayer.properties[numbering];
                int land_price = bought_status.market_price + 100;
                Console.WriteLine("Upgrading this land would cost " +
                    "" + land_price);
                if (currentplayer.money < land_price)
                {
                    Console.WriteLine("What made you think you can afford this upgrade huh?");
                    Console.WriteLine("This is how much you have left: " + currentplayer.money);
                    Console.ReadKey(true);
                    Game_choice(currentplayer, playerID, false);
                }
                else
                {
                    Console.WriteLine("Upgrade confirmation");
                    Console.WriteLine("1: YES" + "\n2: No");
                    int command = int.Parse(Console.ReadLine());
                    if (command == 1)
                    {
                        Console.Clear();
                        bought_status = new LandStatus(bought_status, currentplayer);
                        LandStatus land_status = (LandStatus)bought_status;
                        board.square[currentplayer.position] = land_status;
                        int upgrade_finalizing = 0;
                        foreach (Property prop in currentplayer.properties)
                        {
                            if  (prop.name != land_status.name)
                            {
                                upgrade_finalizing = upgrade_finalizing + 1;
                            }
                        }
                        currentplayer.properties[upgrade_finalizing] = land_status;
                        currentplayer.money = currentplayer.money - land_price;
                        Console.WriteLine(land_status.Owner());
                        Console.ReadKey(true);
                        Game_choice(currentplayer, playerID, false);
                    }
                    else if (command == 2)
                    {
                        Game_choice(currentplayer, playerID, false);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input: allow input are 1 and 2");
                        Console.ReadKey(true);
                        Console.Clear();
                        UpgradeInLandDirection(currentplayer, playerID);
                    }

                }
            }
        }

        public void UpgradeInRentDirection(Player currentplayer, int playerID)
        {
            if (currentplayer.properties.Count() == 0)
            {
                Console.WriteLine("You possess 0 property");
                Console.ReadKey(true);
                Game_choice(currentplayer, playerID, false);
            }
            else
            {
                Console.Clear();
                int numbering = 0;
                Console.WriteLine("Which square to you want to upgrade in the Rent(Hotel/Resort) direction");
                foreach (Property prop in currentplayer.properties)
                {
                    Console.WriteLine(numbering + 1 + ": " + "\n" + prop.property_desc());
                    numbering = numbering + 1;
                }
                numbering = int.Parse(Console.ReadLine()) - 1;
                BoughtStatus bought_status = new BoughtStatus(currentplayer.properties[numbering], currentplayer);
                LandStatus land_status = new LandStatus(bought_status, currentplayer);
                while (currentplayer.properties[numbering].GetType() != land_status.GetType())
                {
                    Console.WriteLine("This square is already upgraded to Rent or The land in this square is not yet been upgraded");
                    Console.WriteLine("1: Choose a different square" + "\n2: Go back to command list");
                    int command = int.Parse(Console.ReadLine());
                    switch (command)
                    {
                        case 1:
                            int numbering2 = 0;
                            Console.WriteLine("Which square to you want to upgrade in the Land direction");
                            foreach (Property prop in currentplayer.properties)
                            {
                                Console.WriteLine(numbering2 + 1 + ": " + "\n" + prop.property_desc());
                                numbering2 = numbering2 + 1;
                            }
                            numbering2 = int.Parse(Console.ReadLine()) - 1;
                            break;

                        case 2:

                            Game_choice(currentplayer, playerID, true);
                            break;

                        default:

                            Console.WriteLine("Invalid input: allow input are 1 and 2");
                            Console.ReadKey(true);
                            Console.Clear();
                            UpgradeInLandDirection(currentplayer, playerID);
                            break;
                    }
                    
                }
                land_status = (LandStatus)currentplayer.properties[numbering];
                int rent_price = land_status.market_price + 500;
                Console.WriteLine("Upgrading this land to a Rent state would cost " + rent_price);
                if (currentplayer.money < rent_price)
                {
                    Console.WriteLine("What made you think you can afford this upgrade huh?");
                    Console.WriteLine("This is how much you have left: " + currentplayer.money);
                    Console.ReadKey(true);
                    Game_choice(currentplayer, playerID, false);
                }
                else
                {
                    Console.WriteLine("Upgrade confirmation");
                    Console.WriteLine("1: YES" + "\n2: No");
                    int command = int.Parse(Console.ReadLine());
                    if (command == 1)
                    {
                        Console.Clear();
                        land_status = new RentStatus(land_status, currentplayer);
                        RentStatus rent_status = (RentStatus)land_status;
                        board.square[currentplayer.position] = rent_status;
                        int upgrade_finalizing = 0;
                        foreach (Property prop in currentplayer.properties)
                        {
                            if (prop.name != rent_status.name)
                            {
                                upgrade_finalizing = upgrade_finalizing + 1;
                            }
                        }
                        currentplayer.properties[upgrade_finalizing] = rent_status;
                        currentplayer.money = currentplayer.money - rent_price;
                        Console.WriteLine(rent_status.Owner());
                        Console.ReadKey(true);
                        Game_choice(currentplayer, playerID, false);
                    }
                    else if (command == 2)
                    {
                        Game_choice(currentplayer, playerID, false);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input: allow input are 1 and 2");
                        Console.ReadKey(true);
                        Console.Clear();
                        UpgradeInRentDirection(currentplayer, playerID);
                    }

                }
            }
        }

        public void CardPosition(Card card, Player currentplayer, int playerID)
        {
            Console.WriteLine("Card description: ");
            int random_cash = card.Random_Cash();
            int random_int = card.Random_Num();
            Console.WriteLine(card.Card_Description(card.instruction, random_cash, random_int));
            if (card.instruction == 1)
            {
                if (currentplayer.prison)
                {
                    Console.WriteLine("Welp its look like you are free to go");
                    currentplayer.prison = false;
                }
                else
                {
                    Console.WriteLine("keep this for the next time you got in prison");
                    currentplayer.prison_pass = true;
                }
            }
            else if (card.instruction == 2)
            {
                if (turns < 2)
                {
                    Console.WriteLine("Blud got lucky huh");
                }
                else
                {
                    if (currentplayer.money < random_cash)
                    {
                        Console.WriteLine("You lost due to being broke af");
                        currentplayer.lose = true;
                    }
                    else
                    {
                        player[playerID - 1].money = player[playerID - 1].money + random_cash;
                        currentplayer.money = currentplayer.money - random_cash;
                        Console.WriteLine("Since you have to give " + random_cash + "to" + player[playerID - 1]);
                        Console.WriteLine("Bank account: -" + random_cash);
                    }
                }
            }
            else if (card.instruction == 3)
            {
                if (currentplayer.money < random_cash)
                {
                    Console.WriteLine("You lost due to being broke af");
                    currentplayer.lose = true;
                }
                else
                {
                    currentplayer.money = currentplayer.money - random_cash;
                    Console.WriteLine("Bank account: -" + random_cash);
                }
            }
            else if (card.instruction == 4)
            {
                currentplayer.money = currentplayer.money + random_cash;
                Console.WriteLine("Bank account: +" + random_cash);
            }
            else if (card.instruction == 5)
            {
                currentplayer.MoveForward(random_int);
                Console.WriteLine("Your are noew at: " + currentplayer.position);
            }
            else if (card.instruction == 6)
            {
                currentplayer.MoveBackward(random_int);
                Console.WriteLine("Your are now at: " + currentplayer.position);
            }
            else if (card.instruction == 7)
            {
                currentplayer.position = 1;
                currentplayer.prison = true;
            }
            Console.WriteLine("\nPress anything");
            Console.ReadKey(true);
        }

    }
}
