namespace FastFoodService.MenuItems.Sodas
{
    /// <summary>
    /// Specific type of Soda.
    /// </summary>
    public class OrangeSoda : Soda
    {
        #region Public properties

        /// <summary>
        /// Implements <see cref="MenuItem.Price"/> property.
        /// </summary>
        public override decimal Price
        {
            get { return 4; }
        }

        #endregion
    }
}
