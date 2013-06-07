using FastFood.Ordering;

namespace FastFood.Model
{
    public class Toy : MealItemBase
    {
        public ToyTypes Type { get; private set; }

        public Toy(ToyTypes type, decimal price)
            : base(price)
        {
            Type = type;
        }
    }
}