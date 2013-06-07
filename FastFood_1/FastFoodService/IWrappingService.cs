using FastFoodService.Exceptions;
using FastFoodService.MenuItems;
using FastFoodService.Wrappings;

namespace FastFoodService
{
    /// <summary>
    /// This interface represents the contract for any Fast Food Menu Item wrapping provider.
    /// </summary>
    public interface IWrappingService
    {
        /// <summary>
        /// Gets the corresponding Wrapper for a specific Menu Item Type.
        /// </summary>
        /// <exception cref="MissingWrappingForMenuItemException">Thrown is no Wrapping for the specified Menu Item Type was found.</exception>
        /// <returns>A Wrapper instance.</returns>
        Wrapping GetWrapping<T>() where T: MenuItem;
    }
}
