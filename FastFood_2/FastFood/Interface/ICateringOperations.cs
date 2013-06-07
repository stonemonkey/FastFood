using FastFood.Ordering;

namespace FastFood.Interface
{
    public interface ICateringOperations
    {
        IMealItem GetBurger(BurgerTypes type);

        IMealItem GetDrink(DrinkTypes type);

        IMealItem GetFries();

        IMealItem GetToy(ToyTypes type);

        IMealItem Pack(IMealItem item);
    }
}