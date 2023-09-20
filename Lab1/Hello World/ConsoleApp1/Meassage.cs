using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Meassage
    {
        private string _text;
        public Meassage(string text) 
        {
            _text = text;
        }

        public void print()
        {
            Console.WriteLine(_text);
        }

    }
}
