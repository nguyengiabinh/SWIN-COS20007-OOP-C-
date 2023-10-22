using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location;
        public Player(string name, string desc) : base(new string[] { "me", "inventory"}, name, desc) 
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
                return Name + " you have:\n" + _inventory.ItemList;
            }
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id) == true)
            {
                return this;
            }

            GameObject interactable = _inventory.Fetch(id);

            if (interactable != null)
            {
                return interactable;
            }

            if (_location != null)
            {
                interactable = _location.Locate(id);
                return interactable;
            }
            else
            {
                return null;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
    }
}
