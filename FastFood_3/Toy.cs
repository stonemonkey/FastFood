using System;

namespace fastfood
{
    internal class Toy : Product
    {
        public Toy(string name, Money price) : base(name, price)
        {
        }

        protected override void Wrap()
        {
            Console.WriteLine("will not wrap toy as it is already wrapped");
        }
    }
}