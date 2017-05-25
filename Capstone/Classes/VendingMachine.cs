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

        Dictionary<string, List<Item>> allItems = new Dictionary<string, List<Item>>();
        
        public VendingMachine()
        {
            StockMachine(this.allItems);
            MainMenu mainMenu = new MainMenu();
            mainMenu.Display(allItems);
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

    }
}
