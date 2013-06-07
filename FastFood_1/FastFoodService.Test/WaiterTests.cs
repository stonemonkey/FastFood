using System;
using Moq;
using NUnit.Framework;
using FastFoodService.Exceptions;
using FastFoodService.MenuItems;
using FastFoodService.MenuItems.Burgers;
using FastFoodService.MenuItems.Chips;
using FastFoodService.MenuItems.Sodas;
using FastFoodService.MenuItems.Toys;

namespace FastFoodService.Test
{
    [TestFixture, Description("Tests the correctness of the Waiter.")]
    class WaiterTests
    {
        [Test, Description("Tests the fact that the correct WrappingService is used by default by the Waiter.")]
        public void IsWaiterUsingTheDefaultWrappingServiceTest()
        {
            Assert.AreEqual(DefaultWrappingService.GetInstance().GetType(),  new Waiter().WrappingService.GetType(), 
                "Incorrect default Wrapping Service used by the Waiter!");
        }

        [Test, Description("Tests the fact that a Waiter may work with different Wrapping Services.")]
        public void IsWaiterAbleToUseAnotherWrappingServiceTest()
        {
            var waiter = new Waiter();
            var aWrappingService = Mock.Of<IWrappingService>();
            waiter.WrappingService = aWrappingService;

            Assert.That(aWrappingService.Equals(waiter.WrappingService), "The Waiter Wrapping Service is not correct!");
        }

        [Test, Description("Tests the fact that, if a Menu cannot be served by the Waiter, the proper exception is thrown.")]
        [ExpectedException(typeof(CannotServeMenuException))]
        public void IsWaiterReturningTheCorrectMessageIfMenuCannotBeServedTest()
        {
            var waiter = new Waiter();
            var aWrappingService = new Mock<IWrappingService>();
            aWrappingService.Setup(m => m.GetWrapping<Burger>()).Throws(new MissingWrappingForMenuItemException("wer"));
            waiter.WrappingService = aWrappingService.Object;

            try
            {
                waiter.ServeMenu<VegetableBurger, CocaColaSoda, StandardFrenchFries, DollToy>();
            }
            catch (Exception exc)
            {
                int i = 0;
            }
            
        }

        [Test, Description("Tests the fact that a waiter can server a Menu as long all the Menu Items are known.")]
        public void CanWaiterServeACorrectMenuTest()
        {
            new Waiter().ServeMenu<VegetableBurger, CocaColaSoda, StandardFrenchFries, DollToy>();
        }
    }
}
