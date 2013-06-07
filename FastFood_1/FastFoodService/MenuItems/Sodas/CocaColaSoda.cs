namespace FastFoodService.MenuItems.Sodas
{
    /// <summary>
    /// Specific type of Soda.
    /// </summary>
    public class CocaColaSoda : Soda
    {
        #region Public properties

        /// <summary>
        /// Implements <see cref="MenuItem.Price"/> property.
        /// </summary>
        public override decimal Price
        {
            get { return 3; }
        }

        #endregion
    }
}
