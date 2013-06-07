using System;
using System.Collections.Generic;

namespace fastfood
{
    internal class Lunch
    {
        private readonly List<Product> content = new List<Product>();

        public void Add(Product product)
        {
            Console.WriteLine("adding " + product + " to lunchbag");
            content.Add(product);
        }

        public override string ToString()
        {
            string result = "Your lunch contains:" + Environment.NewLine;

            foreach (Product product in content)
            {
                result += product + Environment.NewLine;
            }

            return result;
        }
    }
}