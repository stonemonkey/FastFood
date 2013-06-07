using System;
using FastFoodService.Exceptions;
using FastFoodService.MenuItems;
using FastFoodService.Wrappings;

namespace FastFoodService
{
    /// <summary>
    /// Singleton factory class, responsible in returning the correct Wrapper for a certain Menu Item.
    /// </summary>
    public class DefaultWrappingService: IWrappingService
    {
        #region Private constructors

        private DefaultWrappingService() { }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the instance of the DefaultWrappingService class.
        /// Clasical Singleton implementation.
        /// </summary>
        /// <returns></returns>
        public static DefaultWrappingService GetInstance()
        {
            lock (typeof(DefaultWrappingService))
            {
                if (instance == null)
                {
                    instance = new DefaultWrappingService();
                }
                return instance;
            }
        }

        /// <summary>
        /// Implements <see cref="IWrappingService.GetWrapping&lt;T&gt;()"/> method.
        /// </summary>
        public Wrapping GetWrapping<T>() where T: MenuItem
        {
            Type menuItemType = typeof(T);
            //The below code shall be refactored reading an external configuration where adding new Wrappers for
            //new available Menu Items shall be an easy, not necessiting a recompilation, operation (configuration).
            //And of course, the configurations may be added for concrete Menu Items.
            //For the purpose of the exercise, the below hardcoded code shall be sufficient.
            if (typeof(Burger).IsAssignableFrom(menuItemType) || typeof(Soda).IsAssignableFrom(menuItemType) || typeof(FrenchFries).IsAssignableFrom(menuItemType)) 
                return new SomeWrapping();
            if (typeof(Toy).IsAssignableFrom(menuItemType))
                return new BuiltInWrapping();
            if (typeof(Menu).IsAssignableFrom(menuItemType))
                    return new BoxWrapping();

            throw new MissingWrappingForMenuItemException(menuItemType.Name);
        }

        #endregion

        #region Private members

        private static DefaultWrappingService instance;

        #endregion
    }
}
