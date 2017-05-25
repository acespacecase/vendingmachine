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
        Dictionary<string, Item> inventory = new Dictionary<string, Item>();

        public VendingMachine()
        {
            StockMachine();

            MainMenu mainMenu = new MainMenu();
            mainMenu.Display();
            
        }

        private void StockMachine()
        {
            Reader readFile = new Reader();
            inventory = readFile.ReadInventoryFile();
            
        }
    }
}
