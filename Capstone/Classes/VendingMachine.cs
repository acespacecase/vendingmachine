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
        // property = CurrentMoneyAmount
        // method = AddMoney 1, 2, 5, 10
        // method = purchase
        // method = isSoldOut
        // method = complete transaction (change class)

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
            StockMachine(this.allItems);
        }

        public void StockMachine(Dictionary<string, List<Item>> allItems)
        {
            Reader readFile = new Reader();
            this.allItems = readFile.ReadInventoryFile();
        }

        public void AddMoney(decimal dollarAmount)
        {
            this.currentMoneyAmount += dollarAmount;
        }

        public Item Purchase(string slotNumber)
        {

            if (!IsSoldOut(slotNumber))
            {
                if (allItems[slotNumber][0].Price <= this.currentMoneyAmount)
                {
                    this.currentMoneyAmount -= allItems[slotNumber][0].Price;
                    allItems[slotNumber].RemoveAt(0);
                    return allItems[slotNumber][0];
                }
                else
                {
                    throw new OverdraftException("Sorry, you don't have enough money for that.");
                }
            }
            else
            {
                throw new SoldOutException("Sorry, that's sold out! Try something else.");
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

        //public string FinishTransaction()
        //{

        //}
    }
}
