using FastFood.Ordering;

namespace FastFood.Model
{
    public class Burger : MealItemBase
    {
        public BurgerTypes Type { get; private set; }

        public Burger(BurgerTypes type, decimal price) 
            : base(price)
        {
            Type = type;
        }
    }
}