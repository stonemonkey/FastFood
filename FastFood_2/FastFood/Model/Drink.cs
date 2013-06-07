using FastFood.Ordering;

namespace FastFood.Model
{
    public class Drink : MealItemBase
    {
        public DrinkTypes Type { get; private set; }

        public Drink(DrinkTypes type, decimal price)
            : base(price)
        {
            Type = type;
        }
    }
}