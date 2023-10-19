using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string name, desc;
            Console.WriteLine("Setting up the PLayer:\nPlayer name: ");
            name = Console.ReadLine();
            Console.Write("A few word about you: ");
            desc = Console.ReadLine();
            Player p = new Player(name, desc);

            Item gaunlet = new Item(new string[] { "gaunlet(proxy)" }, "a gaunlet", "This is a proxy of the legendary infinity gaunlet");
            Item power_stone = new Item(new string[] { "power stone" }, "an infinity stone", "This is the power stone - one of the infinity stone created at the dawn of time");
            Item invisibility_cloak = new Item(new string[] { "invisibility cloak" }, "a cloak", "The invisibility cloak used by Harry Potter himself a long time ago");
            Bag spatial_ring = new Bag(new string[] {"spatial ring" }, "common", "A rusty spatial ring");

            p.Inventory.Put(gaunlet);
            p.Inventory.Put(invisibility_cloak);
            p.Inventory.Put(spatial_ring);
            spatial_ring.Inventory.Put(power_stone);
        }
    }
}