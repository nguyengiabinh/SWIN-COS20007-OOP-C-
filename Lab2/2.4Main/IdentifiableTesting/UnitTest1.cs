
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; 
using SwinAdventure;

namespace SwinAdventure 
{
    [TestFixture]
    public class IdentifiableObjTest 
    {

        private IdentifiableObject _testObject;
        private string _testString;

        [Test]
        public void TestAreYou()
        {

            IdentifiableObject id = new IdentifiableObject(new string[] { "binh", "lam" });
            Assert.IsTrue(id.AreYou("binh"));

        }

        [Test()]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "binh", "lam" });
            Assert.IsFalse(id.AreYou("nguyen"));
        }

        [Test()]
        public void TestAreYouCaseSentitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "binh", "lam" });
            Assert.IsTrue(id.AreYou("lAM"));
        }

        [Test()]
        public void TestFirstID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "binh", "lam" });
            Assert.That(id.FirstId, Is.EqualTo("binh"));
        }

        [Test()]
        public void TestAddID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "binh", "lam" });
            id.AddIdentifier("manh");
            Assert.IsTrue(id.AreYou("manh"));
        }
    }
}