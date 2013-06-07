using System;
using System.Collections.Generic;

namespace fastfood
{
    internal class Menu
    {
        private readonly List<Category> categories = new List<Category>();

        public Menu()
        {
            // TODO: Load this from resources/db/configuration
            Category burgers = new Category("Burgers");
            burgers.Add(new Product("Hamburger", new Money(3.4, "RON")));
            burgers.Add(new Product("Cheesburger", new Money(4.2, "RON")));
            categories.Add(burgers);

            Category drinks = new Category("Drinks");
            drinks.Add(new Product("Coca Cola", new Money(2.25, "RON")));
            drinks.Add(new Product("Fanta", new Money(2.25, "RON")));
            categories.Add(drinks);

            Category fries = new Category("Fries");
            fries.Add(new Product("French Fries", new Money(1.8, "RON")));
            categories.Add(fries);

            Category toys = new Category("Toys");
            toys.Add(new Toy("Car", new Money(1.5, "RON")));
            toys.Add(new Toy("Doll", new Money(1.5, "RON")));
            categories.Add(toys);
        }

        public Order CreateOrder()
        {
            Order order = new Order();
            foreach (Category category in categories)
            {
                order.Add(category.SelectProduct());
            }
            Console.WriteLine("Your order:");
            Console.WriteLine(order);

            return order;
        }
    }
}