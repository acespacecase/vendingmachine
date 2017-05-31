using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Abstractions;
using System.Reflection;

namespace Capstone.Classes
{
    public class InventoryReader
    {
        IFileSystem fileSystem;

        public InventoryReader() : this(new FileSystem())
        {

            ReadInventoryFile();

        }
        public InventoryReader(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public Dictionary<string, List<Item>> ReadInventoryFile(string fileName)
        {
            string directory = Directory.GetCurrentDirectory();
            string fullPath = Path.Combine(directory, fileName);

            List<string> fullText = new List<string>();
            Dictionary<string, List<Item>> startingItemList = new Dictionary<string, List<Item>>();

            try
            {
                using (Stream stream = this.fileSystem.File.OpenRead(fullPath))
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        while (!sr.EndOfStream)
                        {
                            fullText.Add(sr.ReadLine());
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < fullText.Count(); i++)
            {
                string[] temp = new string[1];
                const int SlotNumberIndex = 0;
                const int ProductName = 1;
                const int ProductPrice = 2;

                temp = fullText[i].Split('|');
                int startingInventoryCount = 5;
                List<Item> fiveSameItems = new List<Item>();
                Dictionary<string, Type> productTypes = new Dictionary<string, Type>()
                {
                    {"A", typeof(Chip) },
                    {"B", typeof(Candy) },
                    {"C", typeof(Beverage) },
                    {"D", typeof(Gum) }
                };

                Type productType = productTypes[temp[SlotNumberIndex].Substring(0, 1)];

                for (int j = 0; j < startingInventoryCount; j++)
                {
                    fiveSameItems.Add((Item)Activator.CreateInstance(productType, temp[ProductName], temp[ProductPrice]));
                }

                startingItemList.Add(temp[SlotNumberIndex], fiveSameItems);
            }

            return startingItemList;
        }

        public Dictionary<string, List<Item>> ReadInventoryFile()
        {
            return ReadInventoryFile("vendingmachine.csv");
        }
    }

}
