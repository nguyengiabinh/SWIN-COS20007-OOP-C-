using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _target;
        private bool _closed;

        public Path(string[] ids, string name, string desc, Location target) : base(ids, name, desc)
        {
            _target = target;
            _closed = false;

            AddIdentifier("path");
            foreach (string s in name.Split(" "))
            {
                AddIdentifier(s);
            }
        }

        public Location Target 
        {
            get 
            {
                return _target; 
            } 
        }

        public override string Description
        {
            get
            {
                return Name;
            }
        }

        public bool Closed
        {
            get
            {
                return _closed;
            }
            set 
            { 
                _closed = value; 
            }
        }
    }
}
