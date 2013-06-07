using FastFoodService.Exceptions;

namespace FastFoodService.MenuItems
{
    /// <summary>
    /// Base Toy.
    /// A particularity of the Toy class is the fact that it is Pre Wrapped, nobody being responsible in providing the Wrapping.
    /// Still, if somebody desires to provide a different Wrapping, it may still do that (not sure that this is correct, but has
    /// some valid logic if you chew it); also, not allowing this operation will break the LSP.
    /// </summary>
    public abstract class Toy : MenuItem
    {
        #region Protected constructors

        /// <summary>
        /// Instantiates the Toy class based on a default Wrapping Service.
        /// </summary>
        /// <exception cref="MissingWrappingForMenuItemException">Thrown is no Wrapping for the Toy was found.</exception>
        protected Toy(): this(DefaultWrappingService.GetInstance())
        {
        }

        /// <summary>
        /// Instantiates the Toy class based on a specified Wrapping Service.
        /// </summary>
        /// <param name="aWrappingService">Wrapping Service responsible in providing a specific Wrapping for the Toy.</param>
        /// <exception cref="MissingWrappingForMenuItemException">Thrown is no Wrapping for the Toy was found.</exception>
        protected Toy(IWrappingService aWrappingService)
        {
            Wrapping = aWrappingService.GetWrapping<Toy>();
        }
        
        #endregion
    }
}
