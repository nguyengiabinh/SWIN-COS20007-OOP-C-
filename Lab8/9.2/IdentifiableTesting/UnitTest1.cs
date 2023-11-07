
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

            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("fred"));

        }

        [Test()]
        public void TestNotAreYou()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsFalse(id.AreYou("wilma"));
        }

        [Test()]
        public void TestAreYouCaseSentitive()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.IsTrue(id.AreYou("bOB"));
        }

        [Test()]
        public void TestFirstID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            Assert.That(id.FirstId, Is.EqualTo("fred"));
        }

        [Test()]
        public void TestAddID()
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "fred", "bob" });
            id.AddIdentifier("wilma");
            Assert.IsTrue(id.AreYou("wilma"));
        }
    }
}