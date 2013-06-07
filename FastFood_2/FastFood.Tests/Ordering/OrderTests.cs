using FastFood.Ordering;
using NUnit.Framework;

namespace FastFood.Tests.Ordering
{
    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void Ctor_initializes_BurgerType()
        {
            var clientChoices = new Order(BurgerTypes.Chicken, DrinkTypes.Cola, ToyTypes.Car);

            Assert.AreEqual(BurgerTypes.Chicken, clientChoices.BurgerType);
        }

        [Test]
        public void Ctor_initializes_DrinkType()
        {
            var clientChoices = new Order(BurgerTypes.Chicken, DrinkTypes.Orange, ToyTypes.Car);

            Assert.AreEqual(DrinkTypes.Orange, clientChoices.DrinkType);
        }
        
        [Test]
        public void Ctor_initializes_ToyType()
        {
            var clientChoices = new Order(BurgerTypes.Chicken, DrinkTypes.Orange, ToyTypes.Doll);

            Assert.AreEqual(ToyTypes.Doll, clientChoices.ToyType);
        }
    }
}