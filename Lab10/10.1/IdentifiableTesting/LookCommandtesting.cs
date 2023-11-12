using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    [TestFixture]
    public class TestLookCommand
    {
        LookCommand look;
        Player p;
        Bag bag;
        Item gem;

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            p = new Player("lickmya707", "the gamer");
            bag = new Bag(new string[] { "bag" }, "bag", "This is the legendary space bag in eastern legend");
            gem = new Item(new string[] { "gem" }, "cool gem", "the reality stone, one of the infinity stones");
        }


        [Test]
        public void TestLookAtMe()
        {
            string command = look.Execute(p, new string[] { "look", "at", "inventory" });
            string expected = "lickmya707 you have:\n";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGem()
        {
            p.Inventory.Put(gem);
            string command = look.Execute(p, new string[] { "look", "at", "gem" });
            string expected = "the reality stone, one of the infinity stones";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtUnknown()
        {
            string command = look.Execute(p, new string[] { "look", "at", "gem" });
            string expected = "I can't find the gem";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            p.Inventory.Put(gem);
            string command = look.Execute(p, new string[] { "look", "at", "gem", "in", "inventory" });
            string expected = "the reality stone, one of the infinity stones";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            bag.Inventory.Put(gem);
            p.Inventory.Put(bag);
            string command = look.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "the reality stone, one of the infinity stones";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            bag.Inventory.Put(gem);
            string command = look.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I can't find the bag";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            p.Inventory.Put(bag);
            string command = look.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I can't find the gem";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidLook()
        {
            string command = look.Execute(p, new string[] { "look", "around" });
            Assert.That(command, Is.EqualTo("I don't know how to look like that"));

            string expected = look.Execute(p, new string[] { "hello" });
            Assert.That(expected, Is.EqualTo("I don't know how to look like that"));

            string command1 = look.Execute(p, new string[] { "look", "at", "a", "at", "b" });
            Assert.That(command1, Is.EqualTo("What do you want to look in?"));
        }



    }
}
