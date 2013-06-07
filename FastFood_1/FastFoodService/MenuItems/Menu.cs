using System.Collections.Generic;
using System.Linq;

namespace FastFoodService.MenuItems
{
    /// <summary>
    /// Base Menu.
    /// </summary>
    public class Menu: MenuItem
    {
        #region Public constructors

        /// <summary>
        /// Initializes an empty list of Menu Items.
        /// </summary>
        public Menu()
        {
            Items = new List<MenuItem>();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets/Sets the list of Items contained within the Menu.
        /// If the Menu does not contain any items, an empty list is returned.
        /// </summary>
        public List<MenuItem> Items { get; set; }

        /// <summary>
        /// Implements <see cref="MenuItem.Price"/> property.
        /// It is supposed that the price of a Menu is calculated based on its composing Items prices (for fun).
        /// </summary>
        public override decimal Price
        {
            get { return Items.Sum(aMenuItem => aMenuItem.Price); }
        }

        #endregion
    }
}
