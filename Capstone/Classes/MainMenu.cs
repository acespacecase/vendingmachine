using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public MainMenu()
        {
            VendingMachine vm = new VendingMachine();
            Display(vm.AllItems, vm);
        }

        public void Display(Dictionary<string, List<Item>> allItems, VendingMachine vm)
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
                    ViewPurchaseSubMenu(vm);
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

        public void ViewPurchaseSubMenu(VendingMachine vm)
        {
            bool isCorrectValue = true;
            
            while (isCorrectValue)
            {
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine();
                Console.WriteLine($"Current money provided: {vm.CurrentMoneyAmount.ToString("C2")}");
                Console.WriteLine();

                try
                {
                    int userChoice = int.Parse(Console.ReadLine());

                    isCorrectValue = false;
                    UserActionInSubMenu(userChoice, vm);

                }
                catch
                {
                    Console.WriteLine("Sorry, I didn't understand that.");
                }
            }
            
        }

        public void UserActionInSubMenu(int userChoice, VendingMachine vm)
        {
            List<Item> currentHaul = new List<Item>();

            if (userChoice == 1)
            {
                bool isCorrectValue = true;
                while(isCorrectValue)
                {
                    Console.WriteLine();
                    Console.WriteLine("How much money are you entering? 1, 2, 5, or 10?");
                    try
                    {
                        decimal userMoneyEntered = decimal.Parse(Console.ReadLine());

                        if (!(userMoneyEntered == 1 || userMoneyEntered == 2 || userMoneyEntered == 5 || userMoneyEntered == 10))
                        {
                            Console.WriteLine("I didn't recognize that.. I only accept 1, 2, 5, and 10.");

                        }
                        else
                        {
                            vm.AddMoney(userMoneyEntered);
                            ViewPurchaseSubMenu(vm);
                            isCorrectValue = false;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Sorry, I didn't understand that.");
                    }

                }
                
            }
            else if (userChoice == 2)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to purchase?");
                string chosenItem = Console.ReadLine();
                try
                {
                    currentHaul.Add(vm.Purchase(chosenItem));
                }
                catch (VendingMachineException e)
                {
                    Console.WriteLine(e.Message);
                }
                
                ViewPurchaseSubMenu(vm);
            }
            else if (userChoice == 3)
            {
            }

        }
    }
}
