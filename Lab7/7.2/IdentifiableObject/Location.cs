using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject,IHaveInventory
    {
        private Inventory _inventory = new Inventory();

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
                return Name + /*Description +*/ ":" + "\n" + _inventory.ItemList;
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
    }
}
