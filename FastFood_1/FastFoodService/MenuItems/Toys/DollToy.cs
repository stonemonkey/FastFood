using FastFoodService.Exceptions;

namespace FastFoodService.MenuItems.Toys
{
    /// <summary>
    /// Specific type of Toy.
    /// </summary>
    public class DollToy: Toy
    {
        #region Public properties

        /// <summary>
        /// Implements <see cref="MenuItem.Price"/> property.
        /// </summary>
        public override decimal Price
        {
            get { return 1; }
        }

        #endregion
    }
}
