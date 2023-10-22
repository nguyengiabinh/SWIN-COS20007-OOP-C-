using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SwinAdventure
{
    public class InventoryTest
    {
        Item club = new Item(new string[] { "club" }, "a club", "This is the LEGENDARY BorneBeast iClub");
        Item sword = new Item(new string[] { "sword" }, "a sword", "This is a rusty sword");


        [Test]
        public void TestFindItem()
        {
            Inventory i = new Inventory();
            i.Put(club);
            Assert.IsTrue(i.ItemOwn(club.FirstId));
        }

        [Test]
        public void TestNotFindItem()
        {
            Inventory i = new Inventory();
            i.Put(club);
            bool command = i.ItemOwn("shovel");
            Assert.IsFalse(command, "Test Inventory does not have item by FirstID");
        }

        [Test]
        public void TestFetchItems()
        {
            Inventory i = new Inventory();
            i.Put(club);
            Item fetchItem = i.Fetch(club.FirstId);
            Assert.IsTrue(fetchItem == club);
            Assert.IsTrue(i.ItemOwn(club.FirstId));
        }

        [Test]
        public void TestTakenItem()
        {
            Inventory i = new Inventory();
            i.Put(club);
            i.Take(club.FirstId);
            Assert.IsFalse(i.ItemOwn(club.FirstId));
        }

        [Test]
        public void TestItemList()
        {
            Inventory i = new Inventory();
            i.Put(club);
            i.Put(sword);
            Assert.IsTrue(i.ItemOwn(club.FirstId));
            Assert.IsTrue(i.ItemOwn(sword.FirstId));
            string expctOutput = "a club: club\n" + "a sword: sword\n";
            Assert.AreEqual(i.ItemList, expctOutput);
        }

    }
}