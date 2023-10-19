using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class TestPlayer
    {
        Player player = new Player("Binh", "Nepenthes poacher");
        Item club = new Item(new string[] { "club" }, "a club", "This is the LEGENDARY BorneBeast iClub");
        Item sword = new Item(new string[] { "sword" }, "a sword", "This is a rusty sword");


        [Test]
        public void TestPlayerIdentifiable()
        {
            Assert.IsTrue(player.AreYou("me") && player.AreYou("inventory"));

        }

        [Test]
        public void TestPlayerLocateItems()
        {
            var result = false;
            player.Inventory.Put(sword);
            var iLocate = player.Locate("sword");
            if (sword == iLocate)
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            var me = player.Locate("me");
            var inventory = player.Locate("inventory");
            var result = false;

            if (me == player)
            {
                result = true;
            }
            Assert.IsTrue(result);
            if (inventory == player) 
            {
                result = true;
            }
            Assert.IsTrue(result);
        }

        [Test]
        public void TestPlayerLocateNothing()
        {
            var me = player.Locate("Hi");
            Assert.IsNull(me);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            player.Inventory.Put(sword);
            player.Inventory.Put(club);
            string expected = "Binh you have:\na sword: sword\na club: club\n";
            Assert.AreEqual(player.Description, expected);
        }
    }
}
