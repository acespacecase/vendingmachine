using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class SoldOutException : Exception
    {
        private string message;
        public override string Message
        {
            get { return this.message; }
        }

        public SoldOutException(string message)
        {
            this.message = message;
        }
    }
}
