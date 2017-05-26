using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    class LogWriter
    {
        public void WritingLogFile(string action, decimal startingPrice, decimal endingPrice)
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "Log.txt";
            string fullPath = Path.Combine(directory, fileName);
            DateTime dateCurrentTime = DateTime.Now;

            try
            {
                using (StreamWriter logWriter = new StreamWriter(fullPath, true))
                {
                    logWriter.WriteLine(dateCurrentTime.ToString("MMMM dd, yyyy").PadRight(15) +
                        dateCurrentTime.ToString("H:mm:ss").PadRight(15) + action.PadRight(25) +
                        startingPrice.ToString("C2").PadRight(8) + endingPrice.ToString("C2"));
                    logWriter.Flush();
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine("File not found." + ex.Message);
            }
        }

        public void WritingSalesReport(List<Item> allSoldItems)
        {
            string directory = Directory.GetCurrentDirectory();
            string fileName = "SalesReport.txt";
            string fullPath = Path.Combine(directory, fileName);
            decimal totalSum = 0.0M;

            Dictionary<Item, int> soldItemCount = new Dictionary<Item, int>();

            for (int i = 0; i < allSoldItems.Count(); i++)
            {
                if (soldItemCount.ContainsKey(allSoldItems[i]))
                {
                    soldItemCount[allSoldItems[i]]++;
                }
                else
                {
                    soldItemCount.Add(allSoldItems[i], 1);
                }
            }

            try
            {
                using (StreamWriter reportWriter = new StreamWriter(fullPath))
                {
                    foreach (KeyValuePair<Item, int> item in soldItemCount)
                    {
                        reportWriter.WriteLine(item.Key.Name + "|" + item.Value);
                        totalSum += item.Key.Price;
                    }
                    reportWriter.WriteLine();
                    reportWriter.WriteLine("Total Sales is " + totalSum.ToString("C2"));
                    reportWriter.Flush();
                }

            }
            catch (IOException ex)
            {
                Console.WriteLine("File not found." + ex.Message);
            }
        }

    }
}