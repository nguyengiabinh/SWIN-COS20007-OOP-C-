using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LocationTesting
    {
        Player p = new Player("Binh", "A man not a god");
        Location l = new Location("Bed", "Binh old but comfy bed");
        Item ipad = new Item(new string[] { "ipad" }, "ipad pro M1", "A ipad pro released in 2020");

        [Test]
        public void TestNotLocation()
        {
            p.Location = l;
            bool actual = l.AreYou("hi");
            Assert.IsFalse(actual);
        }

        [Test]
        public void TestPLayerHasLocation()
        {
            p.Location = l;
            GameObject expect = l;
            GameObject actual = p.Locate("location");
            Assert.AreEqual(actual, expect);
        }

        [Test]
        public void TestLocationLocateItem()
        {
            l.Inventory.Put(ipad);
            p.Location = l;
            GameObject expect = ipad;
            GameObject actual = l.Locate("ipad");
            Assert.AreEqual(actual, expect);
        }

        [Test]
        public void TestEmptyLocation()
        {
            Assert.That(l.Locate("Vsmart"), Is.EqualTo(null));
        }
    }
}
