using System;
using FastFood.Interface;
using FastFood.Model;

namespace FastFood.Demo
{
    static class SomePrintExtensions
    {
        public static void PrintContent(this Bag mealBag, string header = "")
        {
            Console.WriteLine(header + mealBag.GetType().Name);
            
            var newHeader = header + "    ";

            foreach (var item in mealBag)
            {
                var bag = item as Bag;
                if (bag != null)
                    bag.PrintContent(newHeader);
                else
                    item.PrintContent(newHeader);
            }
        }

        private static void PrintContent(this IMealItem item, string header)
        {
            if (!(item is Fries))
                header += ((dynamic) item).Type.ToString() + " ";

            Console.WriteLine("{0}{1} - {2} ron", header, item.GetType().Name, item.Price);
        }
    }
}