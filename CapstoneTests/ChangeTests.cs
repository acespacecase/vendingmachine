using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTests
    {
        [TestMethod]
        public void Change_ConstructsCorrectly()
        {
            Change test = new Change(155);
            Assert.AreEqual(6, test.NumQuarters);
            Assert.AreEqual(0, test.NumDimes);
            Assert.AreEqual(1, test.NumNickels);
        }

        [TestMethod]
        public void Change_ToString_ReturnsString()
        {
            Change test = new Change(155);
            Assert.AreEqual("Your change is $1.55. 6 quarters, 0 dimes, and 1 nickels.", test.ToString());
        }
    }
}
