using FastFood.Model;
using NUnit.Framework;

namespace FastFood.Tests.Model
{
    [TestFixture]
    public class FriesTests : MealItemTests<Fries>
    {
        protected override Fries BuildItem(decimal price)
        {
            return new Fries(price);
        }
    }
}