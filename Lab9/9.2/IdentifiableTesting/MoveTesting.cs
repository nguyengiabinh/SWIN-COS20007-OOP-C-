using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Movetesting
    {
        MoveCommand move;
        Location A;
        Location B;
        Path pathtest;
        Player player;

        [SetUp]
        public void Setup()
        {
            move = new MoveCommand();
            A = new Location("A", "pointA");
            B = new Location("B", "pointB");
            pathtest = new Path(new string[] { "north" }, "north", "this is north", B);
            player = new Player("Binh", "nepenthes collector");

            player.Location = A;
            A.AddPath(pathtest);
        }

        [Test]
        public void TestMove()
        {
            move.Execute(player, new string[] { "move", "north" });
            Assert.That(player.Location, Is.EqualTo(B));
        }

        [Test]
        public void TestInvalidMove()
        {
            move.Execute(player, new string[] { "move", "east" });
            Assert.That(player.Location, Is.SameAs(A));
        }

        [Test]
        public void TestOnlyMoveInput()
        {
            string command = move.Execute(player, new string[] { "move" });
            string expected = "Specify the destination!!!";

            Assert.That(command, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidDirection()
        {
            string command = move.Execute(player, new string[] { "move", "east" });
            string expected = "Something wrong with the direction!!!";

            Assert.That(command, Is.EqualTo(expected));
        }
    }
}
