using System;

namespace FastFoodService.Exceptions
{
    /// <summary>
    /// Exception to be thrown when the Menu cannot be created (possible due to a Wrapping issue).
    /// </summary>
    public class CannotServeMenuException : Exception
    {
        public CannotServeMenuException() { }

        public CannotServeMenuException(string message) : base(message) { }

        public CannotServeMenuException(string message, Exception innerException) : base(message, innerException) { }
    }
}
