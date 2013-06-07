using System;

namespace fastfood
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Order order = menu.CreateOrder();
            Lunch lunch = order.Prepare();
            Console.WriteLine(lunch);
        }
    }
}
