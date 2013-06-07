using FastFoodService.Exceptions;
using FastFoodService.MenuItems;

namespace FastFoodService
{
    /// <summary>
    /// Class responsible in serving a certaing Fast Food Menu, wrapping the Menu Items by default with the help of DefaultWrappingService.
    /// May be easily extended to serve not only Menus, but small Menu Items too.
    /// </summary>
    public class Waiter
    {
        #region Public constructors

        /// <summary>
        /// Instantiates a Waiter service with the DefaultWrappingService.
        /// </summary>
        public Waiter()
        {
            WrappingService = DefaultWrappingService.GetInstance();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets/Sets the Wrapping Service to be used by the Waiter. 
        /// </summary>
        public IWrappingService WrappingService { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Serves (creates) a Menu composed out of a Burger, aSoda, aFrenchFries and a Toy,
        /// wrapping each Menu Item part of the Menu, inclusiv the Menu.
        /// </summary>
        /// <exception cref="CannotServeMenuException">Thrown is the Menu cannot be served, often due to a Wrapping problem.</exception>
        /// <returns>The composed, wrapped, Menu.</returns>
        public Menu ServeMenu<TBurger, TSoda, TFrenchFries, TToy>()
            where TBurger : Burger, new()
            where TSoda : Soda, new()
            where TFrenchFries : FrenchFries, new()
            where TToy : Toy, new()
        {
            var menu = new Menu();

            try
            {
                menu.Items.Add(WrapMenuItem<Burger>(new TBurger()));
                menu.Items.Add(WrapMenuItem<Soda>(new TSoda()));
                menu.Items.Add(WrapMenuItem<FrenchFries>(new TFrenchFries()));
                menu.Items.Add(WrapMenuItem<Toy>(new TToy()));

                menu.Wrapping = WrappingService.GetWrapping<Menu>();
            }
            catch (MissingWrappingForMenuItemException exc)
            {
                throw new CannotServeMenuException("Menu cannot be served due to some missing wrapping!", exc);
            }

            return menu;
        }

        #endregion

        #region Private methods

        private MenuItem WrapMenuItem<TMenuItem>(MenuItem aMenuItem)
            where TMenuItem : MenuItem
        {
            if (!aMenuItem.IsWrapped)
                aMenuItem.Wrapping = WrappingService.GetWrapping<TMenuItem>();

            return aMenuItem;
        }

        #endregion
    }
}
