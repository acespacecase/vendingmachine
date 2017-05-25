using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chip : Item
    {

        public Chip(string name, string price)
            : base(name, price)
        {
        }

        public override void Consume()
        {
            Console.WriteLine("Crunch Crunch, Yum!");
        }
    }
}
