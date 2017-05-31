using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {

        private List<Item> allItemsSold = new List<Item>();
        public List<Item> AllItemsSold
        {
            get { return this.allItemsSold; }
        }

        LogWriter lw = new LogWriter();

        private decimal currentMoneyAmount = 0;
        public decimal CurrentMoneyAmount
        {
            get { return this.currentMoneyAmount; }
        }

        private Dictionary<string, List<Item>> allItems = new Dictionary<string, List<Item>>();
        public Dictionary<string, List<Item>> AllItems
        {
            get { return this.allItems; }
        }

        public VendingMachine()
        {
            StockMachine();

        }

        public void StockMachine()
        {
            InventoryReader readFile = new InventoryReader();
            this.allItems = readFile.ReadInventoryFile();

        }

        public void AddMoney(decimal dollarAmount)
        {
            this.currentMoneyAmount += dollarAmount;
            lw.WritingLogFile("Feed Money", dollarAmount, this.currentMoneyAmount);

        }

        public Item Purchase(string slotNumber)
        {

            if (!IsSoldOut(slotNumber))
            {
                if (allItems[slotNumber][0].Price <= this.currentMoneyAmount)
                {
                    this.currentMoneyAmount -= allItems[slotNumber][0].Price;
                    lw.WritingLogFile("Purchased " + allItems[slotNumber][0].Name + " " + slotNumber, allItems[slotNumber][0].Price, this.currentMoneyAmount);
                    allItems[slotNumber].RemoveAt(0);
                    return allItems[slotNumber][0];
                }
                else
                {
                    throw new VendingMachineException("Sorry, you don't have enough money for that.");
                }
            }
            else
            {
                throw new VendingMachineException("Sorry, that's sold out! Try something else.");
            }

        }

        public bool IsSoldOut(string slotNumber)
        {
            if (allItems[slotNumber].Count() == 0)
            {
                return true;
            }
            return false;
        }

        public Change FinishTransaction(List<Item> currentHaul)
        {
            decimal priceOfAllItems = 0.00M;

            foreach (Item item in currentHaul)
            {
                priceOfAllItems += item.Price;
                Console.WriteLine();
                item.Consume();
                Console.WriteLine();
            }

            this.allItemsSold.AddRange(currentHaul);
            currentHaul.Clear();

            lw.WritingLogFile("Give Change", this.currentMoneyAmount, 0.00M);

            Change change = new Change(this.currentMoneyAmount * 100);
            this.currentMoneyAmount = 0.00M;

            return change;
        }

        public void CreateSalesReport()
        {
            lw.WritingSalesReport(this.allItemsSold);
        }
    }
}
