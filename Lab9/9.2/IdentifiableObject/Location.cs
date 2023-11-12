using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject,IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private List<Path> _paths = new List<Path>();

        public Location(string name, string desc) : base(new string[] {"location"}, name, desc)
        {
        }

        public Inventory Inventory
        {
            get 
            { 
                return _inventory; 
            }
        }

        public override string Description
        {
            get
            {
                return Name + _desc + PathList + /*Description +*/ "\n" + "Around you there are" + "\n" + _inventory.ItemList ;
            }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id) == true)
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public Path locatePath(string path)
        {
            foreach (Path p in _paths)
            {
                if (p.AreYou(path))
                {
                    return p;
                }
            }
            return null;
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public string PathList 
        {
            get
            {
                string paths = string.Empty + "\n";

                if (_paths.Count == 1)
                {
                    return "\n" + "There is an exit to Central Hall "; //might change later if there are secret rooms
                }

                paths = paths + "direction/s available are(is): ";

                foreach (Path path in _paths)
                {
                    if (path == _paths.Last())
                    {
                        paths = paths + " and " + path.FirstId + ".";
                    } 
                    else if (path == _paths.First())
                    {
                        paths = paths + " " + path.FirstId;
                    }
                    else
                    {
                        paths = paths + ", " + path.FirstId;
                    }
                }

                return paths;
            }
        }
    }
}
