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

    }
}