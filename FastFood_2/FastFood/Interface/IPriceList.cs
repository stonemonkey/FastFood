using FastFood.Ordering;

namespace FastFood.Interface
{
    public interface IPriceList
    {
        decimal GetBurgerPrice(BurgerTypes type);

        decimal GetDrinkPrice(DrinkTypes type);

        decimal GetToyPrice(ToyTypes type);

        decimal GetFriesPrice();
    }
}