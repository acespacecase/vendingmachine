using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void Item_CreatesNewCandyCorrectly()
        {
            Candy test = new Candy("Candy", "0.50");

            Assert.AreEqual("Candy", test.Name);
            Assert.AreEqual(0.50M, test.Price);
        }

        [TestMethod]
        public void Item_CreatesNewDrinksCorrectly()
        {
            Beverage test = new Beverage("Beverage", "1.25");

            Assert.AreEqual("Beverage", test.Name);
            Assert.AreEqual(1.25M, test.Price);
        }

        [TestMethod]
        public void Item_CreatesNewChipCorrectly()
        {
            Chip test = new Chip("Chip", "2.25");

            Assert.AreEqual("Chip", test.Name);
            Assert.AreEqual(2.25M, test.Price);
        }


        [TestMethod]
        public void Item_CreatesNewGumCorrectly()
        {
            Gum test = new Gum(" Gum", "0.25");

            Assert.AreEqual(" Gum", test.Name);
            Assert.AreEqual(0.25M, test.Price);
        }
    }
}
