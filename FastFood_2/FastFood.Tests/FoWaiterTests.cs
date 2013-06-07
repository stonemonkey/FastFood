using System.Linq;
using FastFood.Interface;
using FastFood.Model;
using FastFood.Ordering;
using Moq;
using NUnit.Framework;

namespace FastFood.Tests
{
    public class FoWaiterTests
    {
        #region Private fields

        private FoWaiter _waiter;

        private Mock<ICateringOperations> _mockMealBuilder;

        private const decimal SamplePrice = 1m;

        #endregion

        [SetUp]
        public void TestInitialize()
        {
            _mockMealBuilder = new Mock<ICateringOperations>();
            _waiter = new FoWaiter(_mockMealBuilder.Object);
        }

        [Test]
        public void Ctor_initialize_MealBuilder()
        {           
            Assert.AreSame(_mockMealBuilder.Object, _waiter.CateringOperations);
        }

        [Test]
        public void CreateMeal_returns_bag_with_one_Burger_bag()
        {
            var burger = new Burger(BurgerTypes.Chicken, SamplePrice);
            _mockMealBuilder.Setup(x => x.GetBurger(BurgerTypes.Chicken))
                .Returns(burger);
            var burgerPack = SetupMealBuilderToPackItem(burger);

            var bag = _waiter.CreateMeal(new Order(BurgerTypes.Chicken, DrinkTypes.Cola, ToyTypes.Car));

            Assert.AreSame(burgerPack, bag.Single());
        }

        [Test]
        public void CreateMeal_returns_bag_with_one_Drink_bag()
        {
            var drink = new Drink(DrinkTypes.Orange, SamplePrice);
            _mockMealBuilder.Setup(x => x.GetDrink(DrinkTypes.Orange))
                .Returns(drink);
            var drinkPack = SetupMealBuilderToPackItem(drink);

            var bag = _waiter.CreateMeal(new Order(BurgerTypes.Vegetable, DrinkTypes.Orange, ToyTypes.Car));

            Assert.AreSame(drinkPack, bag.Single());
        }

        [Test]
        public void CreateMeal_returns_bag_with_one_Fries_bag()
        {
            var fries = new Fries(SamplePrice);
            _mockMealBuilder.Setup(x => x.GetFries())
                .Returns(fries);
            var friesPack = SetupMealBuilderToPackItem(fries);

            var bag = _waiter.CreateMeal(new Order(BurgerTypes.Vegetable, DrinkTypes.Cola, ToyTypes.Car));

            Assert.AreSame(friesPack, bag.Single());
        }

        [Test]
        public void CreateMeal_returns_bag_with_one_Toy()
        {
            var toy = new Toy(ToyTypes.Doll, SamplePrice);
            _mockMealBuilder.Setup(x => x.GetToy(ToyTypes.Doll))
                .Returns(toy);
            
            var bag = _waiter.CreateMeal(new Order(BurgerTypes.Vegetable, DrinkTypes.Cola, ToyTypes.Doll));

            Assert.AreSame(toy, bag.Single());
        }
        
        [Test]
        public void CreateMeal_returns_bag_with_one_Toy_for_a_second_order()
        {
            var toy = new Toy(ToyTypes.Doll, SamplePrice);
            _mockMealBuilder.Setup(x => x.GetToy(ToyTypes.Doll))
                .Returns(toy);
            _waiter.CreateMeal(new Order(BurgerTypes.Vegetable, DrinkTypes.Cola, ToyTypes.Doll));
            
            var bag = _waiter.CreateMeal(new Order(BurgerTypes.Vegetable, DrinkTypes.Cola, ToyTypes.Doll));

            Assert.AreSame(toy, bag.Single());
        }

        #region Private methods

        private Bag SetupMealBuilderToPackItem(IMealItem item)
        {
            var burgerPack = new Bag { item };

            _mockMealBuilder.Setup(x => x.Pack(item))
                .Returns(burgerPack);

            return burgerPack;
        }

        #endregion
    }
}
