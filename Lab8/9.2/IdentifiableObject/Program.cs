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
            Console.WriteLine("Setting up the PLayer:\n- Player name: ");
            name = Console.ReadLine();
            Console.Write("- A few word about you: ");
            desc = Console.ReadLine();
            Player p = new Player(name, desc);

            Item gaunlet = new Item(new string[] { "gaunlet" }, "a gaunlet", "This is a proxy of the legendary infinity gaunlet");
            Item power_stone = new Item(new string[] { "stone" }, "an infinity stone", "This is the power stone - one of the infinity stone created at the dawn of time");
            Item invisibility_cloak = new Item(new string[] { "cloak" }, "a cloak", "The invisibility cloak used by Harry Potter himself a long time ago");
            Bag spatial_ring = new Bag(new string[] {"ring" }, "spatial ring(common)", "A rusty spatial ring");
            //Central Hall Item
            Item cosmic_vase = new Item(new string[] { "vase" }, "* Cosmic vase(Epic)", "A vase created for the sole purpose of decoration");
            Item MonaLisa = new Item(new string[] { "painting" }, "* MonaLisa Painting(Rare)", "A unique painting created by the legendary Da Vinci");
            //
            //Weaponry Item
            Item storm_breaker = new Item(new string[] { "axe" }, "* Storm Breaker(Mythical)", "A weapon created for the god king, capable of challenging the infinity stones");
            Item mjornir = new Item(new string[] { "hammer" }, "* Mjornir(Epic)(Shattered)", "A weapon created for the god of thunder, capable of harnessing the thunder god power");
            //
            Location CentralHall = new Location("Central Hall ", "- You are at the Central Hall ");
            Location Weaponry = new Location("Weaponry ", "- You are at the weaponry, weapons and various kinds of item are kept here ");
            Location FoodStorage = new Location("Food Storage ", "- Here lies all your frozen meal");
            Location Kitchen = new Location("Kitchen ", "- Where the chef you hired cook your meal");
            Location Bedroom = new Location("Bedroom ", "- This is where the master sleep relax and work ");
            Location LivingRoom = new Location("Livingroom ", "- A room for guests that come to visit ");
            Location Toilet = new Location("Toilet", "- Shit devourer, piss wizard, cum terminator");
            Location Petroom = new Location("Petroom", "- This is where the master pets hang around");
            Location Library = new Location("Library", "- A magical room filled with book that the master will never look into");

            //Path to go back to central hall
            Path CentralHallReturn = new Path(new string[] { "center" }, "Center", "Central Hall", CentralHall);
            Weaponry.AddPath(CentralHallReturn);
            FoodStorage.AddPath(CentralHallReturn);
            Kitchen.AddPath(CentralHallReturn);
            Bedroom.AddPath(CentralHallReturn);
            LivingRoom.AddPath(CentralHallReturn);
            Toilet.AddPath(CentralHallReturn);
            Petroom.AddPath(CentralHallReturn);
            Library.AddPath(CentralHallReturn);
            //
            //Path from central hall
            Path WeaponrySouth = new Path(new string[] { "south" }, "South", "South Path", Weaponry);
            Path ToiletSouthEast = new Path(new string[] { "southeast" }, "South East", "South East Path", Toilet);
            Path FoodStorageSouthWest = new Path(new string[] { "southwest" }, "South West", "South West Path", FoodStorage);
            Path BedroomEast = new Path(new string[] { "east" }, "East", "East Path", Bedroom);
            Path KitchenWest = new Path(new string[] { "west" }, "West", "West Path", Kitchen);
            Path LivingroomNorthWest = new Path(new string[] { "northwest" }, "North West", "North West Path", LivingRoom);
            Path PetroomNorthEast = new Path(new string[] { "northeast" }, "North East", "North East Path", Petroom);
            Path LibraryNorth = new Path(new string[] { "north" }, "North", "North Path", Library);

            CentralHall.AddPath(WeaponrySouth);
            CentralHall.AddPath(ToiletSouthEast);
            CentralHall.AddPath(FoodStorageSouthWest);
            CentralHall.AddPath(BedroomEast);
            CentralHall.AddPath(KitchenWest);
            CentralHall.AddPath(LivingroomNorthWest);
            CentralHall.AddPath(PetroomNorthEast);
            CentralHall.AddPath(LibraryNorth);
            //

            p.Inventory.Put(gaunlet);
            p.Inventory.Put(invisibility_cloak);
            p.Inventory.Put(spatial_ring);
            spatial_ring.Inventory.Put(power_stone);

            p.Location = CentralHall; //Player position by default
            CentralHall.Inventory.Put(cosmic_vase);
            CentralHall.Inventory.Put(MonaLisa);
            Weaponry.Inventory.Put(storm_breaker);
            Weaponry.Inventory.Put(mjornir);

            string command_input;
            Command look = new LookCommand();
            Command move = new MoveCommand();

            while (true)
            {
                Console.Write("What is your Command? ");
                command_input = Console.ReadLine();
                string[] command = command_input.ToLower().Split();
                if (command[0] == "quit")
                {
                    break;
                }
                else if (command[0] == "look")
                {
                    Console.WriteLine(look.Execute(p, command_input.ToLower().Split()));
                }
                else if (command[0] == "move" || command[0] == "go" || command[0] == "head" || command[0] == "leave")
                {
                    Console.WriteLine(move.Execute(p, command_input.ToLower().Split()));
                }

            }
        }
    }
}