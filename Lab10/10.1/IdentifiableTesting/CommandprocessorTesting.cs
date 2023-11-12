using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandprocessorTesting
    {
        CommandProcessor command_main;
        Player p;
        Bag bag;
        Item gem;
        Location A;
        Location B;
        Path pathtest;

        [SetUp]
        public void Setup()
        {
            command_main = new CommandProcessor();
            p = new Player("lickmya707", "the gamer");
            bag = new Bag(new string[] { "bag" }, "bag", "This is the legendary space bag in eastern legend");
            gem = new Item(new string[] { "gem" }, "cool gem", "the reality stone, one of the infinity stones");
            A = new Location("A", "pointA");
            B = new Location("B", "pointB");
            pathtest = new Path(new string[] { "north" }, "north", "this is north", B);

            p.Location = A;
            A.AddPath(pathtest);
        }
        [Test]
        public void TestLookAtMe()
        {
            string command = command_main.Execute(p, new string[] { "look", "at", "inventory" });
            string expected = "lickmya707 you have:\n";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGem()
        {
            p.Inventory.Put(gem);
            string command = command_main.Execute(p, new string[] { "look", "at", "gem" });
            string expected = "the reality stone, one of the infinity stones";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtUnknown()
        {
            string command = command_main.Execute(p, new string[] { "look", "at", "gem" });
            string expected = "I can't find the gem";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            p.Inventory.Put(gem);
            string command = command_main.Execute(p, new string[] { "look", "at", "gem", "in", "inventory" });
            string expected = "the reality stone, one of the infinity stones";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            bag.Inventory.Put(gem);
            p.Inventory.Put(bag);
            string command = command_main.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "the reality stone, one of the infinity stones";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            bag.Inventory.Put(gem);
            string command = command_main.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I can't find the bag";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            p.Inventory.Put(bag);
            string command = command_main.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I can't find the gem";
            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidLook()
        {
            string command = command_main.Execute(p, new string[] { "look", "around" });
            Assert.That(command, Is.EqualTo("I don't know how to look like that"));

            string expected = command_main.Execute(p, new string[] { "hello" });
            Assert.That(expected, Is.EqualTo("Error: Something wrong with the command - Command processor."));

            string command1 = command_main.Execute(p, new string[] { "look", "at", "a", "at", "b" });
            Assert.That(command1, Is.EqualTo("What do you want to look in?"));
        }

        [Test]
        public void TestMove()
        {
            command_main.Execute(p, new string[] { "move", "north" });
            Assert.That(p.Location, Is.EqualTo(B));
        }

        [Test]
        public void TestInvalidMove()
        {
            command_main.Execute(p, new string[] { "move", "east" });
            Assert.That(p.Location, Is.SameAs(A));
        }

        [Test]
        public void TestOnlyMoveInput()
        {
            string command = command_main.Execute(p, new string[] { "move" });
            string expected = "Specify the destination!!!";

            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidDirection()
        {
            string command = command_main.Execute(p, new string[] { "move", "east" });
            string expected = "Something wrong with the direction!!!";

            Assert.That(command, Is.EqualTo(expected));
        }
    }
}
