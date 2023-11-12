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
            //starting item
            Item gaunlet = new Item(new string[] { "gaunlet" }, "a gaunlet", "This is a proxy of the legendary infinity gaunlet");
            Item power_stone = new Item(new string[] { "stone" }, "an infinity stone", "This is the power stone - one of the infinity stone created at the dawn of time");
            Item invisibility_cloak = new Item(new string[] { "cloak" }, "a cloak", "The invisibility cloak used by Harry Potter himself a long time ago");
            Bag spatial_ring = new Bag(new string[] {"ring" }, "spatial ring(common)", "A rusty spatial ring");
    
            //Central Hall Item
            Item cosmic_vase = new Item(new string[] { "vase" }, "* Cosmic vase(Epic)", "A vase created for the sole purpose of decoration");
            Item MonaLisa = new Item(new string[] { "painting" }, "* MonaLisa Painting(Rare)", "A unique painting created by the legendary Da Vinci");
            
            //Weaponry Item
            Item storm_breaker = new Item(new string[] { "axe" }, "* Storm Breaker(Mythical)", "A weapon created for the god king, capable of challenging the infinity stones");
            Item mjornir = new Item(new string[] { "hammer" }, "* Mjornir(Epic)(Shattered)", "A weapon created for the god of thunder, capable of harnessing the thunder god power");

            //Food storage item
            Item fridge = new Item(new string[] { "fridge" }, "* cool ass large fridge(Rare)", "A very big fridge to keep the food fresh for a long time");
            Item barrel_1 = new Item(new string[] { "wine barrel" }, "* Wooden barrel(Common)", "A barrel that contain some fancy wine");
            Item barrel_2 = new Item(new string[] { "sauce barrel" }, "* Wooden barrel(Common)", "Its seem that the owner of this place know how to make fermented sauce");

            //Kitchen items
            Item knife = new Item(new string[] { "knife" }, "* Uru Knife(Mythical)", "A knife that is made from the mythical ore 'URU'");
            Item spoon = new Item(new string[] { "spoon" }, "* Uru Spoon(Mythical)", "A spoon that is made from the mythical ore 'URU'");
            Item bowl = new Item(new string[] { "bowl" }, "* Uru Bowl(Mythical)", "A bowl that is made from the mythical ore 'URU'");

            //Bedroom items
            Item paper_roll = new Item(new string[] { "paper roll" }, "* Paper Roll (Common)", "Why would something that is meant to be in the toilet in here :))");
            Item laptop = new Item(new string[] { "laptop" }, "* Fancy Laptop(Rare)", "The brand of this laptop is unknown");

            //Living room items
            Item couch = new Item(new string[] { "couch" }, "* Leather Couch(Mythical)", "A couch that is made of the legendary world eater leather");
            Item tivi = new Item(new string[] { "tv" }, "* Big TV(Epic)", "The brand of this TV is unknown but it is huge");

            //Toilet items
            Item paperroll = new Item(new string[] { "paper roll" }, "* Paper Roll (Common)", "Just normal toilet paper roll");
            Item toothbrush = new Item(new string[] { "toothbrush" }, "* Toothbrush(Epic)", "the strand on this tooth brush is made using a very precious hair");

            //Petroom items
            Item pettoy1 = new Item(new string[] { "strand poll" }, "* Straw poll(Legendary)", "The straw that cover this poll is exuding a very strong aura");
            Item pettoy2 = new Item(new string[] { "pet bed" }, "* Pet bed(Mythical)", "The case of this pillow is exuding a very strong aura and the core is made from the Duck world eater feather");

            //Library items
            Item computer = new Item(new string[] { "computer" }, "* Computer(Mythical)", "A multiversal Computer, capable of manipulating time and reality");

            //Location
            Location CentralHall = new Location("The Central Hall ", "- You are at the Central Hall ");
            Location Weaponry = new Location("The Weaponry ", "- You are at the weaponry, weapons and various kinds of item are kept here ");
            Location FoodStorage = new Location("The Food Storage ", "- Here lies all your frozen meal");
            Location Kitchen = new Location("The Kitchen ", "- Where the chef you hired cook your meal");
            Location Bedroom = new Location("The Bedroom ", "- This is where the master sleep relax and work ");
            Location LivingRoom = new Location("The Livingroom ", "- A room for guests that come to visit ");
            Location Toilet = new Location("The Toilet Room", "- Shit devourer, piss wizard, cum terminator");
            Location Petroom = new Location("The Petroom", "- This is where the master pets hang around");
            Location Library = new Location("The Library", "- A magical room filled with book that the master will never look into");

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
            
            //Path from central hall
            Path WeaponrySouth = new Path(new string[] { "south" }, "", "", Weaponry);
            Path ToiletEast = new Path(new string[] { "east" }, "", "", Toilet);
            Path FoodStorageSouthWest = new Path(new string[] { "" }, "", "", FoodStorage);
            Path BedroomSouthEast = new Path(new string[] { "se" }, "", "", Bedroom);
            Path KitchenWest = new Path(new string[] { "west" }, "", "", Kitchen);
            Path LivingroomNorth = new Path(new string[] { "north" }, "", "", LivingRoom);
            Path PetroomNorthEast = new Path(new string[] { "ne" }, "", "", Petroom);
            Path LibraryNorthWest = new Path(new string[] { "nw" }, "", "", Library);

            CentralHall.AddPath(WeaponrySouth);
            CentralHall.AddPath(BedroomSouthEast);
            CentralHall.AddPath(FoodStorageSouthWest);
            CentralHall.AddPath(ToiletEast);
            CentralHall.AddPath(KitchenWest);
            CentralHall.AddPath(LivingroomNorth);
            CentralHall.AddPath(PetroomNorthEast);
            CentralHall.AddPath(LibraryNorthWest);
            
            //starting items and location
            p.Inventory.Put(gaunlet);
            p.Inventory.Put(invisibility_cloak);
            p.Inventory.Put(spatial_ring);
            spatial_ring.Inventory.Put(power_stone);

            p.Location = CentralHall; //Player position by default

            //Central hall items
            CentralHall.Inventory.Put(cosmic_vase);
            CentralHall.Inventory.Put(MonaLisa);

            //Weaponry items
            Weaponry.Inventory.Put(storm_breaker);
            Weaponry.Inventory.Put(mjornir);

            //FoodStorage items
            FoodStorage.Inventory.Put(fridge);
            FoodStorage.Inventory.Put(barrel_1);
            FoodStorage.Inventory.Put(barrel_2);

            //Kitchen items
            Kitchen.Inventory.Put(knife);
            Kitchen.Inventory.Put(spoon);
            Kitchen.Inventory.Put(bowl);

            //Bedroom items
            Bedroom.Inventory.Put(paper_roll);
            Bedroom.Inventory.Put(laptop);

            //LivingRoom items
            LivingRoom.Inventory.Put(couch);
            LivingRoom.Inventory.Put(tivi);

            //Toilet items
            Toilet.Inventory.Put(paperroll);
            Toilet.Inventory.Put(toothbrush);

            //Petroom items
            Petroom.Inventory.Put(pettoy1);
            Petroom.Inventory.Put(pettoy2);

            //Library items
            Library.Inventory.Put(computer);

            string command_input;
            CommandProcessor command_main = new CommandProcessor();

            while (true)
            {
                Console.Write("What is your Command? ");
                command_input = Console.ReadLine();
                string[] command = command_input.ToLower().Split();
                if (command[0] == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(command_main.Execute(p, command_input.ToLower().Split()));
                }

            }
        }
    }
}