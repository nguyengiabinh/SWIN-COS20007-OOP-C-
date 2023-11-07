using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class PathTesting
    {
        Path pathtestA;
        Path pathtestB;
        Location roomA;
        Location roomB;
        Player playerTest;

        [SetUp]
        public void Setup()
        {
            roomA = new Location("a room", "This is roomA");
            roomB = new Location("a room", "This is roomB");
            pathtestA = new Path(new string[] { "south" }, "south", "A path", roomA);
            Player playerTest = new Player("Binh", "Nepenthes poacher");

            playerTest.Location = roomA;
            pathtestB = new Path(new string[] { "south" }, "south", "B path", roomB);
            roomA.AddPath(pathtestA);
            roomB.AddPath(pathtestB);
        }

        [Test]
        public void TestPathIdentifiable()
        {
            Assert.That(pathtestA.AreYou("south"), Is.True);
            Assert.That(pathtestA.AreYou("north"), Is.False);
        }

        [Test]
        public void PathLocationTest()
        {
            Location expected = roomA;
            Location actual = pathtestA.Target;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestLocatePath()
        {

            GameObject expected = roomA.Locate("south");
            GameObject actual = null;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
        
}
