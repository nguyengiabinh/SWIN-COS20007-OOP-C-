using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Monopoly.Property;

namespace Monopoly
{
    public class Board
    {
        public Square[] board = new Square[16];

        public Board()
        {
            Board_Creation();
        }

        public void Board_Creation()
        {
            board[0] = new Square(); // start square: give $200 as you pass or land on
            board[1] = new Property("Mediterranean Avenue", property_Type.Street, 60, 0, Property_Status.Free, null, 1);
        }
            
    }
}
