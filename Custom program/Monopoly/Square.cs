using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Square
    {
        public int position;

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

        public Square(int Position)
        {
            position = Position;
        }

        public Square()
        {
        }
    }
}
