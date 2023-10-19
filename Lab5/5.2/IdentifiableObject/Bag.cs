using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentifiableObject;

namespace SwinAdventure
{
    public class Bag : Item
    {
        private Inventory _inventory = new Inventory();
        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
        }
        public GameObject Locate(string id)
        {
            if (AreYou(id) == true)
            {
                return this;
            } 
            else if(_inventory.ItemOwn(id)) 
            {
                return _inventory.Fetch(id);
            } 
            else
            {
                return null;
            }
        }

        public override string Description
        {
            get
            {
                return $"In the {Name}:\n" + _inventory.ItemList;
            }
        }
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
