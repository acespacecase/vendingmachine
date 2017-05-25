using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class Item
    {
        private string name;
        public virtual string Name
        {
            get { return this.name; }
        }
        
        private decimal price;
        public virtual decimal Price
        {
            get { return this.price; }
        }

        public Item(string name, string price)
        {
            this.name = name;
            this.price = decimal.Parse(price);
        }

        public abstract void Consume();

    }
}
