namespace FastFood.Ordering
{
    /// <summary>
    /// Implements user order in Fo FastFood.
    /// </summary>
    public class Order
    {
        public BurgerTypes BurgerType { get; private set; }

        public DrinkTypes DrinkType { get; private set; }

        public ToyTypes ToyType { get; private set; }

        public Order(BurgerTypes burgerType, DrinkTypes drinkType, ToyTypes toyType)
        {
            BurgerType = burgerType;
            DrinkType = drinkType;
            ToyType = toyType;
        }
    }
}