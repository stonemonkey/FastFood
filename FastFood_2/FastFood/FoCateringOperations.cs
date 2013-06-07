using FastFood.Interface;
using FastFood.Model;
using FastFood.Ordering;

namespace FastFood
{
    /// <summary>
    /// Implements all Fo FastFood possible operations. This is the definition of Fo FastFood process.
    /// </summary>
    public class FoCateringOperations : ICateringOperations
    {
        public IPriceList PriceList { get; private set; }

        public FoCateringOperations(IPriceList priceList)
        {
            PriceList = priceList;
        }

        public IMealItem GetBurger(BurgerTypes type)
        {
            // could be: ask the cook to make a burger ...
            return new Burger(type, PriceList.GetBurgerPrice(type));
        }

        public IMealItem GetDrink(DrinkTypes type)
        {
            // could be: go to the refrigerator and take a drink ...
            return new Drink(type, PriceList.GetDrinkPrice(type));
        }

        public IMealItem GetFries()
        {
            // could be: go to the fries machine and get fries ...
            return new Fries(PriceList.GetFriesPrice());
        }

        public IMealItem GetToy(ToyTypes type)
        {
            // could be: go to the closet and take a toy ...
            return new Toy(type, PriceList.GetToyPrice(type));
        }

        public IMealItem Pack(IMealItem item)
        {
            // could be: put the item into a paper bag ...
            return new Bag(item);
        }
    }
}