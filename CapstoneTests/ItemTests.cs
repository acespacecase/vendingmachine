using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Item_CreatesNewItemCorrectly()
        {
            Candy test = new Candy("Candy", "0.50");

            Assert.AreEqual("Candy", test.Name);
            Assert.AreEqual(0.50M, test.Price);
        }
    }
}
