using System;
using System.Collections.Generic;
using System.Globalization;

namespace fastfood
{
    internal class Category
    {
        private readonly List<Product> products = new List<Product>();
        private readonly string name;

        public Category(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            string result = name + Environment.NewLine;
            int index = 1;
            foreach (Product product in products)
            {
                result += index.ToString(CultureInfo.InvariantCulture) + " " + product + Environment.NewLine;
                index++;
            }
            return result;
        }

        public Product SelectProduct()
        {
            Console.WriteLine(this);

            int selection;
            while (true)
            {
                Console.WriteLine("Please select one");
                selection = Console.ReadKey().KeyChar-'1';
                Console.WriteLine();
                if ((selection >= 0) && (selection < products.Count))
                    break;
            }
            Console.WriteLine("You selected " + products[selection]);
            Console.WriteLine();

            return products[selection];
        }

        public void Add(Product product)
        {
            products.Add(product);
        }
    }
}