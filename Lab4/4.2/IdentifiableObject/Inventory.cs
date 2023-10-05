using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifiableObject
{
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool ItemOwn(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }
        public string ItemList
        {
            get
            {
                string itemlist = "";
                foreach (Item i in _items)
                {
                    itemlist = itemlist + i.ShortDescription + "\n";
                }
                return itemlist;
            }
        }
        public void Put(Item item)
        {
            _items.Add(item);
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }
        public Item Take(string id)
        {
            Item iRemove = this.Fetch(id);
            _items.Remove(iRemove);
            return iRemove;
        }
    }
}
