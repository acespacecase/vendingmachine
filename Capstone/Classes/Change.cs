using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private int numQuarters;
        public int NumQuarters
        {
            get { return this.numQuarters; }
        }

        private int numDimes;
        public int NumDimes
        {
            get { return this.numDimes; }
        }

        private int numNickels;
        public int NumNickels
        {
            get { return this.numNickels; }
        }

        public Change(decimal amountInCents)
        {
            this.numQuarters = (int)amountInCents / 25;
            amountInCents = amountInCents % 25;
            this.numDimes = (int)amountInCents / 10;
            amountInCents = amountInCents % 10;
            this.numNickels = (int)amountInCents / 5;
        }

        public override string ToString()
        {
            string result = "";
            decimal change = ((decimal)(this.numQuarters * 25.00M / 100.00M) + (this.numDimes * 10.00M / 100.00M) + (this.numNickels * 5.00M / 100.00M));
            int dollars = (int)change;
            int cents = (int)((change - dollars) * 100);
            result += $"Your change is ${dollars}.{cents}. ";
            result += $"{this.numQuarters} quarters, ";
            result += $"{this.numDimes} dimes, ";
            result += $"and {this.numNickels} nickels.";

            return result;
        }
    }
}
