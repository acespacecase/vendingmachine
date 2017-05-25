using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : Item
    {

        public Candy(string name, string price)
            : base(name, price)
        {
        }

        public override void Consume()
        {
            Console.WriteLine("Munch Munch, Yum!");
        }
    }
}
