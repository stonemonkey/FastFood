﻿namespace FastFoodService.MenuItems.Burgers
{
    /// <summary>
    /// Specific type of Burger.
    /// </summary>
    public class FishBurger : Burger
    {
        #region Public properties

        /// <summary>
        /// Implements <see cref="MenuItem.Price"/> property.
        /// </summary>
        public override decimal Price
        {
            get { return 8; }
        }

        #endregion
    }
}
