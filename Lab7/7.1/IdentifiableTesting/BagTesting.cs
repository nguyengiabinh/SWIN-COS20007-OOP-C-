using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class BagTesting
    {
        Bag bag;
        Bag backpack;
        Item shield;
        Item sword;

        [SetUp]
        public void Setup()
        {
            bag = new Bag(new string[] { "chest" }, "chest", "Minecraft chest");
            backpack = new Bag(new string[] { "backpack" }, "backpack", "a cool siu nhan dien quang backpack");
            shield = new Item(new string[] { "shield" }, "a shield", "This is an obsidian shield");
            sword = new Item(new string[] { "sword" }, "a sword", "This is the legendary dragonlord sword");

            bag.Inventory.Put(backpack);
            bag.Inventory.Put(shield);
            backpack.Inventory.Put(sword);
        }


        [Test]
        public void TestLocatesItems()
        {
            Assert.IsTrue(bag.Inventory.ItemOwn("backpack"));
            Assert.IsTrue(bag.Inventory.ItemOwn("shield"));
            Assert.That(bag.Locate("backpack"), Is.EqualTo(backpack));
            Assert.That(bag.Locate("shield"), Is.EqualTo(shield));
        }
        [Test]
        public void TestBagLocatesItself()
        {
            Assert.IsTrue(bag.Locate(bag.FirstId) == bag);
        }
        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.That(bag.Locate("girlfriend :(("), Is.SameAs(null));
        }
        [Test]
        public void TestFullDescription()
        {
            Assert.That(bag.Description, Is.EqualTo("In the chest:\nbackpack: backpack\na shield: shield\n"));
        }
        [Test]
        public void TestBagInBag()
        {
            bag.Inventory.Put(backpack);
            Assert.That(bag.Locate("backpack"), Is.EqualTo(backpack));
            Assert.That(bag.Locate("shield"), Is.EqualTo(shield));
            Assert.That(bag.Locate("sword"), Is.EqualTo(null));
        }

    }
}
