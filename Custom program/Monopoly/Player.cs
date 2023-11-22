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
        public int money = 1000;  
        public bool prison = false; // jail = true = player in jail
        public bool prison_pass = false; // =true = player has jail_pass
        public bool lose = false;
        public List<Property> properties = new List<Property>();

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
        public bool Prison
        { 
            get 
            { 
                return prison; 
            } 
            set 
            { 
                prison = value; 
            } 
        }
        public bool Prison_Pass
        { 
            get 
            { 
                return prison_pass; 
            } 
            set 
            { 
                prison_pass = value; 
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

        public List<Property> Properties 
        { 
            get 
            {
                return properties; 
            } 
            set 
            { 
                properties = value;
            } 
        }
        public Player(string Name, int Position, int Money, bool Prison, bool Prison_Pass, bool Loser, List<Property> Properties)
        {
            name = Name;
            position = Position;
            money = Money;
            prison = Prison;
            prison_pass = Prison_Pass;
            lose = Loser;
            this.properties = Properties;
        }

        public Player(string Name)
        {
            this.name = Name;
        }

        public Player()
        {
        }

        public string playerInfo()
        {
            int propcount = 0;
            if (properties != null) 
            {
                propcount = properties.Count();
            }
            for (int i = 0; i < properties.Count; i++) 
            {
                Console.WriteLine(properties[i].ToString());
            }

            return "\nName: " + "\t" + Name + "\nCurrent Position: " + "\t" + Position + "\nMoney in account: " + "\t" + Money + "\nProperty(ies): " + "\t" + propcount;
        }

        public int Dice()
        {
            Random random = new Random();
            int dice_value = random.Next(1, 6);
            Console.WriteLine("You roll a " + dice_value);
            return dice_value;
        }
        public void MoveForward(int number)
        {
            if (position + number < 16)
            {
                position += number;
            }
            else
            {
                position = position + number - 16;
                money += 200;
            }
        }

        public void MoveBackward(int number)
        {
            if (position - number >= 0)
            {
                position -= number;
            }
            else
            {
                position = 16 + (position - number);
            }
        }
    }
}
