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
                    return "Get out of jail";
                case 2:
                    return "Pay $" + random_cash + " to the player who played before you";
                case 3:
                    return "Pay $" + random_cash + " for taxes";
                case 4:
                    return "Receive $" + random_cash + " from the bank";
                case 5:
                    return "Move " + random_int + " squares forward";
                case 6:
                    return "Move " + random_int + " squares backward";
                case 7:
                    return "Go to jail";
                default:
                    return "There was an error please try again";
            }
        }

    }
    
}
