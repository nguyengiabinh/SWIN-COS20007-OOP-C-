using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        public string name; 
        public int position = 0; 
        public int money = 2000;  
        public bool jail = false; // jail = true = player in jail
        public bool /*get_out_of_jail_card*/ jail_pass = false; // =true = player has jail_pass
        public bool lose = false;

        public Player(string Name, int Position, int Money, bool Jail, bool NoJail, bool Loser)
        {
            name = Name;
            position = Position;
            money = Money;
            jail = Jail;
            jail_pass = NoJail;
            lose = Loser;
        }

        public string Name 
        {
            get 
            {
                return name;
            }
            set 
            { 
                name = value; 
            }
        }
        public int Position 
        {
            get 
            { 
                return position; 
            } 
            set 
            { 
                position = value; 
            }
        }
        public int Money 
        { 
            get 
            { 
                return money; 
            } 
            set 
            { 
                money = value; 
            } 
        }
        public bool Jail 
        { 
            get 
            { 
                return jail; 
            } 
            set 
            { 
                jail = value; 
            } 
        }
        public bool GetOut 
        { 
            get 
            { 
                return jail_pass; 
            } 
            set 
            { 
                jail_pass = value; 
            } 
        }
        public bool Lose 
        { 
            get 
            { 
                return lose;
            }
            set 
            { 
                lose = value; 
            } 
        }

        public int Dice()
        {
            Random random = new Random();
            int dice_value = random.Next(1, 6);
            Console.WriteLine("You roll a " + dice_value);
            return dice_value;
        }
    }
}
