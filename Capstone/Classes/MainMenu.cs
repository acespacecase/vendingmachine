using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Display()
        {
            bool correctAnswer = false;
            int result = 0;
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Welcome to Your First Amazing Experience With Vendo-Matic 500");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine();
            
            while(!correctAnswer)
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine();
                correctAnswer = int.TryParse(Console.ReadLine(), out result);
            }

            if (result == 1)
            {
                ViewItems();
            }
            else if (result == 2)
            {
                //purchase method goes here
            }

        }

        public void ViewItems()
        {

        }
    }
}
