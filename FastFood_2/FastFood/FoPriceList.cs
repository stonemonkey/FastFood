using System.Collections.Generic;
using FastFood.Interface;
using FastFood.Ordering;

namespace FastFood
{
    /// <summary>
    /// Implements all Fo FastFood price calculations.
    /// </summary>
    public class FoPriceList : IPriceList
    {
        #region Private members

        private readonly IDictionary<BurgerTypes, decimal> _burgersPriceList = new Dictionary<BurgerTypes, decimal>
        {
            { BurgerTypes.Vegetable, 5.5m },
            { BurgerTypes.Fish, 10m },
            { BurgerTypes.Chicken, 9.25m },
        };

        private readonly IDictionary<DrinkTypes, decimal> _drinksPriceList = new Dictionary<DrinkTypes, decimal>
        {
            { DrinkTypes.Cola, 4m },
            { DrinkTypes.Orange, 4m },
        };

        private readonly IDictionary<ToyTypes, decimal> _toysPriceList = new Dictionary<ToyTypes, decimal>
        {
            { ToyTypes.Car, 1m },
            { ToyTypes.Doll, 1.5m },
        };

        private const decimal FriesPrice = 6m;

        #endregion

        public decimal GetBurgerPrice(BurgerTypes type)
        {
            return _burgersPriceList[type];
        }

        public decimal GetDrinkPrice(DrinkTypes type)
        {
            return _drinksPriceList[type];
        }

        public decimal GetToyPrice(ToyTypes type)
        {
            return _toysPriceList[type];
        }

        public decimal GetFriesPrice()
        {
            return FriesPrice;
        }
    }
}