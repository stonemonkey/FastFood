using System.Linq;
using FastFood.Model;
using FastFood.Ordering;
using NUnit.Framework;

namespace FastFood.Tests.Model
{
    [TestFixture]
    public class BagTests
    {
        private const decimal SamplePrice = 12.3456m;

        [Test]
        public void Ctor_initializes_empty_bag()
        {
            var bag = new Bag();

            CollectionAssert.IsEmpty(bag);
        }

        [Test]
        public void Ctor_initializes_collection_with_one_elment()
        {
            var fries = new Fries(SamplePrice);
            
            var bag = new Bag(fries);

            Assert.AreSame(fries, bag.Single());
        }

        [Test]
        public void Price_returns_0_when_bag_is_empty()
        {
            var bag = new Bag();

            Assert.AreEqual(0, bag.Price);
        }

        [Test]
        public void Price_returns_one_item_price_when_bag_contains_one_item()
        {
            var burger = new Fries(SamplePrice);
            var bag = new Bag { burger };

            Assert.AreEqual(burger.Price, bag.Price);
        }
        
        [Test]
        public void Price_returns_sum_of_all_packed_item_prices()
        {
            var burger = new Burger(BurgerTypes.Vegetable, SamplePrice);
            var drink = new Drink(DrinkTypes.Cola, SamplePrice);
            var fries = new Fries(SamplePrice);
            var bag = new Bag { burger, drink, fries };
            var toy = new Toy(ToyTypes.Car, SamplePrice);

            var mealBag = new Bag { bag, toy };

            Assert.AreEqual((burger.Price + drink.Price + fries.Price + toy.Price), mealBag.Price);
        }
    }
}