using System;
using System.Collections.Generic;

namespace fastfood
{
    internal class Order
    {
        private readonly List<Product> products = new List<Product>();  
        public void Add(Product product)
        {
            products.Add(product);
        }

        public override string ToString()
        {
            string result = "";
            Money total = new Money(0.0, "RON");
            foreach (Product product in products)
            {
                result += product + Environment.NewLine;
                total.Add(product.Price());
            }
            result += "Total price: " + total;
            return result;
        }

        public Lunch Prepare()
        {
            Lunch lunch = new Lunch();
            foreach (Product product in products)
            {
                product.Prepare();
                lunch.Add(product);
            }
            return lunch;
        }
    }
}