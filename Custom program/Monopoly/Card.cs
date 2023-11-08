using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Card : Square
    {
        public enum card_Type { Chance, Community_Chest }

        public card_Type type; 
        public int instruction; 

        public card_Type Type 
        { 
            get 
            { 
                return type; 
            } 
            set 
            { 
                type = value; 
            } 
        }
        public int Instruction
        { 
            get 
            { 
                return instruction; 
            } 
            set 
            {
                instruction = value;
            }
        }

        public Card(card_Type type, int position) : base(position)
        {
            this.type = type;
            instruction = Random_Num();
            this.position = position;
        }

        public int Random_Num()
        {
            Random random = new Random();
            int result = random.Next(1, 8);
            return result;
        }

        public int Random_Cash()
        {
            Random random = new Random();
            int result = random.Next(1, 1001);
            return result;
        }

        public string Card_Description(int instruction, int random_cash, int random_int)
        {
            switch (instruction)
            {
                case 1:
                    return "God bail you out of jail";
                case 2:
                    return "Give $" + random_cash + " to the one that played before you";
                case 3:
                    return "God decides to take $" + random_cash + "from you";
                case 4:
                    return "God feel pity and give you $" + random_cash;
                case 5:
                    return "Move " + random_int + " squares forward";
                case 6:
                    return "Move " + random_int + " squares backward";
                case 7:
                    return "You committed tax fraud for no reason so you go to prison";
                default:
                    return "Something wrong!!!";
            }
        }

    }
    
}
