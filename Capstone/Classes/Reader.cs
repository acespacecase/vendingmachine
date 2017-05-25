using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class Reader
    {
        public Dictionary<string, Item> ReadInventoryFile()
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            List<string> fullText = new List<string>();
            Dictionary<string, Item> startingItemList = new Dictionary<string, Item>();

            string[] temp = new string[1];

            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        fullText.Add(sr.ReadLine());
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < fullText.Count(); i++)
            {
                temp = fullText[i].Split('|');
                Item tempItem = new Item(temp[1], temp[2]);
                startingItemList.Add(temp[0], tempItem);
                //                startingItemList.Add(new Item(temp[1], temp[0], temp[2]));
            }

            return startingItemList;
        }
    }
}
