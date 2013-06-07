using System;
using System.Collections.Generic;
using FastFoodService.MenuItems;
using FastFoodService.MenuItems.Burgers;
using FastFoodService.MenuItems.Chips;
using FastFoodService.MenuItems.Sodas;
using FastFoodService.MenuItems.Toys;

namespace FastFoodService.DemoUsage
{
    /// <summary>
    /// Demo of a FastFoodService usage scenario.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrate a scenario of ordering several Menus through the FastFoodService's Waiter.
        /// </summary>
        static void Main()
        {
            var orderedMenus = new List<Menu> {
                new Waiter().ServeMenu<VegetableBurger, CocaColaSoda, StandardFrenchFries, DollToy>(),
                new Waiter().ServeMenu<ChickenBurger, OrangeSoda, StandardFrenchFries, CarToy>(),
                new Waiter().ServeMenu<ChickenBurger, CocaColaSoda, StandardFrenchFries, CarToy>()
            };

            foreach (Menu menu in orderedMenus)
            {
                Console.WriteLine(String.Format("\n'{0}' wrapped in '{1}' costs {2} RON and contains:", menu.Name, menu.Wrapping.Name, menu.Price));
                foreach (MenuItem menuItem in menu.Items)
                {
                    Console.WriteLine(String.Format("\t'{0}' wrapped in '{1}' costs {2} RON", menuItem.Name, menuItem.Wrapping.Name, menuItem.Price));
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
    }
}
