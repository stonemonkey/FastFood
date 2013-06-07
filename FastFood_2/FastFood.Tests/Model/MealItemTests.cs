using FastFood.Model;
using NUnit.Framework;

namespace FastFood.Tests.Model
{
    [TestFixture]
    public abstract class MealItemTests<TMealItem>
        where TMealItem : MealItemBase
    {
        protected abstract TMealItem BuildItem(decimal price);

        [Test]
        public void Ctor_initializes_Price()
        {
            var item = BuildItem(5.5m);

            Assert.AreEqual(5.5m, item.Price);
        }
    }
}