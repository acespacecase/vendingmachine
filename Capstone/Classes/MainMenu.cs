using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Display(Dictionary<string, List<Item>> allItems)
        {
            bool correctAnswer = false;
            bool showMainMenu = true;
            int result = 0;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Welcome to Your First Amazing Experience With Vendo-Matic 500");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();

            while (showMainMenu)
            {

                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine();
                correctAnswer = int.TryParse(Console.ReadLine(), out result);

                if (result == 1)
                {
                    ViewItems(allItems);
                }
                else if (result == 2)
                {
                    //purchase method goes here
                    showMainMenu = false;
                }
            }
        }


        public void ViewItems(Dictionary<string, List<Item>> allItems)
        {
            Console.WriteLine("Displaying Items...");
            Console.WriteLine();
            Console.WriteLine("Slot No.".PadRight(13) + "Item Name".PadRight(21) + "Price".PadRight(11) + "Inventory");
            Console.WriteLine("-------------------------------------------------------");
            foreach (KeyValuePair<string, List<Item>> item in allItems)
            {
                Console.WriteLine($"{item.Key.PadRight(12)} {item.Value[0].Name.PadRight(20)} { (item.Value[0].Price).ToString("C2").PadRight(14)} { item.Value.Count()}");
            }
            Console.WriteLine();
            Console.WriteLine("Returning to main menu");
            Console.WriteLine();
        }

        public void ViewPurchaseSubMenu()
        {
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            int userChoice = int.Parse(Console.ReadLine());

            if (userChoice == 1)
            {
                
            }


        }
    }
}
