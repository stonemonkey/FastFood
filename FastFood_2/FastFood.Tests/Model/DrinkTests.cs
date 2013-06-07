using FastFood.Model;
using FastFood.Ordering;
using NUnit.Framework;

namespace FastFood.Tests.Model
{
    [TestFixture]
    public class DrinkTests : MealItemTests<Drink>
    {
        [Test]
        public void Ctor_initializes_type()
        {
            var drink = new Drink(DrinkTypes.Orange, 0);

            Assert.AreEqual(DrinkTypes.Orange, drink.Type);
        }

        protected override Drink BuildItem(decimal price)
        {
            return new Drink(DrinkTypes.Cola, price);
        }
    }
}