using FastFoodService.Wrappings;

namespace FastFoodService.MenuItems
{
    /// <summary>
    /// Represents a fast food Menu Item.
    /// All Menu Items served within the fast food service have to derive from this class.
    /// </summary>
    public abstract class MenuItem
    {
        #region Public properties

        /// <summary>
        /// Gets the Menu Item's Name.
        /// </summary>
        public string Name
        {
            get { return GetType().Name; }
        }

        /// <summary>
        /// Each Menu Item may have a Wrapping.
        /// Gets/Sets the Menu Item Wrapping (null is no Wrapping exists).
        /// </summary>
        public Wrapping Wrapping { get; set; }

        /// <summary>
        /// Gets a boolean value stating if the Menu Item is already wrapped or not.
        /// </summary>
        public bool IsWrapped
        {
            get { return Wrapping != null; }
        }

        /// <summary>
        /// Gets the Menu Item's Price.
        /// </summary>
        public abstract decimal Price { get; }

        #endregion
    }
}
