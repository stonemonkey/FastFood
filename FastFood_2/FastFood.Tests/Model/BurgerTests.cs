using FastFood.Model;
using FastFood.Ordering;
using NUnit.Framework;

namespace FastFood.Tests.Model
{
    [TestFixture]
    public class BurgerTests : MealItemTests<Burger>
    {
        [Test]
        public void Ctor_initializes_type()
        {
            var burger = new Burger(BurgerTypes.Chicken, 0);

            Assert.AreEqual(BurgerTypes.Chicken, burger.Type);
        }

        protected override Burger BuildItem(decimal price)
        {
            return new Burger(BurgerTypes.Vegetable, price);
        }
    }
}