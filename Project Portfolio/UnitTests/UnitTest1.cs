using System.Collections.Generic;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class UnitTest1
    {
        private List<int> ints;
        private List<int> sharedints;

        [OneTimeSetUp] // used to be TestFixtureSetUp
        public void FixtureSetup()
        {
            ints=new List<int>();
            sharedints=new List<int>();
            sharedints.Add(72);
        }

        [SetUp]
        public void testSetup()
        {
            ints.Add(2);
        }

        [Test]
        [Order(1)]
        public void TestMethod1()
        {
            int i = 2;
            int j = 5;
            int k = i + j;
            int l = i * k;
            string s = string.Concat(i,j,k,l);
            sharedints.Add(l);
            ints.Add(k);
            Assert.IsTrue(ints.Contains(2));
            Assert.AreEqual(k,7);
            Assert.IsTrue(s.Equals("25714"));
            Assert.IsNotEmpty(s);
            Assert.IsFalse(k==l);

        }

        [Test]
        [Order(2)]
        public void TestMethod2()
        {
            Assert.IsTrue(sharedints.Contains(14));
            Assert.IsFalse(ints.Contains(7));
            Assert.IsTrue(ints.Contains(2));
        }

        [TearDown]
        public void TestTearDown()
        {
            ints.Clear();
        }

        [OneTimeTearDown]// Used to be TestFixtureTearDown
        public void fixtureTeardown()
        {
            sharedints.Clear();
        }
    }
}
