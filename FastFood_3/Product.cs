using System;

namespace fastfood
{
    internal class Product
    {
        protected readonly string name;
        private readonly Money price;

        public Product(string name, Money price)
        {
            this.name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return name + " (" + price + ")";
        }

        public void Prepare()
        {
            Console.WriteLine("preparing " + name);
            Wrap();
        }

        protected virtual void Wrap()
        {
            Console.WriteLine("wrapping " + name );
        }

        public Money Price()
        {
            return price;
        }
    }
}