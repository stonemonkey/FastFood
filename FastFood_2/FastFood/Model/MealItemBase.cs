using FastFood.Interface;

namespace FastFood.Model
{
    public abstract class MealItemBase : IMealItem
    {
        public decimal Price { get; set; }

        protected MealItemBase(decimal price)
        {
            Price = price;
        }
    }
}