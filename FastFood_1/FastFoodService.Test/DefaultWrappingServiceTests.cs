using NUnit.Framework;
using FastFoodService.Exceptions;
using FastFoodService.MenuItems;
using FastFoodService.Wrappings;

namespace FastFoodService.Test
{
    [TestFixture, Description("Tests the correctness of the Default Wrapping Service.")]
    class DefaultWrappingServiceTests
    {
        [Test, Description("Tests the fact that, for all current Menu Item Types, a valid Wrapping is returned by the DefaultWrappingService.")]
        public void IsDefaultWrappingServiceReturningAWrappingForAllRequiredMenuItemTypesTest()
        {
            Assert.That(DefaultWrappingService.GetInstance().GetWrapping<FrenchFries>(), Is.AssignableTo(typeof(Wrapping)),
                "The DefaultWrappingService is not returning an expected wrapping!");
            Assert.That(DefaultWrappingService.GetInstance().GetWrapping<Toy>(), Is.AssignableTo(typeof(Wrapping)),
                "The DefaultWrappingService is not returning an expected wrapping!");
            Assert.That(DefaultWrappingService.GetInstance().GetWrapping<Soda>(), Is.AssignableTo(typeof(Wrapping)),
                "The DefaultWrappingService is not returning an expected wrapping!");
            Assert.That(DefaultWrappingService.GetInstance().GetWrapping<Burger>(), Is.AssignableTo(typeof(Wrapping)),
                "The DefaultWrappingService is not returning an expected wrapping!");
            Assert.That(DefaultWrappingService.GetInstance().GetWrapping<Menu>(), Is.AssignableTo(typeof(Wrapping)),
                "The DefaultWrappingService is not returning an expected wrapping!");
        }

        [Test, Description("Tests the fact that, for a unknown Menu Item Type, the expected exception is thrown.")]
        [ExpectedException(typeof(MissingWrappingForMenuItemException))]
        public void IsDefaultWrappingServiceReturningTheCorrectMessageIfAWrappingForAMenuItemTypeIsNotFoundTest()
        {
            DefaultWrappingService.GetInstance().GetWrapping<MenuItem>();
        }
    }
}
