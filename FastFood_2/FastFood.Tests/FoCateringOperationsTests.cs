using System.Collections.Generic;
using System.Linq;
using FastFood.Interface;
using FastFood.Model;
using FastFood.Ordering;
using Moq;
using NUnit.Framework;

namespace FastFood.Tests
{
    [TestFixture]
    public class FoCateringOperationsTests
    {
        private FoCateringOperations _operations;

        private Mock<IPriceList> _mockPriceList;

        [SetUp]
        public void TestInitialize()
        {
            _mockPriceList = new Mock<IPriceList>();
            _operations = new FoCateringOperations(_mockPriceList.Object);
        }

        #region GetBurger tests

        [Test]
        public void GetBurger_returns_new_burger()
        {
            var burger = _operations.GetBurger(BurgerTypes.Vegetable);

            Assert.AreNotSame(_operations.GetBurger(BurgerTypes.Vegetable), burger);
        }

        [TestCase(BurgerTypes.Vegetable)]
        [TestCase(BurgerTypes.Chicken)]
        public void GetBurger_returns_burger_having_specified_type(BurgerTypes type)
        {
            var burger = (Burger) _operations.GetBurger(type);

            Assert.AreEqual(type, burger.Type);
        }

        [TestCase(BurgerTypes.Vegetable)]
        [TestCase(BurgerTypes.Chicken)]
        public void GetBurger_returns_burger_having_price_from_PriceList(BurgerTypes type)
        {
            _operations.GetBurger(type);

            _mockPriceList.Verify(x => x.GetBurgerPrice(type), Times.Once());
        }

        #endregion
        
        #region GetDrink tests

        [Test]
        public void GetDrink_returns_new_burger()
        {
            var drink = _operations.GetDrink(DrinkTypes.Cola);

            Assert.AreNotSame(_operations.GetDrink(DrinkTypes.Cola), drink);
        }

        [TestCase(DrinkTypes.Cola)]
        [TestCase(DrinkTypes.Orange)]
        public void GetDrink_returns_burger_having_specified_type(DrinkTypes type)
        {
            var drink = (Drink)_operations.GetDrink(type);

            Assert.AreEqual(type, drink.Type);
        }

        [TestCase(DrinkTypes.Cola)]
        [TestCase(DrinkTypes.Orange)]
        public void GetDrink_returns_burger_having_price_from_PriceList(DrinkTypes type)
        {
            _operations.GetDrink(type);

            _mockPriceList.Verify(x => x.GetDrinkPrice(type), Times.Once());
        }

        #endregion

        #region GetFries tests

        [Test]
        public void GetFries_returns_new_fries()
        {
            var fries = _operations.GetFries();

            Assert.AreNotSame(_operations.GetFries(), fries);
        }
        
        [Test]
        public void GetFries_returns_fries_having_price_from_PriceList()
        {
            _operations.GetFries();

            _mockPriceList.Verify(x => x.GetFriesPrice(), Times.Once());
        }
        
        #endregion

        #region GetToy tests

        [Test]
        public void GetToy_returns_new_burger()
        {
            var toy = _operations.GetToy(ToyTypes.Car);

            Assert.AreNotSame(_operations.GetToy(ToyTypes.Car), toy);
        }

        [TestCase(ToyTypes.Car)]
        [TestCase(ToyTypes.Doll)]
        public void GetToy_returns_burger_having_specified_type(ToyTypes type)
        {
            var toy = (Toy)_operations.GetToy(type);

            Assert.AreEqual(type, toy.Type);
        }

        [TestCase(ToyTypes.Car)]
        [TestCase(ToyTypes.Doll)]
        public void GetToy_returns_burger_having_price_from_BurgerPriceList(ToyTypes type)
        {
            _operations.GetToy(type);

            _mockPriceList.Verify(x => x.GetToyPrice(type), Times.Once());
        }

        #endregion

        #region Pack tests

        [Test]
        public void Pack_returns_new_bag()
        {
            var bag = _operations.Pack(null);

            Assert.AreNotSame(_operations.Pack(null), bag);
        }

        [Test]
        public void Pack_fills_bag_with_meal_item()
        {
            var burger = new Burger(BurgerTypes.Vegetable, 1m);

            var bag = _operations.Pack(burger);

            Assert.AreSame(burger, ((IEnumerable<IMealItem>) bag).Single());
        }

        #endregion
    }
}