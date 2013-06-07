using FastFood.Model;
using FastFood.Ordering;
using NUnit.Framework;

namespace FastFood.Tests.Model
{
    [TestFixture]
    public class ToyTests : MealItemTests<Toy>
    {
        [Test]
        public void Ctor_initializes_type()
        {
            var toy = new Toy(ToyTypes.Doll, 0);

            Assert.AreEqual(ToyTypes.Doll, toy.Type);
        }

        protected override Toy BuildItem(decimal price)
        {
            return new Toy(ToyTypes.Car, price);
        }
    }
}