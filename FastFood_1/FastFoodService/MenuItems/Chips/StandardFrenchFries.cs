namespace FastFoodService.MenuItems.Chips
{
    /// <summary>
    /// Specific type of French Fries.
    /// </summary>
    public class StandardFrenchFries : FrenchFries
    {
        #region Public properties

        /// <summary>
        /// Implements <see cref="MenuItem.Price"/> property.
        /// </summary>
        public override decimal Price
        {
            get { return 7; }
        }

        #endregion
    }
}
