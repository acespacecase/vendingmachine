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
            Item test = new Item("Candy", "A1", "0.50");

            Assert.AreEqual("Candy", test.Name);
            Assert.AreEqual("A1", test.SlotNumber);
            Assert.AreEqual(0.50M, test.Price);
        }
    }
}
