using System;

namespace FastFoodService.Exceptions
{
    /// <summary>
    /// Exception to be thrown when no wrapping for a certain Menu Item Type is found.
    /// </summary>
    public class MissingWrappingForMenuItemException: Exception
    {
        public MissingWrappingForMenuItemException() {}

        public MissingWrappingForMenuItemException(string message): base(message) {}

        public MissingWrappingForMenuItemException(string message, Exception innerException) : base(message, innerException) { }
    }
}
