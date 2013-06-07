using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using FastFoodService.MenuItems;
using FastFoodService.Wrappings;

namespace FastFoodService.Test
{
    [TestFixture, Description("Tests the correctness of the Menu Items.")]
    class MenuItemTest
    {
        #region IsWrapped related tests

        [Test, Description("Tests the IsWrapped property of a Menu Item when no Wrapping exists.")]
        public void IsMenuItemIsWrappedMethodWorkingCorrectlyWhenAWrappingDoesntExistsTest()
        {
            var aMenuItem = Mock.Of<MenuItem>();
            aMenuItem.Wrapping = null;

            Assert.IsFalse(aMenuItem.IsWrapped, "The Menu Item shall not be wrapped as long as the Wrapping is missing!");
        }

        [Test, Description("Tests the IsWrapped property of a Menu Item when a Wrapping exists.")]
        public void IsMenuItemIsWrappedMethodWorkingCorrectlyWhenAWrappingExistsTest()
        {
            var aMenuItem = Mock.Of<MenuItem>();
            aMenuItem.Wrapping = Mock.Of<Wrapping>();

            Assert.IsTrue(aMenuItem.IsWrapped, "The Menu Item shall be wrapped as long as a Wrapping is provided!");
        }

        [Test, Description("Tests the IsWrapped property of a newly creted Menu Item.")]
        public void IsMenuItemNotWrappedByDefaultTest()
        {
            Assert.IsFalse(Mock.Of<MenuItem>().IsWrapped, "The Menu Item shall not be wrapped as long as the Wrapping is missing!");
        }
        
        [Test, Description("Tests the IsWrapped property of a Toy Menu Item.")]
        public void IsToyWrappedByDefaultTest()
        {
            Assert.IsTrue(Mock.Of<Toy>().IsWrapped, "The Toy shall be pre wrapped by default!");
        }

        #endregion

        #region Wrapping related tests

        [Test, Description("Tests the association of a Wrapping with a Menu Item.")]
        public void CanWrappingBeAssociatedToAMenuItemTest()
        {
            var aMenuItem = Mock.Of<MenuItem>();
            var aWrapping = Mock.Of<Wrapping>();
            aMenuItem.Wrapping = aWrapping;

            Assert.That(aWrapping.Equals(aMenuItem.Wrapping), "The Menu Item Wrapping is not correct!");
        }

        [Test, Description("Tests the removal of a Wrapping from a Menu Item.")]
        public void CanWrappingBeRemovedFromAMenuItemTest()
        {
            var aMenuItem = Mock.Of<MenuItem>();
            var aWrapping = Mock.Of<Wrapping>();
            aMenuItem.Wrapping = aWrapping;
            aMenuItem.Wrapping = null;

            Assert.IsNull(aMenuItem.Wrapping, "The Menu Item Wrapping shall not be present anymore!");
        }

        [Test, Description("Test the fact that all Menu Items, except the Toy, are not pre wrapped.")]
        public void DoAllMenuItemsExceptToysMissingTheWrappingTest()
        {
            var notPreWrappedMenuItems = new List<MenuItem> {
                Mock.Of<FrenchFries>(),
                Mock.Of<Soda>(),
                Mock.Of<Burger>(),
                Mock.Of<Menu>(),
            };

            foreach (MenuItem aMenuItem in notPreWrappedMenuItems)
            {
                Assert.IsNull(aMenuItem.Wrapping, string.Format("The {0} shall not have a Wrapping defined by default!", aMenuItem.Name));
            }
        }

        [Test, Description("Tests the fact that a Toy Menu Item is associated with a Wrapping by default.")]
        public void IsToyHavingADefaultWrappingTest()
        {
            Assert.IsNotNull(Mock.Of<Toy>().Wrapping, "The Toy, being pre wrapped, shall have a Wrapping defined by default!");
        }

        #endregion

        #region Items related tests

        [Test, Description("Tests the correctness of the Menu.Items property in case of an empty Menu.")]
        public void IsMenuContainingNoMenuItemsByDefaultTest()
        {
            var aMenu = new Menu();

            Assert.IsNotNull(aMenu.Items, "Upon initialization, the Menu shall not contain any Items!");
            Assert.AreEqual(0, aMenu.Items.Count, "Upon initializatin, the Menu shall contain zero Items!");
        }

        [Test, Description("Tests the correctness of the Menu.Items property in case of a Menu which contains some items.")]
        public void IsMenuHandlingOfTheMenuItemsCorrectTest()
        {
            var someMenuItems = new List<MenuItem>();
            int numberOfMenuItems = new Random().Next(1, 100);
            for (int idx = 0; idx < numberOfMenuItems; idx++)
            {
                var aMenuItem = new Mock<MenuItem>();
                aMenuItem.Setup(m => m.Price).Returns(new Random().Next(0, 100));
                someMenuItems.Add(aMenuItem.Object);
            }
            
            var aMenu = new Menu();
            aMenu.Items.AddRange(someMenuItems);

            Assert.AreEqual(someMenuItems.Count, aMenu.Items.Count, "The number of Items contained within the Menu is not correct!");
            foreach (MenuItem aMenuItem in someMenuItems)
            {
                Assert.Contains(aMenuItem, aMenu.Items, "Invalid Menu Item was found within the Menu!");
            }
        }

        #endregion

        #region Price related tests

        [Test, Description("Tests the correctness of the Menu Price calculation in case that the Menu Contains zero items.")]
        public void IsMenuPriceCorrectAsLongItDoesntContainAnyMenuItemsTest()
        {
            Assert.AreEqual(0, new Menu().Price, "The Price of the Menu is not correct!");
        }

        [Test, Description("Tests the correctness of the Menu Price calculation in case that the Menu Contains one item.")]
        public void IsMenuPriceCorrectAsLongItContainsOneSingleMenuItemTest()
        {
            var aMenuItem = new Mock<MenuItem>();
            aMenuItem.Setup(m => m.Price).Returns(2);

            var aMenu = new Menu();
            aMenu.Items.Add(aMenuItem.Object);

            Assert.AreEqual(aMenuItem.Object.Price, aMenu.Price, "The Price of the Menu is not correct!");
        }

        [Test, Description("Tests the correctness of the Menu Price calculation in case that the Menu Contains more than one item.")]
        public void IsMenuPriceCorrectAsLongItContainsMultipleMenuItemsTest()
        {
            var someMenuItems = new List<MenuItem>();
            decimal expectedMenuItemPrice = 0;
            for (int idx = 0; idx < new Random().Next(2, 100); idx++)
            {
                var aMenuItem = new Mock<MenuItem>();
                aMenuItem.Setup(m => m.Price).Returns(new Random().Next(0, 50));
                expectedMenuItemPrice += aMenuItem.Object.Price;
                someMenuItems.Add(aMenuItem.Object);
            }

            var aMenu = new Menu();
            aMenu.Items.AddRange(someMenuItems);

            Assert.AreEqual(expectedMenuItemPrice, aMenu.Price, "The Price of the Menu is not correct!");
        }

        #endregion
    }
}
