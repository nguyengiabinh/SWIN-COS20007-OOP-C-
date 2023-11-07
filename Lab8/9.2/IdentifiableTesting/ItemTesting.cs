using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class TestItem
    {
        Item club = new Item(new string[] { "club" }, "a club", "This is the LEGENDARY BorneBeast iClub");
        Item sword = new Item(new string[] { "sword" }, "a sword", "This is a rusty sword");


        [Test]
        public void TestItemIdentifiable()
        {
            var result = club.AreYou("sword");
            Assert.IsFalse(result); 

            var result2 = club .AreYou("club");
            Assert.IsTrue(result2);

        }

        //[Test]
        //public void TestShortDescription()
        //{
        //    Assert.AreEqual(club.ShortDescription, "a club: club"); 
        //    Assert.AreNotEqual(club.ShortDescription, "This is the LEGENDARY BorneBeast iClub"); 
        //}

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual(sword.Description, "This is a rusty sword"); 
            Assert.AreNotEqual(sword.Description, "a sword: sword"); 

        }
    }
}
