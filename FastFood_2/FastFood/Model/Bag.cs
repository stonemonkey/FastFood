using System.Collections.Generic;
using System.Linq;
using FastFood.Interface;

namespace FastFood.Model
{
    public class Bag : List<IMealItem>, IMealItem
    {
        public Bag()
        {
        }

        public Bag(IMealItem item) 
        {
            Add(item);
        }

        public decimal Price
        {
            // the price of a bag is in fact the price of its content
            get { return this.Sum(item => item.Price); }
        }
    }
}