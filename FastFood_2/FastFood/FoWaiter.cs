using FastFood.Interface;
using FastFood.Model;
using FastFood.Ordering;

namespace FastFood
{
    /// <summary>
    /// Implements Fo FastFood waiter maneuvres. This is the behaviour a weiter working for Fo FastFood.
    /// </summary>
    public class FoWaiter
    {
        #region Private fields

        private readonly Bag _currentMealBag;
        private Order _currentOrder;

        #endregion

        public ICateringOperations CateringOperations { get; private set; }

        public FoWaiter(ICateringOperations cateringOperations)
        {
            _currentMealBag = new Bag();

            CateringOperations = cateringOperations;
        }

        public Bag CreateMeal(Order order)
        {
            _currentOrder = order;
            _currentMealBag.Clear();

            PackOrderedMealItemsIntoMealBag();

            return _currentMealBag;
        }

        #region Private methods

        private void PackOrderedMealItemsIntoMealBag()
        {
            AddBurgerBag();

            AddDrinkBag();

            AddFriesBag();

            AddToy();
        }
        
        private void AddToy()
        {
            var toy = CateringOperations.GetToy(_currentOrder.ToyType);

            AddItem(toy);
        }

        private void AddFriesBag()
        {
            var fries = CateringOperations.GetFries();
            var friesBag = CateringOperations.Pack(fries);

            AddItem(friesBag);
        }

        private void AddDrinkBag()
        {
            var drink = CateringOperations.GetDrink(_currentOrder.DrinkType);
            var drinkBag = CateringOperations.Pack(drink);

            AddItem(drinkBag);
        }

        private void AddBurgerBag()
        {
            var burger = CateringOperations.GetBurger(_currentOrder.BurgerType);
            var burgerBag = CateringOperations.Pack(burger);

            AddItem(burgerBag);
        }

        private void AddItem(IMealItem item)
        {
            if (item != null)
                _currentMealBag.Add(item);           
        }

        #endregion
    }
}